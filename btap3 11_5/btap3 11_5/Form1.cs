using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace btap3_11_5
{
    public partial class Form1 : Form
    {
        private const string AllStatuses = "Tất cả";

        private static readonly string[] DeviceTypes =
        {
            "Điện thoại",
            "Laptop",
            "Máy tính bảng",
            "Tivi",
            "Máy in",
            "Thiết bị khác"
        };

        private static readonly Regex PhoneNoise = new(@"[\s.\-()]");

        private readonly BindingList<RepairOrder> _all = new();   // toàn bộ đơn
        private readonly BindingList<RepairOrder> _view = new();  // đơn sau khi lọc (nguồn của BindingSource)
        private bool _loading;                                    // chặn SelectionChanged/Input_Changed khi nạp bằng code
        private string? _currentImagePath;                        // ảnh đang hiển thị trên form

        public Form1()
        {
            InitializeComponent();
            SetupControls();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            pbDevice.Image?.Dispose();
            pbDevice.Image = null;
            base.OnFormClosed(e);
        }

        // ------------------------------------------------------------------ khởi tạo

        private void SetupControls()
        {
            cboDevice.Items.AddRange(DeviceTypes);
            cboStatus.Items.AddRange(RepairOrder.Statuses);

            cboFilterStatus.Items.Add(AllStatuses);
            cboFilterStatus.Items.AddRange(RepairOrder.Statuses);
            cboFilterStatus.SelectedIndex = 0;

            bindingSource1.DataSource = _view;
            dgvOrders.DataSource = bindingSource1;

            SeedData();
            ApplyFilter();
            ClearForm();
        }

        private void SeedData()
        {
            DateTime t = DateTime.Today;
            _all.Add(new RepairOrder { Id = "DH001", CustomerName = "Nguyễn Văn Hùng", Phone = "0912345678", DeviceType = "Điện thoại", Description = "Vỡ màn hình, cảm ứng loạn", ReceivedDate = t.AddDays(-6), EstimatedCost = 1500000, Status = RepairOrder.StatusRepairing });
            _all.Add(new RepairOrder { Id = "DH002", CustomerName = "Trần Thị Mai", Phone = "0987654321", DeviceType = "Laptop", Description = "Không lên nguồn", ReceivedDate = t.AddDays(-4), EstimatedCost = 800000, Status = RepairOrder.StatusWaitingParts });
            _all.Add(new RepairOrder { Id = "DH003", CustomerName = "Lê Quốc Bảo", Phone = "0903111222", DeviceType = "Tivi", Description = "Màn hình sọc ngang", ReceivedDate = t.AddDays(-9), EstimatedCost = 2300000, Status = RepairOrder.StatusDone });
            _all.Add(new RepairOrder { Id = "DH004", CustomerName = "Phạm Thu Hà", Phone = "0868555777", DeviceType = "Máy in", Description = "Kẹt giấy, in bị mờ", ReceivedDate = t.AddDays(-2), EstimatedCost = 350000, Status = RepairOrder.StatusNew });
            _all.Add(new RepairOrder { Id = "DH005", CustomerName = "Đỗ Minh Khôi", Phone = "0933444555", DeviceType = "Máy tính bảng", Description = "Pin chai, sạc không vào", ReceivedDate = t.AddDays(-1), EstimatedCost = 600000, Status = RepairOrder.StatusNew });
            _all.Add(new RepairOrder { Id = "DH006", CustomerName = "Vũ Ngọc Lan", Phone = "0977888999", DeviceType = "Điện thoại", Description = "Rơi nước, không nhận sạc", ReceivedDate = t.AddDays(-5), EstimatedCost = 900000, Status = RepairOrder.StatusCancelled });
        }

        // ------------------------------------------------------------------ tiện ích

        private static string RemoveDiacritics(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Replace('đ', 'd').Replace('Đ', 'D').ToLowerInvariant();
        }

        private bool Confirm(string message) =>
            MessageBox.Show(this, message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        private void Info(string message) =>
            MessageBox.Show(this, message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private RepairOrder? GetSelected() =>
            dgvOrders.SelectedRows.Count > 0
                ? dgvOrders.SelectedRows[0].DataBoundItem as RepairOrder
                : null;

        private void DeselectAll()
        {
            dgvOrders.ClearSelection();
            dgvOrders.CurrentCell = null;
        }

        private bool SelectById(string id)
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.DataBoundItem is RepairOrder o && o.Id == id)
                {
                    dgvOrders.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    return true;
                }
            }
            DeselectAll();
            return false;
        }

        private string NextId()
        {
            int max = 0;
            foreach (var o in _all)
            {
                var m = Regex.Match(o.Id, @"^DH(\d+)$", RegexOptions.IgnoreCase);
                if (m.Success && int.TryParse(m.Groups[1].Value, out int n) && n > max) max = n;
            }
            return $"DH{max + 1:000}";
        }

        private bool TryParseCost(out decimal cost) =>
            decimal.TryParse(txtCost.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out cost);

        // ------------------------------------------------------------------ ảnh thiết bị

        /// <summary>Đọc ảnh vào bộ nhớ rồi đóng file ngay, để file không bị khóa.</summary>
        private static Image? LoadImageCopy(string path)
        {
            try
            {
                if (!File.Exists(path)) return null;
                using var fs = File.OpenRead(path);
                using var img = Image.FromStream(fs);
                return new Bitmap(img);
            }
            catch (Exception ex) when (ex is ArgumentException or IOException or UnauthorizedAccessException or OutOfMemoryException)
            {
                return null;
            }
        }

        private void ShowImage(string? path)
        {
            Image? img = string.IsNullOrEmpty(path) ? null : LoadImageCopy(path);

            var old = pbDevice.Image;
            pbDevice.Image = img;   // SizeMode = Zoom: giữ đúng tỷ lệ, không méo
            old?.Dispose();

            if (string.IsNullOrEmpty(path))
                lblImageName.Text = "Chưa chọn ảnh";
            else if (img == null)
                lblImageName.Text = "Không đọc được: " + Path.GetFileName(path);
            else
                lblImageName.Text = Path.GetFileName(path);
        }

        private void btnChooseImage_Click(object? sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            using (var test = LoadImageCopy(openFileDialog1.FileName))
            {
                if (test == null)
                {
                    MessageBox.Show(this, "Không thể mở file ảnh đã chọn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            _currentImagePath = openFileDialog1.FileName;
            ShowImage(_currentImagePath);
        }

        private void btnRemoveImage_Click(object? sender, EventArgs e)
        {
            _currentImagePath = null;
            ShowImage(null);
        }

        // ------------------------------------------------------------------ tìm kiếm / lọc

        private void ApplyFilter(string? keepId = null)
        {
            keepId ??= GetSelected()?.Id;

            string text = txtSearch.Text.Trim();
            string keyword = RemoveDiacritics(text);
            string phoneKey = PhoneNoise.Replace(text, "");
            string status = cboFilterStatus.SelectedItem as string ?? AllStatuses;

            var result = _all.Where(o =>
                    (text.Length == 0
                        || o.Id.Contains(text, StringComparison.OrdinalIgnoreCase)
                        || RemoveDiacritics(o.CustomerName).Contains(keyword)
                        || (phoneKey.Length > 0 && o.Phone.Contains(phoneKey)))
                    && (status == AllStatuses || o.Status == status))
                .OrderByDescending(o => o.ReceivedDate)
                .ThenBy(o => o.Id)
                .ToList();

            _loading = true;
            try
            {
                _view.RaiseListChangedEvents = false;
                _view.Clear();
                foreach (var o in result) _view.Add(o);
                _view.RaiseListChangedEvents = true;
                _view.ResetBindings();

                if (keepId == null || !SelectById(keepId))
                    DeselectAll();
            }
            finally
            {
                _loading = false;
            }

            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            decimal openTotal = _all.Where(o => o.IsOpen).Sum(o => o.EstimatedCost);
            lblCount.Text = $"Số đơn hiển thị: {_view.Count} / {_all.Count}";
            lblTotal.Text = $"Tổng chi phí dự kiến (đơn chưa hoàn tất): {openTotal.ToString("N0", CultureInfo.CurrentCulture)}";
        }

        private void Filter_Changed(object? sender, EventArgs e) => ApplyFilter();

        private void btnResetFilter_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterStatus.SelectedIndex = 0;
            ApplyFilter();
        }

        // ------------------------------------------------------------------ form <-> dữ liệu

        private void LoadToForm(RepairOrder o)
        {
            _loading = true;
            try
            {
                txtId.Text = o.Id;
                txtName.Text = o.CustomerName;
                txtPhone.Text = o.Phone;
                cboDevice.SelectedIndex = cboDevice.Items.IndexOf(o.DeviceType);
                txtDescription.Text = o.Description;
                dtpReceived.Value = o.ReceivedDate;
                txtCost.Text = o.EstimatedCost.ToString("#,##0.##", CultureInfo.CurrentCulture);
                cboStatus.SelectedIndex = cboStatus.Items.IndexOf(o.Status);

                _currentImagePath = string.IsNullOrEmpty(o.ImagePath) ? null : o.ImagePath;
                ShowImage(_currentImagePath);

                errorProvider1.Clear();
            }
            finally
            {
                _loading = false;
            }
        }

        private void ClearForm()
        {
            _loading = true;
            try
            {
                txtId.Text = NextId();
                txtName.Clear();
                txtPhone.Clear();
                cboDevice.SelectedIndex = 0;
                txtDescription.Clear();
                dtpReceived.Value = DateTime.Today;
                txtCost.Text = "0";
                cboStatus.SelectedIndex = 0;

                _currentImagePath = null;
                ShowImage(null);

                errorProvider1.Clear();
                DeselectAll();
            }
            finally
            {
                _loading = false;
            }
        }

        private RepairOrder ReadForm()
        {
            TryParseCost(out decimal cost);
            return new RepairOrder
            {
                Id = txtId.Text.Trim(),
                CustomerName = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                DeviceType = (string)cboDevice.SelectedItem!,
                Description = txtDescription.Text.Trim(),
                ReceivedDate = dtpReceived.Value.Date,
                EstimatedCost = cost,
                Status = (string)cboStatus.SelectedItem!,
                ImagePath = _currentImagePath ?? ""
            };
        }

        private void dgvOrders_SelectionChanged(object? sender, EventArgs e)
        {
            if (_loading) return;
            var item = GetSelected();
            if (item != null) LoadToForm(item);
        }

        // ------------------------------------------------------------------ kiểm tra dữ liệu

        /// <param name="editing">Đơn đang sửa (null khi thêm mới).</param>
        private bool ValidateInput(RepairOrder? editing)
        {
            errorProvider1.Clear();
            Control? firstBad = null;

            void Fail(Control c, string message)
            {
                errorProvider1.SetError(c, message);
                firstBad ??= c;
            }

            string id = txtId.Text.Trim();
            if (id.Length == 0)
                Fail(txtId, "Mã đơn không được để trống.");
            else if (_all.Any(o => !ReferenceEquals(o, editing)
                                   && string.Equals(o.Id, id, StringComparison.OrdinalIgnoreCase)))
                Fail(txtId, "Mã đơn đã tồn tại.");

            if (txtName.Text.Trim().Length == 0)
                Fail(txtName, "Vui lòng nhập tên khách hàng.");

            if (txtPhone.Text.Trim().Length == 0)
                Fail(txtPhone, "Vui lòng nhập số điện thoại.");

            if (cboDevice.SelectedIndex < 0)
                Fail(cboDevice, "Vui lòng chọn loại thiết bị.");

            if (txtDescription.Text.Trim().Length == 0)
                Fail(txtDescription, "Vui lòng nhập mô tả lỗi.");

            string costText = txtCost.Text.Trim();
            if (costText.Length == 0)
                Fail(txtCost, "Vui lòng nhập chi phí dự kiến (số không âm).");
            else if (!TryParseCost(out decimal cost))
                Fail(txtCost, "Chi phí dự kiến phải là một số.");
            else if (cost < 0)
                Fail(txtCost, "Chi phí dự kiến không được âm.");

            if (cboStatus.SelectedIndex < 0)
                Fail(cboStatus, "Vui lòng chọn trạng thái.");

            firstBad?.Focus();
            return firstBad == null;
        }

        private void Input_Changed(object? sender, EventArgs e)
        {
            if (_loading) return;
            if (sender is Control c) errorProvider1.SetError(c, "");
        }

        // ------------------------------------------------------------------ thêm / sửa / xóa

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(null)) return;

            var item = ReadForm();
            if (!Confirm($"Thêm đơn {item.Id} của khách hàng {item.CustomerName}?")) return;

            _all.Add(item);
            ApplyFilter(item.Id);

            if (!_view.Contains(item))
            {
                Info("Đã thêm đơn nhưng đơn này không nằm trong bộ lọc hiện tại.");
                ClearForm();
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null)
            {
                Info("Vui lòng chọn một đơn trong danh sách để cập nhật.");
                return;
            }

            if (!ValidateInput(selected)) return;
            if (!Confirm($"Cập nhật đơn {selected.Id}?")) return;

            var data = ReadForm();
            selected.Id = data.Id;
            selected.CustomerName = data.CustomerName;
            selected.Phone = data.Phone;
            selected.DeviceType = data.DeviceType;
            selected.Description = data.Description;
            selected.ReceivedDate = data.ReceivedDate;
            selected.EstimatedCost = data.EstimatedCost;
            selected.Status = data.Status;
            selected.ImagePath = data.ImagePath;

            ApplyFilter(selected.Id);

            if (_view.Contains(selected)) LoadToForm(selected);
            else ClearForm();
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null)
            {
                Info("Vui lòng chọn một đơn trong danh sách để xóa.");
                return;
            }

            if (!Confirm($"Xóa đơn {selected.Id} của khách hàng {selected.CustomerName}?")) return;

            _all.Remove(selected);
            ApplyFilter();
            ClearForm();
        }

        private void btnClear_Click(object? sender, EventArgs e) => ClearForm();

        // ------------------------------------------------------------------ menu

        private static string CsvEscape(string value)
        {
            if (value.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0)
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        private void mnuExportCsv_Click(object? sender, EventArgs e)
        {
            if (_view.Count == 0)
            {
                Info("Không có đơn nào để xuất.");
                return;
            }

            saveFileDialog1.FileName = $"DonSuaChua_{DateTime.Now:yyyyMMdd_HHmm}.csv";
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Mã đơn,Tên khách hàng,Số điện thoại,Loại thiết bị,Mô tả lỗi,Ngày tiếp nhận,Chi phí dự kiến,Trạng thái");
                foreach (var o in _view)
                {
                    sb.AppendLine(string.Join(",",
                        CsvEscape(o.Id),
                        CsvEscape(o.CustomerName),
                        CsvEscape(o.Phone),
                        CsvEscape(o.DeviceType),
                        CsvEscape(o.Description),
                        o.ReceivedDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                        o.EstimatedCost.ToString("0.##", CultureInfo.InvariantCulture),
                        CsvEscape(o.Status)));
                }

                // UTF-8 có BOM để Excel đọc đúng tiếng Việt
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), new UTF8Encoding(true));
                Info($"Đã xuất {_view.Count} đơn.");
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(this, "Không thể ghi file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuExit_Click(object? sender, EventArgs e) => Close();
    }
}
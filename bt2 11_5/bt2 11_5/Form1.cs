using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace bt2_11_5
{
    public partial class Form1 : Form
    {
        private const string AllStatuses = "Tất cả";

        private static readonly string[] Equipments =
        {
            "Đồng hồ vạn năng (Multimeter)",
            "Máy hiện sóng (Oscilloscope)",
            "Kit Arduino Uno",
            "Kit Raspberry Pi 4",
            "Bộ nguồn DC",
            "Laptop thực hành",
            "Máy hàn thiếc",
            "Bộ dụng cụ bấm cáp mạng"
        };

        private readonly BindingList<BorrowSlip> _all = new();   // toàn bộ phiếu
        private readonly BindingList<BorrowSlip> _view = new();  // phiếu sau khi lọc (nguồn của BindingSource)
        private bool _loading;                                   // chặn SelectionChanged/Input_Changed khi nạp bằng code

        public Form1()
        {
            InitializeComponent();
            SetupControls();
        }

        // ------------------------------------------------------------------ khởi tạo

        private void SetupControls()
        {
            cboEquipment.Items.AddRange(Equipments);

            cboFilterStatus.Items.Add(AllStatuses);
            cboFilterStatus.Items.AddRange(BorrowSlip.Statuses);
            cboFilterStatus.SelectedIndex = 0;

            bindingSource1.DataSource = _view;
            dgvSlips.DataSource = bindingSource1;

            SeedData();
            ApplyFilter();
            ClearForm();
        }

        private void SeedData()
        {
            DateTime t = DateTime.Today;
            _all.Add(new BorrowSlip { Id = "PM001", StudentId = "SV2021001", StudentName = "Nguyễn Văn Hùng", Equipment = Equipments[0], Quantity = 1, BorrowDate = t.AddDays(-10), DueDate = t.AddDays(-3) });
            _all.Add(new BorrowSlip { Id = "PM002", StudentId = "SV2021002", StudentName = "Trần Thị Mai", Equipment = Equipments[2], Quantity = 2, BorrowDate = t.AddDays(-5), DueDate = t.AddDays(2) });
            _all.Add(new BorrowSlip { Id = "PM003", StudentId = "SV2021003", StudentName = "Lê Quốc Bảo", Equipment = Equipments[1], Quantity = 1, BorrowDate = t.AddDays(-8), DueDate = t.AddDays(-1) });
            _all.Add(new BorrowSlip { Id = "PM004", StudentId = "SV2021004", StudentName = "Phạm Thu Hà", Equipment = Equipments[3], Quantity = 1, BorrowDate = t.AddDays(-12), DueDate = t.AddDays(-5), ReturnDate = t.AddDays(-6) });
            _all.Add(new BorrowSlip { Id = "PM005", StudentId = "SV2021005", StudentName = "Đỗ Minh Khôi", Equipment = Equipments[5], Quantity = 1, BorrowDate = t, DueDate = t.AddDays(7) });
            _all.Add(new BorrowSlip { Id = "PM006", StudentId = "SV2021006", StudentName = "Vũ Ngọc Lan", Equipment = Equipments[4], Quantity = 3, BorrowDate = t.AddDays(-3), DueDate = t });
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

        private BorrowSlip? GetSelected() =>
            dgvSlips.SelectedRows.Count > 0
                ? dgvSlips.SelectedRows[0].DataBoundItem as BorrowSlip
                : null;

        private void DeselectAll()
        {
            dgvSlips.ClearSelection();
            dgvSlips.CurrentCell = null;
        }

        private bool SelectById(string id)
        {
            foreach (DataGridViewRow row in dgvSlips.Rows)
            {
                if (row.DataBoundItem is BorrowSlip s && s.Id == id)
                {
                    dgvSlips.CurrentCell = row.Cells[0];
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
            foreach (var s in _all)
            {
                var m = Regex.Match(s.Id, @"^PM(\d+)$", RegexOptions.IgnoreCase);
                if (m.Success && int.TryParse(m.Groups[1].Value, out int n) && n > max) max = n;
            }
            return $"PM{max + 1:000}";
        }

        // ------------------------------------------------------------------ tìm kiếm / lọc

        private void ApplyFilter(string? keepId = null)
        {
            keepId ??= GetSelected()?.Id;

            string text = txtSearch.Text.Trim();
            string keyword = RemoveDiacritics(text);
            string status = cboFilterStatus.SelectedItem as string ?? AllStatuses;

            var result = _all.Where(s =>
                    (text.Length == 0
                        || s.StudentId.Contains(text, StringComparison.OrdinalIgnoreCase)
                        || RemoveDiacritics(s.Equipment).Contains(keyword))
                    && (status == AllStatuses || s.Status == status))
                .OrderByDescending(s => s.BorrowDate)
                .ThenBy(s => s.Id)
                .ToList();

            _loading = true;
            try
            {
                _view.RaiseListChangedEvents = false;
                _view.Clear();
                foreach (var s in result) _view.Add(s);
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
            int overdue = _all.Count(s => s.IsOverdue);
            lblSummary.Text = $"Tổng số phiếu: {_all.Count}   |   Quá hạn: {overdue}   |   Đang hiển thị: {_view.Count}";
        }

        private void Filter_Changed(object? sender, EventArgs e) => ApplyFilter();

        private void btnResetFilter_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterStatus.SelectedIndex = 0;
            ApplyFilter();
        }

        // ------------------------------------------------------------------ form <-> dữ liệu

        private void UpdateStatusPreview()
        {
            DateTime? returned = dtpReturn.Checked ? dtpReturn.Value.Date : (DateTime?)null;
            txtStatus.Text = BorrowSlip.ComputeStatus(returned, dtpDue.Value.Date);
        }

        private void LoadToForm(BorrowSlip s)
        {
            _loading = true;
            try
            {
                txtId.Text = s.Id;
                txtStudentId.Text = s.StudentId;
                txtStudentName.Text = s.StudentName;
                cboEquipment.SelectedIndex = cboEquipment.Items.IndexOf(s.Equipment);
                nudQty.Value = Math.Clamp(s.Quantity, (int)nudQty.Minimum, (int)nudQty.Maximum);
                dtpBorrow.Value = s.BorrowDate;
                dtpDue.Value = s.DueDate;

                // Gán Value trước rồi mới đặt Checked (gán Value sẽ tự bật Checked)
                dtpReturn.Value = s.ReturnDate ?? DateTime.Today;
                dtpReturn.Checked = s.ReturnDate.HasValue;

                errorProvider1.Clear();
                UpdateStatusPreview();
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
                txtStudentId.Clear();
                txtStudentName.Clear();
                cboEquipment.SelectedIndex = -1;
                nudQty.Value = 1;
                dtpBorrow.Value = DateTime.Today;
                dtpDue.Value = DateTime.Today.AddDays(7);
                dtpReturn.Value = DateTime.Today;
                dtpReturn.Checked = false;
                errorProvider1.Clear();
                DeselectAll();
                UpdateStatusPreview();
            }
            finally
            {
                _loading = false;
            }
        }

        private BorrowSlip ReadForm() => new()
        {
            Id = txtId.Text.Trim(),
            StudentId = txtStudentId.Text.Trim(),
            StudentName = txtStudentName.Text.Trim(),
            Equipment = (string)cboEquipment.SelectedItem!,
            Quantity = (int)nudQty.Value,
            BorrowDate = dtpBorrow.Value.Date,
            DueDate = dtpDue.Value.Date,
            ReturnDate = dtpReturn.Checked ? dtpReturn.Value.Date : (DateTime?)null
        };

        private void dgvSlips_SelectionChanged(object? sender, EventArgs e)
        {
            if (_loading) return;
            var item = GetSelected();
            if (item != null) LoadToForm(item);
        }

        private void dgvSlips_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvSlips.Rows[e.RowIndex].DataBoundItem is not BorrowSlip s) return;

            if (s.IsOverdue)
            {
                e.CellStyle.BackColor = Color.MistyRose;
                e.CellStyle.ForeColor = Color.DarkRed;
            }
            else if (s.ReturnDate.HasValue)
            {
                e.CellStyle.ForeColor = Color.DimGray;
            }
        }

        // ------------------------------------------------------------------ kiểm tra dữ liệu

        /// <param name="editing">Phiếu đang sửa (null khi thêm mới).</param>
        private bool ValidateInput(BorrowSlip? editing)
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
                Fail(txtId, "Mã phiếu không được để trống.");
            else if (_all.Any(s => !ReferenceEquals(s, editing)
                                   && string.Equals(s.Id, id, StringComparison.OrdinalIgnoreCase)))
                Fail(txtId, "Mã phiếu đã tồn tại.");

            if (txtStudentId.Text.Trim().Length == 0)
                Fail(txtStudentId, "Mã sinh viên không được để trống.");

            if (txtStudentName.Text.Trim().Length == 0)
                Fail(txtStudentName, "Vui lòng nhập họ tên sinh viên.");

            if (cboEquipment.SelectedIndex < 0)
                Fail(cboEquipment, "Vui lòng chọn thiết bị.");

            if (nudQty.Value <= 0)
                Fail(nudQty, "Số lượng phải lớn hơn 0.");

            DateTime borrow = dtpBorrow.Value.Date;
            if (dtpDue.Value.Date < borrow)
                Fail(dtpDue, "Hạn trả không được trước ngày mượn.");

            if (dtpReturn.Checked && dtpReturn.Value.Date < borrow)
                Fail(dtpReturn, "Ngày trả thực tế không được trước ngày mượn.");

            firstBad?.Focus();
            return firstBad == null;
        }

        private void Input_Changed(object? sender, EventArgs e)
        {
            if (_loading) return;
            if (sender is Control c) errorProvider1.SetError(c, "");
            UpdateStatusPreview();
        }

        // ------------------------------------------------------------------ thêm / sửa / xóa / trả

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(null)) return;

            var item = ReadForm();
            if (!Confirm($"Thêm phiếu {item.Id}: {item.StudentId} mượn {item.Quantity} × {item.Equipment}?")) return;

            _all.Add(item);
            ApplyFilter(item.Id);

            if (!_view.Contains(item))
            {
                Info("Đã thêm phiếu nhưng phiếu này không nằm trong bộ lọc hiện tại.");
                ClearForm();
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null)
            {
                Info("Vui lòng chọn một phiếu trong danh sách để cập nhật.");
                return;
            }

            if (!ValidateInput(selected)) return;
            if (!Confirm($"Cập nhật phiếu {selected.Id}?")) return;

            var data = ReadForm();
            selected.Id = data.Id;
            selected.StudentId = data.StudentId;
            selected.StudentName = data.StudentName;
            selected.Equipment = data.Equipment;
            selected.Quantity = data.Quantity;
            selected.BorrowDate = data.BorrowDate;
            selected.DueDate = data.DueDate;
            selected.ReturnDate = data.ReturnDate;

            ApplyFilter(selected.Id);

            if (_view.Contains(selected)) LoadToForm(selected);
            else ClearForm();
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null)
            {
                Info("Vui lòng chọn một phiếu trong danh sách để xóa.");
                return;
            }

            if (!Confirm($"Xóa phiếu {selected.Id} của sinh viên {selected.StudentId}?")) return;

            _all.Remove(selected);
            ApplyFilter();
            ClearForm();
        }

        /// <summary>Đánh dấu đã trả: dùng ngày đang chọn ở ô "Ngày trả thực tế" nếu đã tick, ngược lại dùng hôm nay.</summary>
        private void btnReturn_Click(object? sender, EventArgs e)
        {
            var selected = GetSelected();
            if (selected == null)
            {
                Info("Vui lòng chọn một phiếu trong danh sách để đánh dấu đã trả.");
                return;
            }

            if (selected.ReturnDate.HasValue)
            {
                Info($"Phiếu {selected.Id} đã được trả ngày {selected.ReturnDate:dd/MM/yyyy}.");
                return;
            }

            errorProvider1.SetError(dtpReturn, "");
            DateTime returnDate = dtpReturn.Checked ? dtpReturn.Value.Date : DateTime.Today;

            if (returnDate < selected.BorrowDate.Date)
            {
                errorProvider1.SetError(dtpReturn, "Ngày trả thực tế không được trước ngày mượn.");
                dtpReturn.Focus();
                return;
            }

            if (!Confirm($"Đánh dấu phiếu {selected.Id} đã trả ngày {returnDate:dd/MM/yyyy}?")) return;

            selected.ReturnDate = returnDate;
            ApplyFilter(selected.Id);

            if (_view.Contains(selected)) LoadToForm(selected);
            else ClearForm();
        }

        private void btnClear_Click(object? sender, EventArgs e) => ClearForm();

        // ------------------------------------------------------------------ menu

        private static string CsvEscape(string value)
        {
            if (value.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0)
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        private static string Date(DateTime? d) =>
            d.HasValue ? d.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) : "";

        private void mnuExportCsv_Click(object? sender, EventArgs e)
        {
            if (_view.Count == 0)
            {
                Info("Không có phiếu nào để xuất.");
                return;
            }

            saveFileDialog1.FileName = $"PhieuMuon_{DateTime.Now:yyyyMMdd_HHmm}.csv";
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Mã phiếu,Mã sinh viên,Họ tên sinh viên,Thiết bị,Số lượng,Ngày mượn,Hạn trả,Ngày trả thực tế,Tình trạng");
                foreach (var s in _view)
                {
                    sb.AppendLine(string.Join(",",
                        CsvEscape(s.Id),
                        CsvEscape(s.StudentId),
                        CsvEscape(s.StudentName),
                        CsvEscape(s.Equipment),
                        s.Quantity.ToString(CultureInfo.InvariantCulture),
                        Date(s.BorrowDate),
                        Date(s.DueDate),
                        Date(s.ReturnDate),
                        CsvEscape(s.Status)));
                }

                // UTF-8 có BOM để Excel đọc đúng tiếng Việt
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), new UTF8Encoding(true));
                Info($"Đã xuất {_view.Count} phiếu.");
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
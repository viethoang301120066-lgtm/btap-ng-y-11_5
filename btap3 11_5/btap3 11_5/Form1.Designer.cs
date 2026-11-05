#nullable disable
using System.Drawing;
using System.Windows.Forms;

namespace btap3_11_5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle styleDate = new DataGridViewCellStyle();
            DataGridViewCellStyle styleCost = new DataGridViewCellStyle();

            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuExportCsv = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblCount = new ToolStripStatusLabel();
            lblTotal = new ToolStripStatusLabel();
            tlpMain = new TableLayoutPanel();
            grpInput = new GroupBox();
            tlpInput = new TableLayoutPanel();
            lblId = new Label();
            txtId = new TextBox();
            lblName = new Label();
            txtName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblDevice = new Label();
            cboDevice = new ComboBox();
            lblReceived = new Label();
            dtpReceived = new DateTimePicker();
            lblCost = new Label();
            txtCost = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            tlpImage = new TableLayoutPanel();
            pbDevice = new PictureBox();
            lblImageName = new Label();
            flpImageButtons = new FlowLayoutPanel();
            btnChooseImage = new Button();
            btnRemoveImage = new Button();
            flpButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            grpFilter = new GroupBox();
            tlpFilter = new TableLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblFilterStatus = new Label();
            cboFilterStatus = new ComboBox();
            btnResetFilter = new Button();
            dgvOrders = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colDevice = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colReceived = new DataGridViewTextBoxColumn();
            colCost = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();

            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tlpMain.SuspendLayout();
            grpInput.SuspendLayout();
            tlpInput.SuspendLayout();
            tlpImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbDevice).BeginInit();
            flpImageButtons.SuspendLayout();
            flpButtons.SuspendLayout();
            grpFilter.SuspendLayout();
            tlpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1150, 24);
            menuStrip1.TabIndex = 0;

            // mnuFile
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuExportCsv, mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Text = "&Tệp";

            // mnuExportCsv
            mnuExportCsv.Name = "mnuExportCsv";
            mnuExportCsv.ShortcutKeys = Keys.Control | Keys.E;
            mnuExportCsv.Text = "Xuất danh sách đang hiển thị ra &CSV...";
            mnuExportCsv.Click += new System.EventHandler(mnuExportCsv_Click);

            // mnuExit
            mnuExit.Name = "mnuExit";
            mnuExit.Text = "&Thoát";
            mnuExit.Click += new System.EventHandler(mnuExit_Click);

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblCount, lblTotal });
            statusStrip1.Name = "statusStrip1";
            statusStrip1.TabIndex = 2;

            // lblCount
            lblCount.Name = "lblCount";
            lblCount.Text = "Số đơn hiển thị: 0";

            // lblTotal
            lblTotal.Name = "lblTotal";
            lblTotal.Text = "Tổng chi phí dự kiến (đơn chưa hoàn tất): 0";

            // tlpMain
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(grpInput, 0, 0);
            tlpMain.Controls.Add(grpFilter, 0, 1);
            tlpMain.Controls.Add(dgvOrders, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(8);
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.TabIndex = 1;

            // grpInput
            grpInput.AutoSize = true;
            grpInput.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpInput.Controls.Add(tlpInput);
            grpInput.Dock = DockStyle.Fill;
            grpInput.Name = "grpInput";
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin đơn sửa chữa";

            // tlpInput
            tlpInput.AutoSize = true;
            tlpInput.ColumnCount = 5;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
            tlpInput.Controls.Add(lblId, 0, 0);
            tlpInput.Controls.Add(txtId, 1, 0);
            tlpInput.Controls.Add(lblName, 2, 0);
            tlpInput.Controls.Add(txtName, 3, 0);
            tlpInput.Controls.Add(lblPhone, 0, 1);
            tlpInput.Controls.Add(txtPhone, 1, 1);
            tlpInput.Controls.Add(lblDevice, 2, 1);
            tlpInput.Controls.Add(cboDevice, 3, 1);
            tlpInput.Controls.Add(lblReceived, 0, 2);
            tlpInput.Controls.Add(dtpReceived, 1, 2);
            tlpInput.Controls.Add(lblCost, 2, 2);
            tlpInput.Controls.Add(txtCost, 3, 2);
            tlpInput.Controls.Add(lblStatus, 0, 3);
            tlpInput.Controls.Add(cboStatus, 1, 3);
            tlpInput.Controls.Add(lblDescription, 0, 4);
            tlpInput.Controls.Add(txtDescription, 1, 4);
            tlpInput.Controls.Add(tlpImage, 4, 0);
            tlpInput.Controls.Add(flpButtons, 0, 5);
            tlpInput.SetColumnSpan(txtDescription, 3);
            tlpInput.SetRowSpan(tlpImage, 5);
            tlpInput.SetColumnSpan(flpButtons, 5);
            tlpInput.Dock = DockStyle.Top;
            tlpInput.Name = "tlpInput";
            tlpInput.Padding = new Padding(6);
            tlpInput.RowCount = 6;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpInput.TabIndex = 0;

            // lblId
            lblId.Anchor = AnchorStyles.Left;
            lblId.AutoSize = true;
            lblId.Margin = new Padding(3, 0, 12, 0);
            lblId.Name = "lblId";
            lblId.Text = "Mã đơn:";

            // txtId
            txtId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtId.Margin = new Padding(3, 6, 12, 6);
            txtId.Name = "txtId";
            txtId.TabIndex = 0;
            txtId.TextChanged += new System.EventHandler(Input_Changed);

            // lblName
            lblName.Anchor = AnchorStyles.Left;
            lblName.AutoSize = true;
            lblName.Margin = new Padding(3, 0, 12, 0);
            lblName.Name = "lblName";
            lblName.Text = "Tên khách hàng:";

            // txtName
            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Margin = new Padding(3, 6, 12, 6);
            txtName.Name = "txtName";
            txtName.TabIndex = 1;
            txtName.TextChanged += new System.EventHandler(Input_Changed);

            // lblPhone
            lblPhone.Anchor = AnchorStyles.Left;
            lblPhone.AutoSize = true;
            lblPhone.Margin = new Padding(3, 0, 12, 0);
            lblPhone.Name = "lblPhone";
            lblPhone.Text = "Số điện thoại:";

            // txtPhone
            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Margin = new Padding(3, 6, 12, 6);
            txtPhone.Name = "txtPhone";
            txtPhone.TabIndex = 2;
            txtPhone.TextChanged += new System.EventHandler(Input_Changed);

            // lblDevice
            lblDevice.Anchor = AnchorStyles.Left;
            lblDevice.AutoSize = true;
            lblDevice.Margin = new Padding(3, 0, 12, 0);
            lblDevice.Name = "lblDevice";
            lblDevice.Text = "Loại thiết bị:";

            // cboDevice
            cboDevice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboDevice.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDevice.Margin = new Padding(3, 6, 12, 6);
            cboDevice.Name = "cboDevice";
            cboDevice.TabIndex = 3;
            cboDevice.SelectedIndexChanged += new System.EventHandler(Input_Changed);

            // lblReceived
            lblReceived.Anchor = AnchorStyles.Left;
            lblReceived.AutoSize = true;
            lblReceived.Margin = new Padding(3, 0, 12, 0);
            lblReceived.Name = "lblReceived";
            lblReceived.Text = "Ngày tiếp nhận:";

            // dtpReceived
            dtpReceived.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpReceived.Format = DateTimePickerFormat.Short;
            dtpReceived.Margin = new Padding(3, 6, 12, 6);
            dtpReceived.Name = "dtpReceived";
            dtpReceived.TabIndex = 4;
            dtpReceived.ValueChanged += new System.EventHandler(Input_Changed);

            // lblCost
            lblCost.Anchor = AnchorStyles.Left;
            lblCost.AutoSize = true;
            lblCost.Margin = new Padding(3, 0, 12, 0);
            lblCost.Name = "lblCost";
            lblCost.Text = "Chi phí dự kiến:";

            // txtCost
            txtCost.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCost.Margin = new Padding(3, 6, 12, 6);
            txtCost.Name = "txtCost";
            txtCost.TabIndex = 5;
            txtCost.TextAlign = HorizontalAlignment.Right;
            txtCost.TextChanged += new System.EventHandler(Input_Changed);

            // lblStatus
            lblStatus.Anchor = AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Margin = new Padding(3, 0, 12, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Trạng thái:";

            // cboStatus
            cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Margin = new Padding(3, 6, 12, 6);
            cboStatus.Name = "cboStatus";
            cboStatus.TabIndex = 6;
            cboStatus.SelectedIndexChanged += new System.EventHandler(Input_Changed);

            // lblDescription
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblDescription.AutoSize = true;
            lblDescription.Margin = new Padding(3, 9, 12, 0);
            lblDescription.Name = "lblDescription";
            lblDescription.Text = "Mô tả lỗi:";

            // txtDescription
            txtDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Margin = new Padding(3, 6, 12, 6);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(300, 60);
            txtDescription.TabIndex = 7;
            txtDescription.TextChanged += new System.EventHandler(Input_Changed);

            // tlpImage
            tlpImage.ColumnCount = 1;
            tlpImage.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpImage.Controls.Add(pbDevice, 0, 0);
            tlpImage.Controls.Add(lblImageName, 0, 1);
            tlpImage.Controls.Add(flpImageButtons, 0, 2);
            tlpImage.Dock = DockStyle.Fill;
            tlpImage.MinimumSize = new Size(220, 210);
            tlpImage.Name = "tlpImage";
            tlpImage.RowCount = 3;
            tlpImage.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpImage.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpImage.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpImage.TabIndex = 8;

            // pbDevice
            pbDevice.BorderStyle = BorderStyle.FixedSingle;
            pbDevice.Dock = DockStyle.Fill;
            pbDevice.Name = "pbDevice";
            pbDevice.SizeMode = PictureBoxSizeMode.Zoom;
            pbDevice.TabStop = false;

            // lblImageName
            lblImageName.AutoEllipsis = true;
            lblImageName.Dock = DockStyle.Fill;
            lblImageName.Name = "lblImageName";
            lblImageName.Size = new Size(100, 20);
            lblImageName.Text = "Chưa chọn ảnh";
            lblImageName.TextAlign = ContentAlignment.MiddleCenter;

            // flpImageButtons
            flpImageButtons.AutoSize = true;
            flpImageButtons.Controls.Add(btnChooseImage);
            flpImageButtons.Controls.Add(btnRemoveImage);
            flpImageButtons.Dock = DockStyle.Fill;
            flpImageButtons.Name = "flpImageButtons";
            flpImageButtons.TabIndex = 2;

            // btnChooseImage
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(110, 30);
            btnChooseImage.TabIndex = 0;
            btnChooseImage.Text = "Chọn ảnh...";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += new System.EventHandler(btnChooseImage_Click);

            // btnRemoveImage
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(90, 30);
            btnRemoveImage.TabIndex = 1;
            btnRemoveImage.Text = "Xóa ảnh";
            btnRemoveImage.UseVisualStyleBackColor = true;
            btnRemoveImage.Click += new System.EventHandler(btnRemoveImage_Click);

            // flpButtons
            flpButtons.AutoSize = true;
            flpButtons.Controls.Add(btnAdd);
            flpButtons.Controls.Add(btnUpdate);
            flpButtons.Controls.Add(btnDelete);
            flpButtons.Controls.Add(btnClear);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Name = "flpButtons";
            flpButtons.TabIndex = 9;

            // btnAdd
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 32);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += new System.EventHandler(btnAdd_Click);

            // btnUpdate
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 32);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += new System.EventHandler(btnUpdate_Click);

            // btnDelete
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 32);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += new System.EventHandler(btnDelete_Click);

            // btnClear
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 32);
            btnClear.TabIndex = 3;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += new System.EventHandler(btnClear_Click);

            // grpFilter
            grpFilter.AutoSize = true;
            grpFilter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grpFilter.Controls.Add(tlpFilter);
            grpFilter.Dock = DockStyle.Fill;
            grpFilter.Name = "grpFilter";
            grpFilter.TabStop = false;
            grpFilter.Text = "Tìm kiếm và lọc";

            // tlpFilter
            tlpFilter.AutoSize = true;
            tlpFilter.ColumnCount = 5;
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpFilter.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpFilter.Controls.Add(lblSearch, 0, 0);
            tlpFilter.Controls.Add(txtSearch, 1, 0);
            tlpFilter.Controls.Add(lblFilterStatus, 2, 0);
            tlpFilter.Controls.Add(cboFilterStatus, 3, 0);
            tlpFilter.Controls.Add(btnResetFilter, 4, 0);
            tlpFilter.Dock = DockStyle.Top;
            tlpFilter.Name = "tlpFilter";
            tlpFilter.Padding = new Padding(6);
            tlpFilter.RowCount = 1;
            tlpFilter.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlpFilter.TabIndex = 0;

            // lblSearch
            lblSearch.Anchor = AnchorStyles.Left;
            lblSearch.AutoSize = true;
            lblSearch.Margin = new Padding(3, 0, 6, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Text = "Tìm (mã đơn / tên / SĐT):";

            // txtSearch
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Margin = new Padding(3, 6, 12, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += new System.EventHandler(Filter_Changed);

            // lblFilterStatus
            lblFilterStatus.Anchor = AnchorStyles.Left;
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Margin = new Padding(3, 0, 6, 0);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Text = "Trạng thái:";

            // cboFilterStatus
            cboFilterStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterStatus.Margin = new Padding(3, 6, 12, 6);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.TabIndex = 1;
            cboFilterStatus.SelectedIndexChanged += new System.EventHandler(Filter_Changed);

            // btnResetFilter
            btnResetFilter.Anchor = AnchorStyles.Left;
            btnResetFilter.AutoSize = true;
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.TabIndex = 2;
            btnResetFilter.Text = "Xóa bộ lọc";
            btnResetFilter.UseVisualStyleBackColor = true;
            btnResetFilter.Click += new System.EventHandler(btnResetFilter_Click);

            // dgvOrders
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AllowUserToResizeRows = false;
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = SystemColors.Window;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPhone, colDevice, colDescription, colReceived, colCost, colStatus });
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.TabIndex = 2;
            dgvOrders.SelectionChanged += new System.EventHandler(dgvOrders_SelectionChanged);

            // colId
            colId.DataPropertyName = "Id";
            colId.FillWeight = 60F;
            colId.HeaderText = "Mã đơn";
            colId.Name = "colId";
            colId.ReadOnly = true;

            // colName
            colName.DataPropertyName = "CustomerName";
            colName.FillWeight = 120F;
            colName.HeaderText = "Tên khách hàng";
            colName.Name = "colName";
            colName.ReadOnly = true;

            // colPhone
            colPhone.DataPropertyName = "Phone";
            colPhone.FillWeight = 85F;
            colPhone.HeaderText = "Số điện thoại";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;

            // colDevice
            colDevice.DataPropertyName = "DeviceType";
            colDevice.FillWeight = 90F;
            colDevice.HeaderText = "Loại thiết bị";
            colDevice.Name = "colDevice";
            colDevice.ReadOnly = true;

            // colDescription
            colDescription.DataPropertyName = "Description";
            colDescription.FillWeight = 170F;
            colDescription.HeaderText = "Mô tả lỗi";
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;

            // colReceived
            styleDate.Format = "dd/MM/yyyy";
            colReceived.DataPropertyName = "ReceivedDate";
            colReceived.DefaultCellStyle = styleDate;
            colReceived.FillWeight = 85F;
            colReceived.HeaderText = "Ngày tiếp nhận";
            colReceived.Name = "colReceived";
            colReceived.ReadOnly = true;

            // colCost
            styleCost.Alignment = DataGridViewContentAlignment.MiddleRight;
            styleCost.Format = "N0";
            colCost.DataPropertyName = "EstimatedCost";
            colCost.DefaultCellStyle = styleCost;
            colCost.FillWeight = 90F;
            colCost.HeaderText = "Chi phí dự kiến";
            colCost.Name = "colCost";
            colCost.ReadOnly = true;

            // colStatus
            colStatus.DataPropertyName = "Status";
            colStatus.FillWeight = 90F;
            colStatus.HeaderText = "Trạng thái";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;

            // errorProvider1
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;

            // saveFileDialog1
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "CSV (*.csv)|*.csv";
            saveFileDialog1.Title = "Xuất danh sách đơn sửa chữa";

            // openFileDialog1
            openFileDialog1.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả các file (*.*)|*.*";
            openFileDialog1.Title = "Chọn ảnh thiết bị";

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 720);
            Controls.Add(tlpMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(980, 640);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Repair Service Tracker";

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            grpInput.ResumeLayout(false);
            grpInput.PerformLayout();
            tlpInput.ResumeLayout(false);
            tlpInput.PerformLayout();
            tlpImage.ResumeLayout(false);
            tlpImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbDevice).EndInit();
            flpImageButtons.ResumeLayout(false);
            flpButtons.ResumeLayout(false);
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            tlpFilter.ResumeLayout(false);
            tlpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuExportCsv;
        private ToolStripMenuItem mnuExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblCount;
        private ToolStripStatusLabel lblTotal;
        private TableLayoutPanel tlpMain;
        private GroupBox grpInput;
        private TableLayoutPanel tlpInput;
        private Label lblId;
        private TextBox txtId;
        private Label lblName;
        private TextBox txtName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblDevice;
        private ComboBox cboDevice;
        private Label lblReceived;
        private DateTimePicker dtpReceived;
        private Label lblCost;
        private TextBox txtCost;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblDescription;
        private TextBox txtDescription;
        private TableLayoutPanel tlpImage;
        private PictureBox pbDevice;
        private Label lblImageName;
        private FlowLayoutPanel flpImageButtons;
        private Button btnChooseImage;
        private Button btnRemoveImage;
        private FlowLayoutPanel flpButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpFilter;
        private TableLayoutPanel tlpFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblFilterStatus;
        private ComboBox cboFilterStatus;
        private Button btnResetFilter;
        private DataGridView dgvOrders;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colDevice;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colReceived;
        private DataGridViewTextBoxColumn colCost;
        private DataGridViewTextBoxColumn colStatus;
        private BindingSource bindingSource1;
        private ErrorProvider errorProvider1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
    }
}
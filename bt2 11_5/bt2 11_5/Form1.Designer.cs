#nullable disable
using System.Drawing;
using System.Windows.Forms;

namespace bt2_11_5
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
            DataGridViewCellStyle styleBorrow = new DataGridViewCellStyle();
            DataGridViewCellStyle styleDue = new DataGridViewCellStyle();
            DataGridViewCellStyle styleReturn = new DataGridViewCellStyle();

            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuExportCsv = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblSummary = new ToolStripStatusLabel();
            tlpMain = new TableLayoutPanel();
            grpInput = new GroupBox();
            tlpInput = new TableLayoutPanel();
            lblId = new Label();
            txtId = new TextBox();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblStudentName = new Label();
            txtStudentName = new TextBox();
            lblEquipment = new Label();
            cboEquipment = new ComboBox();
            lblQty = new Label();
            nudQty = new NumericUpDown();
            lblBorrow = new Label();
            dtpBorrow = new DateTimePicker();
            lblDue = new Label();
            dtpDue = new DateTimePicker();
            lblReturn = new Label();
            dtpReturn = new DateTimePicker();
            lblStatus = new Label();
            txtStatus = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnReturn = new Button();
            btnClear = new Button();
            grpFilter = new GroupBox();
            tlpFilter = new TableLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblFilterStatus = new Label();
            cboFilterStatus = new ComboBox();
            btnResetFilter = new Button();
            dgvSlips = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colStudentId = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colEquipment = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colBorrow = new DataGridViewTextBoxColumn();
            colDue = new DataGridViewTextBoxColumn();
            colReturn = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            saveFileDialog1 = new SaveFileDialog();

            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tlpMain.SuspendLayout();
            grpInput.SuspendLayout();
            tlpInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQty).BeginInit();
            flpButtons.SuspendLayout();
            grpFilter.SuspendLayout();
            tlpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSlips).BeginInit();
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
            mnuExportCsv.Text = "Xuất danh sách đang lọc ra &CSV...";
            mnuExportCsv.Click += new System.EventHandler(mnuExportCsv_Click);

            // mnuExit
            mnuExit.Name = "mnuExit";
            mnuExit.Text = "&Thoát";
            mnuExit.Click += new System.EventHandler(mnuExit_Click);

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblSummary });
            statusStrip1.Name = "statusStrip1";
            statusStrip1.TabIndex = 2;

            // lblSummary
            lblSummary.Name = "lblSummary";
            lblSummary.Text = "Tổng số phiếu: 0";

            // tlpMain
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(grpInput, 0, 0);
            tlpMain.Controls.Add(grpFilter, 0, 1);
            tlpMain.Controls.Add(dgvSlips, 0, 2);
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
            grpInput.Text = "Thông tin phiếu mượn";

            // tlpInput
            tlpInput.AutoSize = true;
            tlpInput.ColumnCount = 4;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.Controls.Add(lblId, 0, 0);
            tlpInput.Controls.Add(txtId, 1, 0);
            tlpInput.Controls.Add(lblStudentId, 2, 0);
            tlpInput.Controls.Add(txtStudentId, 3, 0);
            tlpInput.Controls.Add(lblStudentName, 0, 1);
            tlpInput.Controls.Add(txtStudentName, 1, 1);
            tlpInput.Controls.Add(lblEquipment, 2, 1);
            tlpInput.Controls.Add(cboEquipment, 3, 1);
            tlpInput.Controls.Add(lblQty, 0, 2);
            tlpInput.Controls.Add(nudQty, 1, 2);
            tlpInput.Controls.Add(lblBorrow, 2, 2);
            tlpInput.Controls.Add(dtpBorrow, 3, 2);
            tlpInput.Controls.Add(lblDue, 0, 3);
            tlpInput.Controls.Add(dtpDue, 1, 3);
            tlpInput.Controls.Add(lblReturn, 2, 3);
            tlpInput.Controls.Add(dtpReturn, 3, 3);
            tlpInput.Controls.Add(lblStatus, 0, 4);
            tlpInput.Controls.Add(txtStatus, 1, 4);
            tlpInput.Controls.Add(flpButtons, 0, 5);
            tlpInput.SetColumnSpan(flpButtons, 4);
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
            lblId.Text = "Mã phiếu:";

            // txtId
            txtId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtId.Margin = new Padding(3, 6, 12, 6);
            txtId.Name = "txtId";
            txtId.TabIndex = 0;
            txtId.TextChanged += new System.EventHandler(Input_Changed);

            // lblStudentId
            lblStudentId.Anchor = AnchorStyles.Left;
            lblStudentId.AutoSize = true;
            lblStudentId.Margin = new Padding(3, 0, 12, 0);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Text = "Mã sinh viên:";

            // txtStudentId
            txtStudentId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStudentId.Margin = new Padding(3, 6, 3, 6);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.TabIndex = 1;
            txtStudentId.TextChanged += new System.EventHandler(Input_Changed);

            // lblStudentName
            lblStudentName.Anchor = AnchorStyles.Left;
            lblStudentName.AutoSize = true;
            lblStudentName.Margin = new Padding(3, 0, 12, 0);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Text = "Họ tên sinh viên:";

            // txtStudentName
            txtStudentName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStudentName.Margin = new Padding(3, 6, 12, 6);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.TabIndex = 2;
            txtStudentName.TextChanged += new System.EventHandler(Input_Changed);

            // lblEquipment
            lblEquipment.Anchor = AnchorStyles.Left;
            lblEquipment.AutoSize = true;
            lblEquipment.Margin = new Padding(3, 0, 12, 0);
            lblEquipment.Name = "lblEquipment";
            lblEquipment.Text = "Thiết bị:";

            // cboEquipment
            cboEquipment.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEquipment.Margin = new Padding(3, 6, 3, 6);
            cboEquipment.Name = "cboEquipment";
            cboEquipment.TabIndex = 3;
            cboEquipment.SelectedIndexChanged += new System.EventHandler(Input_Changed);

            // lblQty
            lblQty.Anchor = AnchorStyles.Left;
            lblQty.AutoSize = true;
            lblQty.Margin = new Padding(3, 0, 12, 0);
            lblQty.Name = "lblQty";
            lblQty.Text = "Số lượng:";

            // nudQty
            nudQty.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudQty.Margin = new Padding(3, 6, 12, 6);
            nudQty.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQty.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nudQty.Name = "nudQty";
            nudQty.TabIndex = 4;
            nudQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudQty.ValueChanged += new System.EventHandler(Input_Changed);

            // lblBorrow
            lblBorrow.Anchor = AnchorStyles.Left;
            lblBorrow.AutoSize = true;
            lblBorrow.Margin = new Padding(3, 0, 12, 0);
            lblBorrow.Name = "lblBorrow";
            lblBorrow.Text = "Ngày mượn:";

            // dtpBorrow
            dtpBorrow.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpBorrow.Format = DateTimePickerFormat.Short;
            dtpBorrow.Margin = new Padding(3, 6, 3, 6);
            dtpBorrow.Name = "dtpBorrow";
            dtpBorrow.TabIndex = 5;
            dtpBorrow.ValueChanged += new System.EventHandler(Input_Changed);

            // lblDue
            lblDue.Anchor = AnchorStyles.Left;
            lblDue.AutoSize = true;
            lblDue.Margin = new Padding(3, 0, 12, 0);
            lblDue.Name = "lblDue";
            lblDue.Text = "Hạn trả:";

            // dtpDue
            dtpDue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpDue.Format = DateTimePickerFormat.Short;
            dtpDue.Margin = new Padding(3, 6, 12, 6);
            dtpDue.Name = "dtpDue";
            dtpDue.TabIndex = 6;
            dtpDue.ValueChanged += new System.EventHandler(Input_Changed);

            // lblReturn
            lblReturn.Anchor = AnchorStyles.Left;
            lblReturn.AutoSize = true;
            lblReturn.Margin = new Padding(3, 0, 12, 0);
            lblReturn.Name = "lblReturn";
            lblReturn.Text = "Ngày trả thực tế:";

            // dtpReturn (tick chọn = đã trả)
            dtpReturn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpReturn.Checked = false;
            dtpReturn.Format = DateTimePickerFormat.Short;
            dtpReturn.Margin = new Padding(3, 6, 3, 6);
            dtpReturn.Name = "dtpReturn";
            dtpReturn.ShowCheckBox = true;
            dtpReturn.TabIndex = 7;
            dtpReturn.ValueChanged += new System.EventHandler(Input_Changed);

            // lblStatus
            lblStatus.Anchor = AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Margin = new Padding(3, 0, 12, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Tình trạng:";

            // txtStatus
            txtStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStatus.Margin = new Padding(3, 6, 12, 6);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.TabStop = false;

            // flpButtons
            flpButtons.AutoSize = true;
            flpButtons.Controls.Add(btnAdd);
            flpButtons.Controls.Add(btnUpdate);
            flpButtons.Controls.Add(btnDelete);
            flpButtons.Controls.Add(btnReturn);
            flpButtons.Controls.Add(btnClear);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Name = "flpButtons";
            flpButtons.TabIndex = 8;

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

            // btnReturn
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(150, 32);
            btnReturn.TabIndex = 3;
            btnReturn.Text = "Đánh dấu đã trả";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += new System.EventHandler(btnReturn_Click);

            // btnClear
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 32);
            btnClear.TabIndex = 4;
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
            lblSearch.Text = "Tìm (mã SV / tên thiết bị):";

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
            lblFilterStatus.Text = "Tình trạng:";

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

            // dgvSlips
            dgvSlips.AllowUserToAddRows = false;
            dgvSlips.AllowUserToDeleteRows = false;
            dgvSlips.AllowUserToResizeRows = false;
            dgvSlips.AutoGenerateColumns = false;
            dgvSlips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSlips.BackgroundColor = SystemColors.Window;
            dgvSlips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSlips.Columns.AddRange(new DataGridViewColumn[] { colId, colStudentId, colStudentName, colEquipment, colQty, colBorrow, colDue, colReturn, colStatus });
            dgvSlips.Dock = DockStyle.Fill;
            dgvSlips.MultiSelect = false;
            dgvSlips.Name = "dgvSlips";
            dgvSlips.ReadOnly = true;
            dgvSlips.RowHeadersVisible = false;
            dgvSlips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSlips.TabIndex = 2;
            dgvSlips.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvSlips_CellFormatting);
            dgvSlips.SelectionChanged += new System.EventHandler(dgvSlips_SelectionChanged);

            // colId
            colId.DataPropertyName = "Id";
            colId.FillWeight = 65F;
            colId.HeaderText = "Mã phiếu";
            colId.Name = "colId";
            colId.ReadOnly = true;

            // colStudentId
            colStudentId.DataPropertyName = "StudentId";
            colStudentId.FillWeight = 85F;
            colStudentId.HeaderText = "Mã sinh viên";
            colStudentId.Name = "colStudentId";
            colStudentId.ReadOnly = true;

            // colStudentName
            colStudentName.DataPropertyName = "StudentName";
            colStudentName.FillWeight = 120F;
            colStudentName.HeaderText = "Họ tên sinh viên";
            colStudentName.Name = "colStudentName";
            colStudentName.ReadOnly = true;

            // colEquipment
            colEquipment.DataPropertyName = "Equipment";
            colEquipment.FillWeight = 160F;
            colEquipment.HeaderText = "Thiết bị";
            colEquipment.Name = "colEquipment";
            colEquipment.ReadOnly = true;

            // colQty
            colQty.DataPropertyName = "Quantity";
            colQty.FillWeight = 50F;
            colQty.HeaderText = "SL";
            colQty.Name = "colQty";
            colQty.ReadOnly = true;

            // colBorrow
            styleBorrow.Format = "dd/MM/yyyy";
            colBorrow.DataPropertyName = "BorrowDate";
            colBorrow.DefaultCellStyle = styleBorrow;
            colBorrow.FillWeight = 85F;
            colBorrow.HeaderText = "Ngày mượn";
            colBorrow.Name = "colBorrow";
            colBorrow.ReadOnly = true;

            // colDue
            styleDue.Format = "dd/MM/yyyy";
            colDue.DataPropertyName = "DueDate";
            colDue.DefaultCellStyle = styleDue;
            colDue.FillWeight = 85F;
            colDue.HeaderText = "Hạn trả";
            colDue.Name = "colDue";
            colDue.ReadOnly = true;

            // colReturn
            styleReturn.Format = "dd/MM/yyyy";
            styleReturn.NullValue = "";
            colReturn.DataPropertyName = "ReturnDate";
            colReturn.DefaultCellStyle = styleReturn;
            colReturn.FillWeight = 95F;
            colReturn.HeaderText = "Ngày trả thực tế";
            colReturn.Name = "colReturn";
            colReturn.ReadOnly = true;

            // colStatus
            colStatus.DataPropertyName = "Status";
            colStatus.FillWeight = 75F;
            colStatus.HeaderText = "Tình trạng";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;

            // errorProvider1
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;

            // saveFileDialog1
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "CSV (*.csv)|*.csv";
            saveFileDialog1.Title = "Xuất danh sách phiếu mượn";

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 700);
            Controls.Add(tlpMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(950, 620);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab Equipment Checkout";

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
            ((System.ComponentModel.ISupportInitialize)nudQty).EndInit();
            flpButtons.ResumeLayout(false);
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            tlpFilter.ResumeLayout(false);
            tlpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSlips).EndInit();
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
        private ToolStripStatusLabel lblSummary;
        private TableLayoutPanel tlpMain;
        private GroupBox grpInput;
        private TableLayoutPanel tlpInput;
        private Label lblId;
        private TextBox txtId;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblStudentName;
        private TextBox txtStudentName;
        private Label lblEquipment;
        private ComboBox cboEquipment;
        private Label lblQty;
        private NumericUpDown nudQty;
        private Label lblBorrow;
        private DateTimePicker dtpBorrow;
        private Label lblDue;
        private DateTimePicker dtpDue;
        private Label lblReturn;
        private DateTimePicker dtpReturn;
        private Label lblStatus;
        private TextBox txtStatus;
        private FlowLayoutPanel flpButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnReturn;
        private Button btnClear;
        private GroupBox grpFilter;
        private TableLayoutPanel tlpFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblFilterStatus;
        private ComboBox cboFilterStatus;
        private Button btnResetFilter;
        private DataGridView dgvSlips;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colStudentId;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colEquipment;
        private DataGridViewTextBoxColumn colQty;
        private DataGridViewTextBoxColumn colBorrow;
        private DataGridViewTextBoxColumn colDue;
        private DataGridViewTextBoxColumn colReturn;
        private DataGridViewTextBoxColumn colStatus;
        private BindingSource bindingSource1;
        private ErrorProvider errorProvider1;
        private SaveFileDialog saveFileDialog1;
    }
}
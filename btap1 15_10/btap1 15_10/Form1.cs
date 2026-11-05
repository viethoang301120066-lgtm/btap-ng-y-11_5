using System;
using System.Windows.Forms;

namespace btap_15_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đơn giá hợp lệ
            if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá dịch vụ hợp lệ (số không âm)!",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            // 2. Kiểm tra số lượng khách
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng khách hợp lệ (số nguyên > 0)!",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            // 3. Kiểm tra phần trăm giảm giá (0% - 100%)
            decimal phanTramGiam = 0;
            if (!string.IsNullOrWhiteSpace(txtGiamGia.Text))
            {
                if (!decimal.TryParse(txtGiamGia.Text.Trim(), out phanTramGiam) || phanTramGiam < 0 || phanTramGiam > 100)
                {
                    MessageBox.Show("Mã giảm giá phải là số từ 0% đến 100%!",
                                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiamGia.Focus();
                    return;
                }
            }

            // 4. Áp dụng công thức tính tiền: Tổng = (Đơn giá * Số lượng) * (100 - % giảm) / 100
            decimal tongTien = (donGia * soLuong) * (100 - phanTramGiam) / 100;

            // 5. Hiển thị kết quả
            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            lblTongTien.Text = "0 VNĐ";
            txtDonGia.Focus();
        }
    }
}
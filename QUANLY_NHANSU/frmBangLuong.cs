﻿using BLLQLNS;
using DALQLNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLY_NHANSU
{
    public partial class frmBangLuong : Form
    {
        BLLLuong _luong;
        private DataGridViewRow r;
        public frmBangLuong()
        {
            InitializeComponent();
        }

        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            _luong = new BLLLuong();
            LoadData();

        }
        void LoadData()
        {
            
            dgvBangLuong.DataSource = _luong.GetAllBangLuong();
        }

        private void dgvBangLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                r = dgvBangLuong.Rows[e.RowIndex]; // xác định được 1 hàng vừa click
               
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn bảng lương cần xem", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmChiTietLuong(r.Cells["Nam"].Value.ToString(), int.Parse(r.Cells["Thang"].Value.ToString()), int.Parse(r.Cells["MaLuong"].Value.ToString())).ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null || r.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn bảng lương cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show($"Bạn có chắc chắn xóa bảng lương: {r.Cells["MaLuong"].Value?.ToString()} ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _luong.Delete(int.Parse(r.Cells["MaLuong"].Value.ToString()));
                    MessageBox.Show("Xóa bảng lương thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa bảng lương thất bại với lỗi: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (r == null || r.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn bảng lương cần sửa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            new frmDieuChinhBangLuong(r).ShowDialog();

            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            new frmDieuChinhBangLuong().ShowDialog();
            LoadData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cbbThang.SelectedIndex < 0 || cbbNam.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ tháng và năm cần tìm kiếm", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgvBangLuong.DataSource = _luong.TimKiemBangLuong(int.Parse(cbbThang.SelectedItem.ToString()), cbbNam.SelectedItem.ToString());
        }
    }
}

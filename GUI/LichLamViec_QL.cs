using QLPhongMachTu_DOAN_.BLL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLPhongMachTu_DOAN_.GUI
{
    public partial class LichLamViec_QL : UserControl // doi lai thanh usercontrol
    {
        private List<LichPhanCong> ds_lpc;
        private PhanCongBLL phanCongBLL;
        private PhanQuyenBLL phanquyenBLL;
        private BacSiBLL bacSiBLL;
        private KhoaBLL khoaBLL;
        private UserBLL userBLL;
        private LichKhamBLL lichkhamBLL;
        private NhanVienBLL nhanvienBLL;

        private long selectedMaLPC;
        public LichLamViec_QL()
        {
            InitializeComponent();
            phanCongBLL = new PhanCongBLL();
            bacSiBLL = new BacSiBLL();
            phanquyenBLL = new PhanQuyenBLL();
            khoaBLL = new KhoaBLL();
            userBLL = new UserBLL();
            lichkhamBLL = new LichKhamBLL();
            nhanvienBLL = new NhanVienBLL();

            LoadData();
            LoadComboBoxChucVu();
            LoadComboBoxChuyenKhoa();
            LoadComboBoxHoTen();
            LoadComboBoxLichKham();
            LoadComboBoxNhanVien();

            //comboBox4.SelectedIndex = 0;
        }

        public void LoadData()
        {
            // Xóa hết các dữ liệu cũ trong DataGridView
            dataGridView1.Rows.Clear();

            // Lấy tất cả các bản ghi từ bảng LichPhanCongs
            var ds_lpc = phanCongBLL.GetAll();
            // Lấy các danh sách bác sĩ, người dùng (Users), phân quyền (PhanQuyen) và phòng khoa (Khoa)
            var ds_bs = bacSiBLL.GetAll();       // Danh sách bác sĩ
            var ds_user = userBLL.GetAll();      // Danh sách người dùng
            var ds_pq = phanquyenBLL.GetAll();   // Danh sách phân quyền
            var ds_pk = khoaBLL.GetAll();        // Danh sách phòng khoa

            // Duyệt qua danh sách LichPhanCong để thêm dữ liệu vào DataGridView
            foreach (var lpc in ds_lpc)
            {
                // Lấy bác sĩ tương ứng với MaBS trong LichPhanCong
                var bs = ds_bs.FirstOrDefault(b => b.MaSo == lpc.MaBS);

                // Nếu bác sĩ có dữ liệu hợp lệ
                if (bs != null)
                {
                    // Lấy thông tin người dùng (Users) tương ứng với bác sĩ
                    var user = ds_user.FirstOrDefault(u => u.MaUser == bs.MaUser);  // Lấy người dùng tương ứng với MaUser của bác sĩ

                    // Nếu người dùng có dữ liệu hợp lệ
                    if (user != null)
                    {
                        // Lấy phân quyền của bác sĩ từ MaPQ trong bảng Users
                        var pq = ds_pq.FirstOrDefault(p => p.MaPQ == user.MaPQ);  // Tìm phân quyền của bác sĩ dựa trên MaPQ trong bảng Users

                        // Lấy phòng khoa của bác sĩ từ MaKhoa
                        var pk = ds_pk.FirstOrDefault(k => k.MaPK == bs.MaKhoa);  // Lấy phòng khoa tương ứng với MaKhoa của bác sĩ

                        // Nếu phân quyền và phòng khoa đều có dữ liệu hợp lệ
                        if (pq != null && pk != null)
                        {
                            int rowIndex = dataGridView1.Rows.Add();

                            // Gán giá trị cho các cột trong DataGridView
                            dataGridView1.Rows[rowIndex].Cells[0].Value = lpc.MaLPC;                  // Mã LPC
                            dataGridView1.Rows[rowIndex].Cells[1].Value = bs.HoTen;                   // Họ tên bác sĩ
                            dataGridView1.Rows[rowIndex].Cells[2].Value = pq.TenQuyen;                // Chức vụ (tên quyền)
                            dataGridView1.Rows[rowIndex].Cells[3].Value = pk.ChuyenKhoa;              // Chuyên khoa (hoặc phòng ban)
                            dataGridView1.Rows[rowIndex].Cells[4].Value = lpc.NgayThucHien.ToString("dd-MM-yyyy"); // Ngày thực hiện
                            dataGridView1.Rows[rowIndex].Cells[5].Value = lpc.GhiChu;                 // Ghi chú
                            //dataGridView1.Rows[rowIndex].Cells[6].Value = lpc.TrangThai;                 // Ghi chú
                        }
                    }
                }
            }
        }

        public void LoadComboBoxChucVu()
        {
            comboBox1.Items.Clear();
            foreach (var pq in phanquyenBLL.GetPhanQuyenByName())
            {
                comboBox1.Items.Add(pq);
            }
            comboBox1.SelectedIndex = 0;
        }

        public void LoadComboBoxChuyenKhoa()
        {
            comboBox2.Items.Clear();
            foreach (var ck in khoaBLL.GetAll())
            {
                comboBox2.Items.Add(ck.ChuyenKhoa);
            }
            comboBox2.SelectedIndex = 0;
        }

        public void LoadComboBoxHoTen()
        {
            comboBox3.Items.Clear();
            foreach (var bs in bacSiBLL.GetAll())
            {
                comboBox3.Items.Add(bs.HoTen);
            }
            comboBox3.SelectedIndex = 0;
        }

        public void LoadComboBoxLichKham()
        {
            //comboBox5.Items.Clear();
            //foreach (var lk in lichkhamBLL.GetAll())
            //{
            //    comboBox5.Items.Add(lk.MaLK);
            //}
            //comboBox5.SelectedIndex = 0;
        }

        public void LoadComboBoxNhanVien()
        {
            comboBox6.Items.Clear();
            foreach (var nv in nhanvienBLL.GetAllNhanVien())
            {
                comboBox6.Items.Add(nv.HoTen);
            }
            comboBox6.SelectedIndex = 0;
        }

        //private void button3_Click(object sender, EventArgs e) // them button 
        //{
        //    if (string.IsNullOrWhiteSpace(comboBox3.Text) || string.IsNullOrWhiteSpace(comboBox5.Text))
        //    {
        //        MessageBox.Show("Vui lòng chọn bác sĩ và lịch khám hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    try
        //    {
        //        LichPhanCong lpc = new LichPhanCong
        //        {
        //            MaBS = bacSiBLL.GetAll().FirstOrDefault(_bs => _bs.HoTen == comboBox3.Text).MaSo,
        //            MaLK = lichkhamBLL.GetAll().FirstOrDefault(_lk => _lk.MaLK == Convert.ToInt64(comboBox5.Text)).MaLK,
        //            MaNV = nhanvienBLL.GetAllNhanVien().FirstOrDefault(_nv => _nv.HoTen == comboBox6.Text).MaSo,
        //            NgayThucHien = DateTime.Parse(dateTimePicker1.Text),
        //            //ThoiGian = DateTime.Parse(comboBox4.Text),
        //            GhiChu = textBox1.Text
        //        };

        //        phanCongBLL.CreateLichPhanCong(lpc);
        //        MessageBox.Show("Thêm lịch phân công thành công!", "Thông báo", MessageBoxButtons.OK);
        //        LoadData();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void button3_Click(object sender, EventArgs e) // thêm button
        {
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(comboBox3.Text) || string.IsNullOrWhiteSpace(comboBox6.Text))
            {
                MessageBox.Show("Vui lòng chọn bác sĩ, lịch khám và nhân viên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Kiểm tra nếu MaBS và MaLK hợp lệ
                var bacSi = bacSiBLL.GetAll().FirstOrDefault(_bs => _bs.HoTen == comboBox3.Text);
                //var lichKham = lichkhamBLL.GetAll().FirstOrDefault(_lk => _lk.MaLK == Convert.ToInt64(comboBox5.Text));
                var nhanVien = nhanvienBLL.GetAllNhanVien().FirstOrDefault(_nv => _nv.HoTen == comboBox6.Text);

                if (bacSi == null || nhanVien == null)
                {
                    MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra ngày thực hiện hợp lệ
                if (!DateTime.TryParse(dateTimePicker1.Text, out DateTime ngayThucHien))
                {
                    MessageBox.Show("Ngày thực hiện không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra lịch phân công đã tồn tại chưa
                

                // Khởi tạo đối tượng LichPhanCong
                LichPhanCong newSchedule = new LichPhanCong
                {
                    MaBS = bacSi.MaSo,
                    //MaLK = lichKham.MaLK,
                    MaNV = nhanVien.MaSo,
                    NgayThucHien = ngayThucHien,
                    GhiChu = textBox1.Text
                };

                // Thêm vào cơ sở dữ liệu
                phanCongBLL.CreateLichPhanCong(newSchedule);

                MessageBox.Show("Thêm lịch phân công thành công!", "Thông báo", MessageBoxButtons.OK);
                LoadData();  // Làm mới dữ liệu sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e) // chi chinh sua dc ghi chu/ngay thuc hien/ca lam
        {
            LichPhanCong lpc = new LichPhanCong
            {
                MaLPC = selectedMaLPC,
                MaBS = bacSiBLL.GetAll().FirstOrDefault(_bs => _bs.HoTen == comboBox3.Text).MaSo,
                //MaLK = lichkhamBLL.GetAll().FirstOrDefault(_lk => _lk.MaLK == Convert.ToInt64(comboBox5.Text)).MaLK,
                MaNV = nhanvienBLL.GetAllNhanVien().FirstOrDefault(_nv => _nv.HoTen == comboBox6.Text).MaSo,
                NgayThucHien = DateTime.Parse(dateTimePicker1.Text),
                //ThoiGian = DateTime.Parse(comboBox4.Text),
                GhiChu = textBox1.Text
            };

            phanCongBLL.EditLichPhanCong(lpc);
            MessageBox.Show("Cập nhật lịch phân công thành công!", "Thông báo", MessageBoxButtons.OK);
            LoadData();
        }

        //private void TimChucVuChuyenKhoaCuaHoTen(object sender, EventArgs e)
        //{
        //    var bs = bacSiBLL.GetAll().FirstOrDefault(_bs => _bs.HoTen == comboBox3.Text);
        //    var user = userBLL.GetAll().FirstOrDefault(_user => _user.MaUser == bs.MaSo);
        //    var pk = khoaBLL.GetAll().FirstOrDefault(_pk => _pk.MaPK == bs.MaKhoa);
        //    var cv = phanquyenBLL.GetAll().FirstOrDefault(_cv => _cv.MaPQ == user.MaPQ);

        //    comboBox1.Text = cv.TenQuyen;
        //    comboBox2.Text = pk.TenPhongBan;
        //}

        private void TimChucVuChuyenKhoaCuaHoTen(object sender, EventArgs e)
        {
            //comboBox1.Text = cv.TenQuyen;
            /// comboBox2.Text = pk.TenPhongBan;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // click vào một cell sẽ click vào cả dòng
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ (không phải header)
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Kiểm tra nếu cell có giá trị hợp lệ
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    // Chọn dòng hiện tại
                    dataGridView1.CurrentRow.Selected = true;

                    // Lấy giá trị từ các cell và gán vào các control tương ứng
                    comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // Họ tên
                    comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); // Chức vụ
                    comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); // Chuyên khoa
                    dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value); // Ngày thực hiện
                    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); // Ghi chú

                    // Lấy giá trị MaLPC từ cell và gán vào biến selectedMaLPC
                    selectedMaLPC = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e) // xoa button
        {
            phanCongBLL.DeleteLichPhanCong((int)selectedMaLPC);
            MessageBox.Show("Xóa lịch phân công thành công!", "Thông báo", MessageBoxButtons.OK);
            LoadData();
        }
    }
}




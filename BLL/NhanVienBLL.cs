using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System.Collections.Generic;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nvdal;

        public NhanVienBLL()
        {
            this.nvdal = new NhanVienDAL();
        }

        public List<NhanVien> GetAllNhanVien()
        {
            return nvdal.GetAllNhanVien();
        }

        // Thêm nhân viên vào cơ sở dữ liệu
        public bool AddNhanVien(NhanVien nv)
        {
            return nvdal.AddNhanVien(nv);
        }
    }
}

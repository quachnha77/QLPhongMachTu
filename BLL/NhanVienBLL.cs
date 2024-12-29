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



        //BichNhung

        public bool DeleteNhanVien(long ma)
        {
            return nvdal.DeleteNhanVien(ma);
        }

        public NhanVien GetNhanVienByMa(long ma)
        {
            return nvdal.GetNhanVienByMa(ma);
        }

        public bool UpdateNhanVienByCCCD(NhanVien nv)
        {
            return nvdal.UpdateNhanVienByCCCD(nv);
        }

        public (bool, long) IsCCCDExistAndGetMaUser(long cccd)
        {
            return nvdal.IsCCCDExistAndGetMaUser(cccd);
        }

        public bool UpdateNhanVien(NhanVien nv)
        {
            return nvdal.UpdateNhanVien(nv);
        }
    }
}

using QLPhongMachTu_DOAN_.DAL;
using QLPhongMachTu_DOAN_.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPhongMachTu_DOAN_.BLL
{
    public class BenhNhanBLL
    {
        private readonly BenhNhanDAL dal;

        public BenhNhanBLL()
        {
            this.dal = new BenhNhanDAL();
        }

        public BenhNhan Create(BenhNhan newBenhNhan)
        {   /* Quả code chạy được là chính thôi nha :)))
             * Có thể đề xuất chỉnh sửa
             * Chứ tui cũng éo biết code vậy cô la ko :)))).
             * */
            var benhNhan = dal.Create(newBenhNhan);
            return benhNhan;
        }
    }
}

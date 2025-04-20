using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Models
{
    internal class ContractMob
    {
        // Các thuộc tính tương ứng với các cột trong bảng cơ sở dữ liệu
        protected int IDHĐ { get; set; } // ID hợp đồng
        protected int IDTS { get; set; } // ID tài sản
        protected long SoTien { get; set; } // Số tiền vay
        protected decimal LaiSuat { get; set; } // Lãi suất
        protected DateTime NgayVay { get; set; } // Ngày vay
        protected DateTime HanTra { get; set; } // Hạn trả (có thể null)
        protected string TrangThai { get; set; } // Trạng thái hợp đồng (tối đa 20 ký tự)

        // Constructor mặc định
        public ContractMob() { }

        // Constructor có tham số
        public ContractMob(int idhd, int idts, long sotien, decimal laisuat, DateTime ngayvay, DateTime hantra, string trangthai)
        {
            this.IDHĐ = idhd;
            this.IDTS = idts;
            this.SoTien = sotien;
            this.LaiSuat = laisuat;
            this.NgayVay = ngayvay;
            this.HanTra = hantra;
            this.TrangThai = trangthai;
        }

        public int generalid()
        {
            return int.Parse(connection_sql.ExcuteScalar(string.Format(constant.createid_Contract)));
        }

        public int InsertContract()
        {
            int result = 0;
            string[] paras = new string[7] { "@idhd", "@idts", "@tien", "@lai", "@ngayvay", "@hantra", "@trangthai" };
            object[] values = new object[7] { IDHĐ, IDTS, SoTien, LaiSuat, NgayVay, HanTra, TrangThai };

            // Thực thi stored procedure
            result = connection_sql.Excute_Sql(constant.insert_Contract, CommandType.StoredProcedure, paras, values);
            return result;
        }

        public int UpdateContract()
        {
            int result = 0;
            string[] paras = new string[7] { "@idhd", "@idts", "@tien", "@lai", "@ngayvay", "@hantra", "@trangthai" };
            object[] values = new object[7] { IDHĐ, IDTS, SoTien, LaiSuat, NgayVay, HanTra, TrangThai };
            result = connection_sql.Excute_Sql(constant.update_Contract, CommandType.StoredProcedure, paras, values);
            return result;
        }

        public int DeleteContract()
        {
            int result = 0;
            string[] paras = new string[1] { "@idhd" };
            object[] values = new object[1] { IDHĐ };
            result = connection_sql.Excute_Sql(constant.delete_Contract, CommandType.StoredProcedure, paras, values);
            return result;
        }

        public DataTable SearchContract()
        {
            SqlParameter[] paras = { new SqlParameter("@idhd", IDHĐ) };
            DataTable dt = connection_sql.FillDataTable(constant.search_Contract, paras);
            return dt;
        }

        public DataTable FilterContract()
        {
            SqlParameter[] paras = { new SqlParameter("@status", TrangThai) };
            DataTable dt = connection_sql.FillDataTable(constant.filter_Contract, paras);
            return dt;
        }

        public DataTable SearchAsset()
        {
            SqlParameter[] paras = { new SqlParameter("@idts", IDTS) };
            DataTable dt = connection_sql.FillDataTable(constant.search_Asset, paras);
            return dt;
        }
        public DataTable UpdateStatus()
        {
            return connection_sql.FillDataTable(constant.update_ContractStatus);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CamDo.Models
{
    internal class CustomerMob
    {
        protected string cccd { get; set; }          // CCCD
        protected string hoten { get; set; }         // Họ tên
        protected string sdt { get; set; }           // Số điện thoại
        protected string diachi { get; set; }        // Địa chỉ

        public CustomerMob() { }                     // Constructor mặc định

        public CustomerMob(string cccd) // Constructor với tham số
        {
            this.cccd = cccd;
        }

        public CustomerMob(string cccd, string hoten, string sdt, string diachi)
        {
            this.cccd = cccd;
            this.hoten = hoten;
            this.sdt = sdt;
            this.diachi = diachi;
        }

        public int insertCustomer()
        {
            int result = 0;
            string[] paras = new string[4] { "@cccd", "@hoten", "@sdt", "@diachi" };
            object[] values = new object[4] { cccd, hoten, sdt, diachi };
            // Thực thi stored procedure
            result = connection_sql.Excute_Sql(constant.insert_Customer, CommandType.StoredProcedure, paras, values);
            return result;
        }

        public int updateCustomer()
        {
            int result = 0;
            string[] paras = new string[4] { "@cccd", "@hoten", "@sdt", "@diachi" };
            object[] values = new object[4] { cccd, hoten, sdt, diachi };
            result = connection_sql.Excute_Sql(constant.update_Customer, CommandType.StoredProcedure, paras, values);
            return result;
        }

        public int deleteCustomer()
        {
            int result = 0;
            string[] paras = new string[1] { "@cccd" };
            object[] values = new object[1] { cccd };
            result = connection_sql.Excute_Sql(constant.delete_Customer, CommandType.StoredProcedure, paras, values);
            return result;
        }

        public int checkCustomer()
        {
            SqlParameter[] paras = { new SqlParameter("@cccd", cccd) };
            object result = connection_sql.docGiaTri(constant.check_Customer, paras);
            int count = result != null ? Convert.ToInt32(result) : 0;
            return count;
        }

        public DataTable SearchCustomerByCCCD()
        {
            SqlParameter[] paras = { new SqlParameter("@cccd", "%" + cccd + "%") };
            DataTable dt = connection_sql.FillDataTable(constant.search_CustomerByCCCD, paras);
            return dt;
        }
        public DataTable SearchCustomerByName()
        {
            SqlParameter[] paras = { new SqlParameter("@hoten", "%" + hoten + "%") };
            DataTable dt = connection_sql.FillDataTable(constant.search_CustomerByName, paras);
            return dt;
        }
    }
}

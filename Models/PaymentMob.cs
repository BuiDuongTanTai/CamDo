using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Models
{
    internal class PaymentMob
    {
        protected int IDTT { get; set; }
        protected int IDHD { get; set; }
        protected long SOTIENTRA { get; set; }
        protected DateTime NGAYTRA { get; set; }

        // Constructor mặc định
        public PaymentMob() { }

        // Constructor có tham số
        public PaymentMob(int idtt, int idhd, long sotientra, DateTime ngaytra)
        {
            this.IDTT = idtt;
            this.IDHD = idhd;
            this.SOTIENTRA = sotientra;
            this.NGAYTRA = ngaytra;
        }

        public int generalid()
        {
            return int.Parse(connection_sql.ExcuteScalar(string.Format(constant.createid_Payment)));
        }

        public int InsertPayment()
        {
            int result = 0;
            string[] paras = new string[4] { "@idtt", "@idhd", "@sotientra", "@ngaytra" };
            object[] values = new object[4] { IDTT, IDHD, SOTIENTRA, NGAYTRA };
            // Thực thi stored procedure
            result = connection_sql.Excute_Sql(constant.insert_Payment, CommandType.StoredProcedure, paras, values);
            return result;
        }
    }
}

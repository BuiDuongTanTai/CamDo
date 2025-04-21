using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace CamDo.Models
{
    class UserLoginMod
    {
        protected string username { get; set; } //100
        protected string password { get; set; } //250

        public UserLoginMod()
        {
        }
        public UserLoginMod(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string EncodeSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder hash = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hash.Append(b.ToString("x2"));
                }

                return hash.ToString();
            }
        }

        public string checkLogin()
        {
            string[] paras = new string[2] { "@username", "@password" };
            object[] values = new object[2] { username, password };
            return connection_sql.ExcuteScalar(constant.check_Userlogin, CommandType.StoredProcedure, paras, values);
        }
        public int updateLogin()
        {
            string[] paras = new string[2] { "@username", "@password" };
            object[] values = new object[2] { username, password };
            return connection_sql.Excute_Sql(constant.update_Userlogin, CommandType.StoredProcedure, paras, values);
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Models
{
    internal class AssetMob
    {

        protected int IDTS { get; set; }                 // ID tài sản
        protected string CCCD { get; set; }               // CCCD
        protected string TenTS { get; set; }              // Tên tài sản
        protected string MoTa { get; set; }               // Mô tả
        protected string HinhAnh { get; set; }            // Hình ảnh

        // Constructor mặc định
        public AssetMob() { }

        // Constructor với tất cả tham số
        public  AssetMob(int idts, string cccd, string tenTS, string moTa, string hinhAnh)
        {
            IDTS = idts;
            CCCD = cccd;
            TenTS = tenTS;
            MoTa = moTa;
            HinhAnh = hinhAnh;
        }

        public int generalid()
        {
            return int.Parse(connection_sql.ExcuteScalar(string.Format(constant.createid_Asset)));
        }


        public int InsertAsset()
        {
            string[] paras = new string[5] { "@IDTS", "@CCCD", "@TenTS", "@MoTa", "@HinhAnh" };
            object[] values = new object[5] { IDTS, CCCD, TenTS, MoTa, HinhAnh };
            MessageBox.Show(HinhAnh);
            return connection_sql.Excute_Sql(constant.insert_Asset, CommandType.StoredProcedure, paras, values);
        }

        public int UpdateAsset()
        {
            string[] paras = new string[5] { "@IDTS", "@CCCD", "@TenTS", "@MoTa", "@HinhAnh" };
            object[] values = new object[5] { IDTS, CCCD, TenTS, MoTa, HinhAnh };
            return connection_sql.Excute_Sql(constant.update_Asset, CommandType.StoredProcedure, paras, values);
        }

        public int DeleteAsset()
        {
            string[] paras = new string[1] { "@IDTS" };
            object[] values = new object[1] { IDTS };
            return connection_sql.Excute_Sql(constant.delete_Asset, CommandType.StoredProcedure, paras, values);
        }

        public DataTable SearchAssetByID()
        {
            SqlParameter[] paras = { new SqlParameter("@idts", IDTS) };
            DataTable dt = connection_sql.FillDataTable(constant.search_AssetByID, paras);
            return dt;
        }
        public DataTable SearchAssetByName()
        {
            SqlParameter[] paras = { new SqlParameter("@tents", "%" + TenTS + "%") };
            DataTable dt = connection_sql.FillDataTable(constant.search_AssetByName, paras);
            return dt;
        }

        public DataTable SearchCustomer()
        {
            SqlParameter[] paras = { new SqlParameter("@cccd", "%" + CCCD + "%") };
            DataTable dt = connection_sql.FillDataTable(constant.search_Customer, paras);
            return dt;
        }
    }
}

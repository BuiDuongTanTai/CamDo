using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Models
{
    internal class constant
    {
        // stored procedure check Userlogin
        public static string check_Userlogin = "spCheckLogin";
        public static string update_Userlogin = "spUpdateUserlogin";

        //stored procedure use for table Contract
        public static string createid_Contract = "select id= dbo.fcgetIdContract()";
        public static string insert_Contract = "spInsertContract";
        public static string update_Contract = "spUpdateContract";
        public static string delete_Contract = "spDeleteContract";
        public static string search_Contract = "SELECT * FROM HOPDONG WHERE IDHD = @idhd";
        public static string filter_Contract = "SELECT * FROM HOPDONG WHERE TRANGTHAI = @status";
        public static string show_Contract = "SELECT * FROM HOPDONG ORDER BY IDHD DESC";
        public static string search_Asset= "SELECT * FROM HOPDONG WHERE IDTS = @idts";
        public static string update_ContractStatusAuto = "spUpdateContractStatusAuto";
        public static string update_ContractStatusDone = "spUpdateContractStatusDone";
        public static string update_ContractStatusLiquidation = "spUpdateContractStatusLiquidation";


        //stored procedure use for table Customer
        public static string insert_Customer = "spInsertCustomer";
        public static string update_Customer = "spUpdateCustomer";
        public static string delete_Customer = "spDeleteCustomer";
        public static string check_Customer = "SELECT COUNT(*) FROM KHACHHANG WHERE CCCD = @cccd";
        public static string show_Customer = "SELECT * FROM KHACHHANG ORDER BY HOTEN ASC";
        public static string search_CustomerByCCCD= "SELECT * FROM KHACHHANG WHERE CCCD like @cccd";
        public static string search_CustomerByName= "SELECT * FROM KHACHHANG WHERE HOTEN like @hoten";



        //stored procedure use for table Asset
        public static string createid_Asset = "select id= dbo.fcgetIdAsset()";
        public static string insert_Asset = "spInsertAsset";
        public static string update_Asset = "spUpdateAsset";
        public static string delete_Asset = "spDeleteAsset";
        public static string show_Asset = "SELECT * FROM TAISAN ORDER BY IDTS DESC";
        public static string search_AssetByID= "SELECT * FROM TAISAN WHERE IDTS = @idts";
        public static string search_AssetByName = "SELECT * FROM TAISAN WHERE TENTS like @tents";
        public static string search_Customer= "SELECT * FROM TAISAN WHERE CCCD like @cccd";

        //stored procedure use for table Payment
        public static string createid_Payment = "select id= dbo.fcgetIdPayment()";
        public static string insert_Payment = "spInsertPayment";
        public static string liquidation = "spLiquidation";
    }
}

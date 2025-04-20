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




        ////stored procedure use for table Desk
        //public static string createid_Desk = "select id= dbo.fcgeneralDeskId()";
        //public static string insert_Desk = "spInsertDesk";
        //public static string update_Desk = "spUpdateDesk";
        //public static string delete_Desk = "spDeleteDesk";
        //public static string find_Desk = "spFindDesk";
        //public static string findAll_Desk = "spFindAllDesk";
        //public static string findByStatus_Desk = "spFindByStatusDesk";
        //public static string updateStatus_Desk = "spUpdateStatusDesk";
        //public static string FindByDeskid_Desk = "spFindByDeskid";


        ////status Desk
        //public static int status_upgrade = 0;
        //public static int status_busy = 1;
        //public static int status_ready = 2;

        ////style Desk
        //public static int style_ball = 0;
        //public static int style_france = 1;

        ////status Receiption
        //public static int receiption_new = 0;
        //public static int receiption_finished = 1;
        //public static int receiption_destroyed = 2;

        ////stored procedure use for table Receiption
        //public static string insert_Receiption = "spInsertReceiption";
        //public static string updateTimebegin_Receiption = "spUpdateTimebeginReceiption";
        //public static string createid_Receiption = "select id= dbo.fcgetIdReceiption()";
        //public static string updatefinish_Receiption = "spUpdateReceiptionFinish";
        //public static string findByDeskid_Receiption = "spFindReceiptionByDeskid";
        //public static string transfer_Receiption = "spTransferReceiption";

        ////stored procedure use for table Receiptiondetail
        //public static string insert_Receiptiondetail = "spInsertReceiptiondetail";
        //public static string update_Receiptiondetail = "spUpdateReceiptiondetail";
        //public static string delete_Receiptiondetail = "spDeleteReceiptiondetail";
        //public static string createid_Receiptiondetail = "select id= dbo.fcgetIdReceiptiondetail()";
        //public static string findByReceiptionid_Receiptiondetail = "spFindByReceiptionid";

    }
}

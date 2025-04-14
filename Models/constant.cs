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

        ////stored procedure use for table Menu
        //public static string insert_Menu = "spInsertMenu";
        //public static string update_Menu = "spUpdateMenu";
        //public static string delete_Menu = "spDeleteMenu";
        //public static string createid_Menu = "select id= dbo.fcgetIdMenu()";
        //public static string findView_Menu = "spFindViewMenu";

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

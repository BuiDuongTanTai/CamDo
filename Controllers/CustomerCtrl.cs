using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamDo.Models;
using Microsoft.Data.SqlClient;

namespace CamDo.Controllers
{
    internal class CustomerCtrl
    {
        public static int insert(string cccd, string hoten, string sdt, string diachi)
        {
            CustomerMob customer = new CustomerMob(cccd, hoten, sdt, diachi);
            return customer.insertCustomer();
        }

        public static int update(string cccd, string hoten, string sdt, string diachi)
        {
            CustomerMob customer = new CustomerMob(cccd, hoten, sdt, diachi);
            return customer.updateCustomer();
        }

        public static int delete(string cccd)
        {
            CustomerMob customer = new CustomerMob(cccd);
            return customer.deleteCustomer();
        }

        public static int check(string cccd)
        {
            CustomerMob customer = new CustomerMob(cccd);
            return customer.checkCustomer();
        }

        public static DataTable searchCCCD(string cccd)
        {
            CustomerMob customer = new CustomerMob(cccd, "", "", "");
            return customer.SearchCustomerByCCCD();
        }
        public static DataTable searchName(string hoten)
        {
            CustomerMob customer = new CustomerMob("", hoten, "", "");
            return customer.SearchCustomerByName();
        }
    }
}

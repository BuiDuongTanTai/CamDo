using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamDo.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CamDo.Controllers
{
    internal class ContractCtrl
    {
        public static int generalid()
        {
            ContractMob contract = new ContractMob();
            return contract.generalid();
        }

        public static int insert(int idhd, int idts, long sotien, decimal laisuat, DateTime ngayvay, DateTime hantra)
        {
            string trangthai = "Đang hoạt động"; // Đặt trạng thái mặc định
            ContractMob contract = new ContractMob(idhd, idts, sotien, laisuat, ngayvay, hantra, trangthai);
            return contract.InsertContract();
        }

        public static int update(int idhd, int idts, long sotien, decimal laisuat, DateTime ngayvay, DateTime hantra, string trangthai)
        {
            ContractMob contract = new ContractMob(idhd, idts, sotien, laisuat, ngayvay, hantra, trangthai);
            return contract.UpdateContract();
        }

        public static int delete(int idhd)
        {
            ContractMob contract = new ContractMob(idhd, 0, 0, 0, DateTime.Now, DateTime.Now, "");
            return contract.DeleteContract();
        }

        public static DataTable search(int idhd)
        {
            ContractMob contract = new ContractMob(idhd, 0, 0, 0, DateTime.Now, DateTime.Now, "");
            return contract.SearchContract();
        }

        public static DataTable filter(string status) {
            ContractMob contract = new ContractMob(0, 0, 0, 0, DateTime.Now, DateTime.Now, status);
            return contract.FilterContract();
        }

        public static DataTable searchAsset(int idts)
        {
            ContractMob contract = new ContractMob(0, idts, 0, 0, DateTime.Now, DateTime.Now, "");
            return contract.SearchAsset();
        }

        public static DataTable updateStatusAuto()
        {
            ContractMob contract = new ContractMob();
            return contract.UpdateStatusAuto();
        }

        public static int pay(int idhd)
        {
            ContractMob contract = new ContractMob(idhd, 0, 0, 0, DateTime.Now, DateTime.Now, "");
            return contract.UpdateStatusDone();
        }

        public static int Liquidate(int idhd)
        {
            ContractMob contract = new ContractMob(idhd, 0, 0, 0, DateTime.Now, DateTime.Now, "");
            return contract.UpdateStatusLiquidation();
        }
    }
}

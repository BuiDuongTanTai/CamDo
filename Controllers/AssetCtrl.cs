using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamDo.Models;

namespace CamDo.Controllers
{
    internal class AssetCtrl
    {
        public static int insert(int idts, string cccd, string tenTS, string moTa, string hinhAnh)
        {
            AssetMob asset = new AssetMob(idts, cccd, tenTS, moTa, hinhAnh);
            return asset.InsertAsset();
        }

        public static int update(int idts, string cccd, string tenTS, string moTa, string hinhAnh)
        {
            AssetMob asset = new AssetMob(idts, cccd, tenTS, moTa, hinhAnh);
            return asset.UpdateAsset();
        }

        public static int delete(int idts)
        {
            AssetMob asset = new AssetMob(idts, "", "", "", "");
            return asset.DeleteAsset();
        }

        public static int generalid()
        {
            AssetMob asset = new AssetMob();
            return asset.generalid();
        }

        public static DataTable searchID(int idts)
        {
            AssetMob asset = new AssetMob(idts, "", "", "", "");
            return asset.SearchAssetByID();
        }

        public static DataTable searchName(string tents)
        {
            AssetMob asset = new AssetMob(0, "", tents, "", "");
            return asset.SearchAssetByName();
        }

        public static DataTable searchCustomer(string cccd)
        {
            AssetMob asset = new AssetMob(0, cccd, "", "", "");
            return asset.SearchCustomer();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamDo.Models;

namespace CamDo.Controllers
{
    internal class PaymentCtrl
    {
        public static int generalid()
        {
            PaymentMob payment = new PaymentMob();
            return payment.generalid();
        }
        public static int insert(int idtt, int idhd, long sotien, DateTime ngaytra)
        {
            PaymentMob payment = new PaymentMob(idtt, idhd, sotien, ngaytra);
            return payment.InsertPayment();
        }
    }
}

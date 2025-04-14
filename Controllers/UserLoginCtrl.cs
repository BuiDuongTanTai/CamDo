using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CamDo.Controllers
{
    class UserLoginCtrl
    {
        public static string encodePassword(string _password)
        {
            Models.UserLoginMod login = new Models.UserLoginMod();
            return login.EncodeSHA256(_password);
        }
        public static string checkUserlogin(string _user, string _password)
        {
            Models.UserLoginMod login = new Models.UserLoginMod(_user, _password);
            return login.checkLogin();
        }
        public static int updateUserlogin(string _user, string _password)
        {
            Models.UserLoginMod login = new Models.UserLoginMod(_user, _password);
            return login.updateLogin();
        }
    }
}

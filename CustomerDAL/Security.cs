using CustomerEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDAL
{
    public static class Security
    {

        public static UserM LoginUser(string UserName, string Password)
        {
            UserM returnVal = null;

            using (ManageCustomersEntities ctx = new ManageCustomersEntities())
            {
                var _ob = ctx.UserMs.SingleOrDefault(b => b.UserName.Equals(UserName) && b.UserPassword.Equals(Password));
                if (_ob != null)
                {
                    returnVal = _ob;
                }
            }

            return returnVal;
        }
    }
}

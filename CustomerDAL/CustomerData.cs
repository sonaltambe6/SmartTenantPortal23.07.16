using CustomerEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDAL
{
    public class CustomerData
    {
        public CustomerData(UserM user)
        {
            CurrentUser = user;
        }

        private UserM _currentUser = null;
        public UserM CurrentUser
        {
            get
            {
                return _currentUser;
            }
            private set
            {
                _currentUser = value;
            }
        }

        public int CustomerId
        {
            get
            {
                int returnValue = 0;

                if (CurrentUser != null)
                {
                    returnValue = CurrentUser.UserID;
                }

                return returnValue;
            }
        }

        private Tenant _currentCustomer = null;

        public Tenant CurrentCustomer
        {
            get
            {
                if (_currentCustomer == null && CurrentUser != null)
                {
                    using (ManageCustomersEntities context = new ManageCustomersEntities())
                    {
                        _currentCustomer = context.Tenants.FirstOrDefault(x => x.Id == CurrentUser.TenantId);
                    }
                }

                return _currentCustomer;
            }
        }

        //public static List<UserRole> Roles
        //{
        //    get
        //    {
        //        List<UserRole> returnValue = new List<UserRole>();  //GetCacheItem(CacheKeys.GlobalRoles) as List<UserRole>;

        //        if (returnValue == null)
        //        {
        //            using (var context = new ManageCustomersEntities())
        //            {
        //                returnValue = context.UserRoles.Where(x => x.Id == _currentUser.UserTypeID).ToList();
        //                //.Where(x => x.START_DATE <= DateTime.UtcNow && (x.END_DATE == null || x.END_DATE >= DateTime.UtcNow)).OrderBy(x => x.ROLE_NAME).ToList();
        //                AddCacheItem(CacheKeys.GlobalRoles, returnValue);
        //            }
        //        }

        //        return returnValue;
        //    }
        //}
    }
}

using CustomerBLL.Membership;
using CustomerDAL;
using CustomerEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CustomerAPI
{
    public static class CustomContext
    {
        public enum CacheKeys
        {
            GlobalRoles,
            EventRuleOperandTypes,
            Applications
        }


        private static void AddCacheItem(CacheKeys key, object obj)
        {

            HttpContext.Current.Cache.Insert(key.ToString(), obj);
        }

        public static object GetCacheItem(CacheKeys key)
        {
            return HttpContext.Current.Cache[key.ToString()];
        }

        public static bool IsAlive
        {
            get
            {
                var returnValue = false;
                if (HttpContext.Current.Session["IsAlive"] != null)
                {
                    returnValue = true;
                }
                return returnValue;
            }
            set
            {
                HttpContext.Current.Session["IsAlive"] = value;
            }
        }

                   
       
        //public static string GetRoleDescription(int roleId)
        //{
        //    string returnValue = string.Empty;

        //    var item = Roles.FirstOrDefault(x => x.Id == roleId);

        //    if (item != null)
        //    {
        //        returnValue = item.RoleName;
        //    }


        //    return returnValue;
        //}

        /// <summary>
        /// Current Tenant
        /// </summary>
        //public static JCI.BE.SmartBuilding.Models.Dim.Tenant CurrentTenant
        //{
        //    get
        //    {
        //        JCI.BE.SmartBuilding.Models.Dim.Tenant returnValue = null;

        //        if (CurrentUser != null)
        //        {
        //            var userPermission = CurrentUser.UserPermissions.FirstOrDefault(x => x.TENANT_ID != null);

        //            if (userPermission != null)
        //            {
        //                returnValue = userPermission.Tenant;
        //            }
        //        }

        //        return returnValue;
        //    }
        //}

        public static int CurrentCustomerId
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

        //public static Models.Dim.CustomerMaster CurrentCustomer
        //{
        //    get
        //    {
        //        Models.Dim.CustomerMaster returnValue = null;

        //        if (CustomerData != null)
        //        {
        //            returnValue = CustomerData.CurrentCustomer;
        //        }

        //        return returnValue;
        //    }
        //}

        public static CustomerData CustomerData
        {
            get
            {
                CustomerData returnValue = HttpContext.Current.Session["CustomerData"] as CustomerData;

                if (returnValue == null)
                {
                    UserM user = null;

                    string username = HttpContext.Current.Request.ServerVariables["LOGON_USER"];

                    // TODO: JAS - Remove this
                    // username = "cwoolsd";

                    if (returnValue == null && !string.IsNullOrEmpty(username))
                    {
                            user = CustomMembershipProvider.GetUserByGlobalId(username);

                            if (user != null)
                            {
                                returnValue = new CustomerData(user);

                                CustomerData = returnValue;
                            }                        
                    }
                }

                return returnValue;
            }
            set
            {
                HttpContext.Current.Session["CustomerData"] = value;

                if (value != null)
                {
                    if (value.CurrentUser != null)
                    {
                        // CustomContext.ThemesController.Reset(value.CurrentUser.CUSTOMER_ID, null);
                    }
                }
            }
        }


        public static UserM CurrentUser
        {
            get
            {
                UserM returnValue = null;

                if (CustomerData != null)
                {
                    returnValue = CustomerData.CurrentUser;
                }

                return returnValue;
            }
        }

        public static string CurrentUserName
        {
            get
            {
                string returnValue = "unknown user";

                if (CurrentUser != null)
                {
                    returnValue = CurrentUser.UserName;
                }

                return returnValue;

            }
        }



       
        
    }
}

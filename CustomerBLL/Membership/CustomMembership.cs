using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using CustomerDAL;
using CustomerEntities.Entities;

namespace CustomerBLL.Membership
{
    public class CustomMembershipProvider : System.Web.Security.MembershipProvider
    {
        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool ValidateUser(string username, string password, int? userTypeId = null)
        {
            //Logging.LogInformation(Logging.TraceType.UI, "CustomMembershipProvider.ValidateUser: attempt authentication for user " + username);

            bool returnValue = false;            

            var appUser = CustomerDAL.Security.LoginUser(username, password);

            if (appUser != null)
            {
                if (appUser.UserTypeID != 5)  //If tenant user
                {
                    appUser = null;
                }
                //if (appUser.SITEMINDER_ONLY)  //  Unsure if final siteminder validation will include this call or not.  But for now, block
                //{
                //    Logging.LogInformation(Logging.TraceType.UI, "CustomMembershipProvider.ValidateUser: user rejected from forms auth due to siteminder only flag:" + username);
                //    appUser = null;
                //}

                //else if (appUser.UserPermissions.Count != 0 && userTypeId == null)  //  Allow global admin's always
                //{
                //    if (!appUser.UserPermissions.Any(x => (x.USER_TYPE_ID == 1 || x.USER_TYPE_ID == 4 || x.USER_TYPE_ID == 2 || x.USER_TYPE_ID == 6) && x.Active))
                //    {
                //        Logging.LogInformation(Logging.TraceType.UI, "CustomMembershipProvider.ValidateUser: set user to null due to insufficient permissions: " + username);

                //        appUser = null;
                //    }
                //}
            }

            //  TODO:  Can check roles for Green Games Administrator

            returnValue = appUser != null;

            //Logging.LogInformation(Logging.TraceType.UI, "CustomMembershipProvider.ValidateUser: authentication result for user " + username + ": " + returnValue);

            return returnValue;

        }

        public override bool ValidateUser(string username, string password)
        {
            return ValidateUser(username, password, userTypeId: null);
        }

        public static UserM GetUserByGlobalId(string globalId)
        {
            UserM returnValue = null;

            using (var context = new ManageCustomersEntities())
            {
                returnValue = context.UserMs
                    //.Include(x => x.UserRoles)
                    //.Include("UserRoles.Role")
                    //.Include(x => x.UserPermissions)
                    //.Include("UserPermissions.UserType")
                    //.Include(x => x.UserAppSettings)
                    .FirstOrDefault(x => x.UserName == globalId && x.UserTypeID==5);

                if (returnValue != null)
                {
                    //returnValue = returnValue.UserPermissions.OrderByDescending(x => x.CUSTOMER_ID).ToList();
                }
            }

            return returnValue;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
    }
}

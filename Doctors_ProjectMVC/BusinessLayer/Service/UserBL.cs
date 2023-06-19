using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public UserModel UserRegister(UserModel user)
        {
            try
            {
                return this.userRL.UserRegister(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserModel UserLogin(LoginModel loginModel)
        {
            try
            {
                return this.userRL.UserLogin(loginModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<GetUser> GetAllUser()
        {
            try
            {
                return this.userRL.GetAllUser();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public GetUser GetUserDetails(int? UserID)
        {
            try
            {
                return this.userRL.GetUserDetails(UserID);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public GetUser UpdateUser(GetUser user)
        {
            try
            {
                return this.userRL.UpdateUser(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public GetUser DeleteUser(int? UserID)
        {
            try
            {
                return this.userRL.DeleteUser(UserID);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

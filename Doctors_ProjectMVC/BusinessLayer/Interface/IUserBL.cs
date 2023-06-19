using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        public UserModel UserRegister(UserModel user);

        public UserModel UserLogin(LoginModel loginModel);
        public IEnumerable<GetUser> GetAllUser();
        public GetUser GetUserDetails(int? UserID);
        public GetUser UpdateUser(GetUser user);
        public GetUser DeleteUser(int? UserID);
    }
}

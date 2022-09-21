using CommonServiceLocator;
using System;
using WebBLL.Interface;
using WebDAL;
using WebModel.Interface;
using WebModel.Login;

namespace WebBLL
{
    public class LoginBLL: ILoginBLL
    {
        private ILoginData _loginData;
        public LoginBLL()
        {
            _loginData = ServiceLocator.Current.GetInstance<ILoginData>();
        }
        //private ILoginData _loginData;
        //public LoginBLL(ILoginData loginData)
        //{
        //    _loginData = loginData;
        //}
        public bool IsMember(AccountModel account)=> _loginData.IsMember(account);
    }
}

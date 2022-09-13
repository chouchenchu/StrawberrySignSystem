using System;
using System.Collections.Generic;
using System.Text;
using WebModel.Login;

namespace WebBLL.Interface
{
    public interface ILoginBLL
    {
        public bool IsMember(AccountModel account);
    }
}

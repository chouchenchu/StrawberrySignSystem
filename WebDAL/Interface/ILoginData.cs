using System;
using System.Collections.Generic;
using System.Text;
using WebModel.Login;

namespace WebModel.Interface
{
    public interface ILoginData
    {
        public bool IsMember(AccountModel account);
    }
}

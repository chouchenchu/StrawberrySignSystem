using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBLL.Interface;
using WebModel.Common;
using WebModel.Login;

namespace StrawberrySignSystem.Controllers
{
    public class LoginController: BaseController
    {
        #region Filed
        private ILoginBLL _loginBLL;
        #endregion

        #region Binding

        #endregion

        #region Construct
        public LoginController(ILoginBLL loginBLL, IHttpContextAccessor accessor):base(accessor)
        {
            _loginBLL=loginBLL; 
        }
        #endregion

        #region Public Method
        public ActionResult Login(AccountModel accountModel)
        {
            //var _ApiResult = new ApiResult();

            //var dd = new SessionHelper().GetSession("CaptchaCode").ToString();
            //if (_LoginModel.captchaCode != dd)
            //{
            //    _ApiResult.Successed = false;
            //    _ApiResult.ErrorMessage = "驗證碼錯誤,請重新輸入";

            //    return Json(_ApiResult);
            //}

            //得到登入者資訊
            var loginmodel = _loginBLL.IsMember(accountModel);

            //if (loginmodel.StoreCode != null)
            //{

            //    SignInAsync(loginmodel);

            //    _ApiResult.Successed = true;
            //    _ApiResult.RoleID = loginmodel.RoleID;

            //    return Json(_ApiResult);
            //}

            return PartialView("_DialogContent", new PopWindowsModel { Title = "錯誤", Content = "無法登入" });
        }
        #endregion
    }
}

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebBLL;
using WebBLL.Interface;
using WebDAL.Login;
using WebModel.Common;
using WebModel.Interface;
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
        public void Resgiter()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<ILoginBLL, LoginBLL>();
            SimpleIoc.Default.Register<ILoginData, LoginData>();
        }
        public LoginController(/*ILoginBLL loginBLL, */IHttpContextAccessor accessor):base(accessor)
        {
            Resgiter();
            _loginBLL = ServiceLocator.Current.GetInstance<ILoginBLL>();
        }
        #endregion

        #region Public Method
        public IActionResult Index()
        {
            AccountModel accountModel = new AccountModel();
            accountModel.Account = "123";
            accountModel.Password = "123";
            //Login(accountModel);
            //ViewBag.Version = GlobalContext.SystemConfig.Version;
            if (_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.AuthorityName = _accessor.HttpContext.User.FindFirst("AuthorityName").Value;
                var RoleID = _accessor.HttpContext.User.FindFirst("RoleID").Value;
                ViewBag.RoleID = RoleID;
                var StoreCode = _accessor.HttpContext.User.FindFirst("StoreCode").Value;


            }
            return View("View/Login.cshtml");
        }
        [HttpPost]
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
            //WebModel.Login.AccountModel accountModel = new AccountModel();
            //得到登入者資訊
            var loginmodel = _loginBLL.IsMember(accountModel);
            if(loginmodel)
                return View("View/HomePagecshtml.cshtml");
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

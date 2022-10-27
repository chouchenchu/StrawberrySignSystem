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
            return View("View/Login.cshtml", accountModel);
        }
        public ActionResult Login(AccountModel accountModel)
        {
            //得到登入者資訊
            var loginmodel = _loginBLL.IsMember(accountModel);
            if (loginmodel)
            {
                //return RedirectToAction("HomePagecshtml", "View", null);
                return View("View/HomePagecshtml.cshtml");
            }


            return PartialView("_DialogContent", new PopWindowsModel { Title = "錯誤", Content = "無法登入" });
        }
        #endregion
    }
}

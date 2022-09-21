using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            Login(accountModel);
            //ViewBag.Version = GlobalContext.SystemConfig.Version;
            if (_accessor.HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.AuthorityName = _accessor.HttpContext.User.FindFirst("AuthorityName").Value;
                var RoleID = _accessor.HttpContext.User.FindFirst("RoleID").Value;
                ViewBag.RoleID = RoleID;
                var StoreCode = _accessor.HttpContext.User.FindFirst("StoreCode").Value;
                //switch (RoleID)
                //{
                //    case "1":
                //        var StoreAccountList = _IAccountService.GetStoreAccountList(StoreCode, 1);
                //        ViewBag.Model = StoreAccountList;
                //        return View("Views/StoreAccountManagement/index.cshtml");
                //    case "2":
                //        var StoreAccountList1 = _IAccountService.GetStoreAccountList(StoreCode, 1);
                //        ViewBag.Model = StoreAccountList1;
                //        return View("Views/StoreAccountManagement/index.cshtml");
                //    case "3":
                //        var AccountsList = _IAccountService.GetFAEAccountList(StoreCode, 3);
                //        if (AccountsList != null)
                //            ViewBag.Model = AccountsList;
                //        return View("Views/WithBitAccount/index.cshtml");
                //    case "4":
                //        var _model = _IAreaService.GetBandManagementMoel(StoreCode);
                //        _model.StoreCode = StoreCode;
                //        return View("Views/BandManagement/index.cshtml", _model);
                //}

            }
            return View("Login");
        }
        public void Login(AccountModel accountModel)
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

        }
        public ActionResult Login1(AccountModel accountModel)
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

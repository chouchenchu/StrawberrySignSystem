using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StrawberrySignSystem.Controllers
{
    public abstract class BaseController : Controller
    {
        public readonly IHttpContextAccessor _accessor;

        public BaseController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

    }
}

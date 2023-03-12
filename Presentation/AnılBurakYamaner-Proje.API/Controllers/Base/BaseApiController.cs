using AnılBurakYamaner_Proje.Common.WorkContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AnılBurakYamaner_Proje.API.Controllers.Base
{
    [Authorize]
    [ApiController]
    public class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
    {
        private IWorkContext _workContext;

        public IWorkContext WorkContext
        {
            get
            {
                if (_workContext == null)
                {
                    //using Microsoft.Extensions.DependencyInjection
                    _workContext = HttpContext.RequestServices.GetService<IWorkContext>();
                }
                return _workContext;
            }
            set { _workContext = value; }
        }
    }
}

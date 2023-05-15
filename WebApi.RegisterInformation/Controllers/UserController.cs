using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.RegisterInformation.Domain;
using WebApi.RegisterInformation.Dto;
using WebApi.RegisterInformation.Service.UserService;

namespace WebApi.RegisterInformation.Controllers
{

    public class UserController : ApiController
    {


        private readonly IUserService iUserService;
        public UserController(IUserService iUserService)
        {
            this.iUserService = iUserService;

        }

        [Route("api/SubmitUser")]
        [ResponseType(typeof(ResultMessage))]
        public async Task<IHttpActionResult> PostSubmitUser(UserDto _user)
        {
            _user.Id = Guid.NewGuid();
            var result = await iUserService.Submit(_user);
            return Content(result.httpStatusCode, result);
        }


        [Route("api/EditUser")]
        [ResponseType(typeof(ResultMessage))]
        public async Task<IHttpActionResult> PostEditUser(UserEditDto _user)
        {
             var result = await iUserService.Upadte(_user);
            return Content(result.httpStatusCode, result);
        }


    }
}

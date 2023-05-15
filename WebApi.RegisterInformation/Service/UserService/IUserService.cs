using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.RegisterInformation.Dto;

namespace WebApi.RegisterInformation.Service.UserService
{
   public interface IUserService
    {
        Task<ResultMessage> Submit(UserDto userDto);
        Task<ResultMessage> Upadte(UserEditDto userDto);
        Task<ResultMessage> FindByUsernameAsync(UserSearchDto userSearchDto);

    }
}

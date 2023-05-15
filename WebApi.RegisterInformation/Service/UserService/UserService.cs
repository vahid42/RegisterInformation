using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WebApi.RegisterInformation.Domain;
using WebApi.RegisterInformation.Dto;
using WebApi.RegisterInformation.Infrastructures.ListMessage;
using WebApi.RegisterInformation.Repository;

namespace WebApi.RegisterInformation.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepositoryService<User> irepositoryService;
        public UserService(IRepositoryService<User> repositoryService)
        {
            irepositoryService = repositoryService;
        }


        public async Task<ResultMessage> Submit(UserDto userDto)
        {
            try
            {
                var exsist = await FindByUsernameAsync(new UserSearchDto() { username = userDto.Username });
                if (exsist.Status == true)
                {
                    return GetResult(HttpStatusCode.Conflict, false, ShowMessage.RepeatSubmitUser);
                }

                var result = await irepositoryService.InsertAsync((User)userDto);

                if (result == true)
                {
                    return GetResult(HttpStatusCode.OK, true, ShowMessage.SubmitSuccess);
                }
                else
                {
                    return GetResult(HttpStatusCode.Conflict, false, ShowMessage.SubmitFailed);
                }
            }
            catch (Exception er)
            {

                return GetResult(HttpStatusCode.Conflict, false, ShowMessage.Failed, er.ToString());
            }


        }

        public async Task<ResultMessage> Upadte(UserEditDto userDto)
        {
            try
            {
                var exsist = await FindByUsernameAsync(new UserSearchDto() { username = userDto.Username});
                if (exsist.Status == false)
                {
                    return GetResult(HttpStatusCode.Conflict, false, ShowMessage.ExsistUser);
                }


                User _user = JsonConvert.DeserializeObject<User>(exsist.Content);
                _user.Name = userDto.Name;
                _user.Family = userDto.Family;



                var result = await irepositoryService.UpdateAsync(_user);

                if (result == true)
                {
                    return GetResult(HttpStatusCode.OK, true, ShowMessage.UpdateSuccess);
                }
                else
                {
                    return GetResult(HttpStatusCode.Conflict, false, ShowMessage.UpdateFailed);
                }

            }
            catch (Exception er)
            {

                return GetResult(HttpStatusCode.Conflict, false, ShowMessage.Failed, er.ToString());
            }
        }

        public async Task<ResultMessage> FindByUsernameAsync(UserSearchDto userSearchDto)
        {
            try
            {
                var result = await irepositoryService.Find_Without_IdAsync(x => x.Username == userSearchDto.username);

                if (result != null)
                {
                    return GetResult(HttpStatusCode.OK, true, JsonConvert.SerializeObject(result));
                }
                else
                {
                    return GetResult(HttpStatusCode.Conflict, false, ShowMessage.FindFailed);
                }
            }
            catch (Exception er)
            {

                return GetResult(HttpStatusCode.Conflict, false, ShowMessage.Failed, er.ToString());
            }
        }


        private ResultMessage GetResult(HttpStatusCode httpStatusCode, bool status, string content, string error = null)
        {
            return new ResultMessage()
            {
                httpStatusCode = httpStatusCode,
                Status = status,
                Content = content,
                Error = error

            };
        }
    }
}
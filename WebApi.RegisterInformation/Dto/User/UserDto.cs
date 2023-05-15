using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.RegisterInformation.Domain;

namespace WebApi.RegisterInformation.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string PasswordHash { get; set; }
        public DateTime SubmitDateTime { get; set; } = DateTime.Now;
        public int Enable { get; set; }
        public int Delete { get; set; }

        public static explicit operator UserDto(User v)
        {
            return new UserDto()
            {
                Id = v.Id,
                Name = v.Name,
                Family = v.Family,
                Username = v.Username,
                Password = v.Password,
                PasswordConfirm = v.PasswordConfirm,
                PasswordHash = v.PasswordHash,
                SubmitDateTime = v.SubmitDateTime,
                Enable = v.Enable,
                Delete = v.Delete

            };
        }

        public static explicit operator User(UserDto v)
        {
            return new User()
            {
                Id = v.Id,
                Name = v.Name,
                Family = v.Family,
                Username = v.Username,
                Password = v.Password,
                PasswordConfirm = v.PasswordConfirm,
                PasswordHash = v.PasswordHash,
                SubmitDateTime = v.SubmitDateTime,
                Enable = v.Enable,
                Delete = v.Delete

            };
        }
    }
}
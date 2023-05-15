using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApi.RegisterInformation.Dto;

namespace WebApi.RegisterInformation.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public Guid Id { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        public string Name { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        public string Family { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        public string Username { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        public string Password { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(256)]
        public string PasswordConfirm { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(500)]
        public string PasswordHash { get; set; }
        public DateTime SubmitDateTime { get; set; } = DateTime.Now;
        public int Enable { get; set; } = 1;
        public int Delete { get; set; } = 0;
        public  virtual ICollection<CarInfo> CarInfo   { get; set; }

       

        public virtual CountrySection CountrySection { get; set; }

        public virtual UserPermission    UserPermission { get; set; }

        
    }
}
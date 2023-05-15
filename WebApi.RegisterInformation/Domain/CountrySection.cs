using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.RegisterInformation.Domain
{
    public class CountrySection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int ParentId { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Section { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(150)]
        public string Location { get; set; }

        //public virtual ICollection<User> Users { get; set; }


    }
}
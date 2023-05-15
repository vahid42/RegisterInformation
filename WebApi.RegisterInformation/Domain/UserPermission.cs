using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.RegisterInformation.Domain
{
    public class UserPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(500)]
        public string Permission { get; set; }
        public DateTime SubmitDateTime { get; set; } = DateTime.Now;
        public int Enable { get; set; } = 1;
        public int Delete { get; set; } = 0;
        public virtual User User { get; set; }


    }
}
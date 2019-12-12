using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FunkyMunch.Data.Entities
{
    public class User : BaseEntity
    {        
        [StringLength(128)]
        public string EmailAddress { get; set; }
        
        [Required]
        [StringLength(128)]
        public string Password { get; set; }

        [Required]
        [StringLength(32)]
        public string DisplayName { get; set; }
    }
}

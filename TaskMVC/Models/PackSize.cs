using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMVC.Models
{
    public class PackSize
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int PackSizeName { get; set; }
    }
}
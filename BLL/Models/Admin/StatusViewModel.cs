using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLL.Models.Admin
{
    public class StatusViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class StatusCreateViewModel
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
    }

    public enum StatusResult
    {
        Success = 1,
        Failure = 2
    }
}
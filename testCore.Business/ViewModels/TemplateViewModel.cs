using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace testCore.Business
{
   public class TemplateViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذا الحقل إجباري")]
        public IFormFile Photo { get; set; }
        public string PhotoString { get; set; }
    }
}

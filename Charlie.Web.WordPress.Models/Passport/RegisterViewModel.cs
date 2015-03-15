﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charlie.Web.WordPress.Models.Passport
{
    [Serializable]
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }

        [Required]
        [Display(Name = "电子邮件")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
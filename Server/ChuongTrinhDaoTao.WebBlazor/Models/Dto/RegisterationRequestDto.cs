﻿using System.ComponentModel.DataAnnotations;

namespace ChuongTrinhDaoTao.WebBlazor.Models.Dto
{
    public class RegisterationRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string CohortId { get; set; }
    }
}

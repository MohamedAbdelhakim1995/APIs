using System.ComponentModel.DataAnnotations;

namespace EcommerceApis.Dto
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

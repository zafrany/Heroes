using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes.Models
{
    public class SignUpModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace BettingSystem.Web.Areas.User.Models
{
    public class UserLoginViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
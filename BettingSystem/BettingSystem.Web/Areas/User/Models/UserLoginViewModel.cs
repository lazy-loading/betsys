using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BettingSystem.Web.Areas.User.Models
{
    public class UserLoginViewModel
    {
        [Required, DataType(DataType.EmailAddress), Display(Name="Email Address")]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password), Display(Name="Password")]
        public string Password { get; set; }
    }
}
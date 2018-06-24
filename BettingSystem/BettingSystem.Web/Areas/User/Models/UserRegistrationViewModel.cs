using System.ComponentModel.DataAnnotations;

namespace BettingSystem.Web.Areas.User.Models
{
    public class UserRegistrationViewModel
    {
        [Required, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required,DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
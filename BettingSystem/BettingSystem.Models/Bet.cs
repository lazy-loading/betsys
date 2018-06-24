using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BettingSystem.Models
{
    public class Bet : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }
        
        [Required]
        public int UserId { get; set; }

        public ICollection<SportEventSelection> Selections { get; set; }

        [NotMapped]
        public SportEvent Event => Selections?.FirstOrDefault()?.Market.Event;

        protected bool Equals(Bet other)
        {
            return Id == other.Id && Equals(User, other.User) && UserId == other.UserId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Bet) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (User != null ? User.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ UserId;
                return hashCode;
            }
        }

        public static bool operator ==(Bet left, Bet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Bet left, Bet right)
        {
            return !Equals(left, right);
        }
    }
}
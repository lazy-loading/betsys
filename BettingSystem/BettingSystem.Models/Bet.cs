using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BettingSystem.Models
{
    public class Bet : IEntity
    {
        [Key] public int Id { get; set; }

        [Required] public decimal BetValue { get; set; }

        [Required] public string UserId { get; set; }

        [Required] public int SelectionId { get; set; }

        #region Navigation properties

        [Required] public User User { get; set; }

        [Required] public SportEventSelection Selection { get; set; }

        #endregion

        #region Equality members

        protected bool Equals(Bet other)
        {
            return Id == other.Id &&
                   BetValue == other.BetValue &&
                   string.Equals(UserId,
                       other.UserId) &&
                   SelectionId == other.SelectionId;
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
                hashCode = (hashCode * 397) ^ BetValue.GetHashCode();
                hashCode = (hashCode * 397) ^ (UserId != null ? UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SelectionId;
                return hashCode;
            }
        }

        #endregion
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BettingSystem.Models
{
    public class SportEventSelection : IEntity, IEquatable<SportEventSelection>
    {
        [Key] public int Id { get; set; }

        [Required] public int Number { get; set; }

        [Required] public string Description { get; set; }

        [Required] public decimal Odds { get; set; }

        [Required] public SelectionParticipantType? Participant { get; set; }

        [Required] public int MarketId { get; set; }

        #region Navigation properties

        [Required] public SportEventMarket Market { get; set; }

        #endregion

        #region Equality members

        public bool Equals(SportEventSelection other)
        {
            return Id == other.Id &&
                   Number == other.Number &&
                   string.Equals(Description,
                       other.Description) &&
                   Odds == other.Odds &&
                   Participant == other.Participant &&
                   MarketId == other.MarketId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SportEventSelection) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Number;
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Odds.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) Participant;
                hashCode = (hashCode * 397) ^ MarketId;
                return hashCode;
            }
        }

        public static bool operator ==(SportEventSelection left, SportEventSelection right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SportEventSelection left, SportEventSelection right)
        {
            return !Equals(left, right);
        }

        #endregion

        public override string ToString() =>
            $"{Id}, {Number}, {Description}, {Odds}, {Participant}";
    }
}
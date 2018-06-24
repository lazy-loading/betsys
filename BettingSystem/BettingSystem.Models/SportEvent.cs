using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BettingSystem.Models
{
    public class SportEvent : IEntity, IEquatable<SportEvent>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SportType { get; set; }

        [Required]
        public DateTime EventTime { get; set; }
        
        [Required]
        public string HomePlayer { get; set; }
        
        [Required]
        public string AwayPlayer { get; set; }
        
        [Required]
        public IList<SportEventMarket> Markets { get; set; }

        [Required]
        public ICollection<Bet> Bets { get; set; }

        public bool Equals(SportEvent other)
        {
            return Id == other.Id &&
                   string.Equals(SportType,
                       other.SportType) &&
                   EventTime.Equals(other.EventTime) &&
                   string.Equals(HomePlayer,
                       other.HomePlayer) &&
                   string.Equals(AwayPlayer,
                       other.AwayPlayer);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SportEvent) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (SportType != null ? SportType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ EventTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (HomePlayer != null ? HomePlayer.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AwayPlayer != null ? AwayPlayer.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(SportEvent left, SportEvent right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SportEvent left, SportEvent right)
        {
            return !Equals(left, right);
        }
    }
}
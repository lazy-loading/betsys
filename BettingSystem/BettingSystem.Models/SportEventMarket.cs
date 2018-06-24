using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BettingSystem.Models
{
    public class SportEventMarket : IEntity, IEquatable<SportEventMarket>
    {
        [Key] public int Id { get; set; }

        [Required] public int Number { get; set; }

        [Required] public string Name { get; set; }

        [Required] public bool IsClosed { get; set; }

        [Required] public int EventId { get; set; }

        #region Navigation properties

        [Required] public SportEvent Event { get; set; }

        [Required] public IList<SportEventSelection> Selections { get; set; }

        #endregion

        public override string ToString() =>
            $"{Id}, {Number}, {Name}, {IsClosed}, {Selections?.Count}";

        #region Equality members

        public bool Equals(SportEventMarket other)
        {
            return Id == other.Id &&
                   Number == other.Number &&
                   string.Equals(Name,
                       other.Name) &&
                   IsClosed == other.IsClosed &&
                   EventId == other.EventId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SportEventMarket) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Number;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsClosed.GetHashCode();
                hashCode = (hashCode * 397) ^ EventId;
                return hashCode;
            }
        }

        public static bool operator ==(SportEventMarket left, SportEventMarket right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SportEventMarket left, SportEventMarket right)
        {
            return !Equals(left, right);
        }

        #endregion
    }
}
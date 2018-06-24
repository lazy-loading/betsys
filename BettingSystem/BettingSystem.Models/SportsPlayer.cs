using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BettingSystem.Models
{
    public sealed class SportsPlayer : IEntity, IEquatable<SportsPlayer>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public bool Equals(SportsPlayer other)
        {
            return Id == other.Id && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is SportsPlayer && Equals((SportsPlayer) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public static bool operator ==(SportsPlayer left, SportsPlayer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SportsPlayer left, SportsPlayer right)
        {
            return !Equals(left, right);
        }
    }
}

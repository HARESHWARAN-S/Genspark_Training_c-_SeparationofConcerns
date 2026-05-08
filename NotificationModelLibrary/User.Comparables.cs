namespace NotificationModelLibrary
{
    public partial class User : IComparable<User>, IEquatable<User>
    {
        public static bool operator ==(User? a, User? b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return string.Equals(a.Name, b.Name, StringComparison.OrdinalIgnoreCase);
        }

        public static bool operator !=(User? a, User? b) => !(a == b);

        public override bool Equals(object? obj) =>
            obj is User other && Equals(other);

        public bool Equals(User? other)
        {
            if (other is null) return false;
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int CompareTo(User? other)
        {
            if (other is null) return 1;
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode() => Name.ToLower().GetHashCode();

        public override string ToString() =>
            $"Name  : {Name}\nEmail : {Email}\nPhone : {Phone}";
    }
}
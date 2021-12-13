using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            Age = age;
            FullName = fullName;
            Username = username ?? throw new ArgumentNullException();
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => Age != null;

        public bool Equals(User usr) =>
            Age == usr.Age &&
            FullName == usr.FullName &&
            Username == usr.Username;


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals(obj as User);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, Username, Age);
        }

        public override string ToString()
        {
            return $"[ Full name: {FullName}, username: {Username}, age: {Age}yo ]";
        }
    }
}

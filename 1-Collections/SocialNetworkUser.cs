using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private readonly IDictionary<string, ISet<TUser>> followedUsers = new Dictionary<string, ISet<TUser>>();

        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            //throw new NotImplementedException("TODO is there anything to do here?"); NO >:(
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (followedUsers.ContainsKey(group))
            {
                return followedUsers[group].Add(user);
            }
            else
            {
                followedUsers[group] = new HashSet<TUser> { user };
                return true;
            }
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                //throw new NotImplementedException("TODO construct and return the list of all users followed by the current users, in all groups");

                var allFollowedUsers = new List<TUser>();

                foreach (var group in followedUsers.Values)
                    foreach (var user in group)
                        allFollowedUsers.Add(user);

                return allFollowedUsers;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            //throw new NotImplementedException("TODO construct and return a collection containing of all users followed by the current users, in group");

            if (followedUsers.ContainsKey(group))            
                return new HashSet<TUser>(followedUsers[group]);            
            else
                return new HashSet<TUser>();
        }
    }
}

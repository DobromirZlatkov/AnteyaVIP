namespace AnteyaVIP.Data
{
    using System.Collections.Generic;

    using AnteyaVIP.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class IdentityManager
    {
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new AnteyaVIPDbContext()));
            return rm.RoleExists(name);
        }

        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<User>(
                new UserStore<User>(new AnteyaVIPDbContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        public void ClearUserRoles(string userId, string role)
        {
            var um = new UserManager<User>(
                new UserStore<User>(new AnteyaVIPDbContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);

            um.RemoveFromRole(userId, role);
        }
    }
}

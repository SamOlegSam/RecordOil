using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using RecordOil.Models;

namespace RecordOil.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = new List<string>();
            
            using (RecordOilEntities db = new RecordOilEntities())
            {
                // Получаем пользователя
                
                //Autorize user = db.Autorize.FirstOrDefault(u => u.Login == username);
                //if (user != null && user.Login != null)
                //{
                //    //// получаем роль
                //    //roles = new string[] { user.Login };
                //    Models.Roles userRole = db.Roles.Find(user.RoleId);
                //    if(userRole != null)
                //    roles = new string[] { userRole.Name };

                //}
                //---------------------------------------
                Autorize user = db.Autorize.FirstOrDefault(u => u.Login == username);
                if (user != null && user.Login != null)
                {
                    //---------------------------------------

                    // List<UserRoles> UR =  new List<UserRoles>();
                    //var UR = db.UserRoles.Where(g => g.IdUser == user.ID).ToList();
                    var UR = db.UserRoles
                        .Join(db.Roles,
                        ur => ur.idRole,
                        r => r.IdR,
                        (ur, r) => new { UserRole = ur, Name = r.Name, UserId = ur.IdUser })
                        .Where(u => u.UserId == user.ID).ToList();
                    foreach (var item in UR)
                    {
                        roles.Add(item.Name);
                        //roles = new string[] { item.Name };
                    }
                }
                    return roles.ToArray();
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            using (RecordOilEntities db = new RecordOilEntities())
            {
                Autorize user = db.Autorize.FirstOrDefault(u => u.Login == username);
                if (user != null)
                {
                    Models.Roles userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null && userRole.Name == roleName)
                        outputResult = true;
                }
                
            }
            return outputResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
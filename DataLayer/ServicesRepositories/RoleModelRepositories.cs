using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer
{
    public class RoleModelRepositories : IRoleModelRepositories
    {
        CRM_Sepehr db = new CRM_Sepehr();
        public IEnumerable<RoleModel> GetAllRoles()
        {
            return db.RoleModels;
        }

        public RoleModel GetRoleById(int id)
        {
            return db.RoleModels.Find(id);
        }

        public bool InsertRole(RoleModel roleModel)
        {
            try
            {
                db.RoleModels.Add(roleModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateRole(RoleModel roleModel)
        {
            try
            {
                db.Entry(roleModel).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(RoleModel roleModel)
        {
            try
            {
                db.Entry(roleModel).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteRole(int id)
        {
            try
            {
                var role = GetRoleById(id);
                db.Entry(role).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool save()
        {
            return Convert.ToBoolean(db.SaveChanges());
        }
    }
}
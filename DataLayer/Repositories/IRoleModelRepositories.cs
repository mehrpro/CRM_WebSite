using System.Collections.Generic;

namespace DataLayer
{
    public interface IRoleModelRepositories

    {
        IEnumerable<RoleModel> GetAllRoles();
        RoleModel GetRoleById(int id);
        bool InsertRole(RoleModel roleModel);
        bool UpdateRole(RoleModel roleModel);
        bool DeleteRole(RoleModel roleModel);
        bool DeleteRole(int id);
        bool save();

    }
}
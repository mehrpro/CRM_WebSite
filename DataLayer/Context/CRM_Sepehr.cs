using System.Data.Entity;

namespace DataLayer
{
    public class CRM_Sepehr : DbContext
    {
        public DbSet<UsersModel> UsersModels { get; set; }
        public DbSet<RoleModel> RoleModels { get; set; }
    }
}
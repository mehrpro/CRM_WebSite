using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer
{
    public class UsersModelRepositories : IUserModelRepositories
    {
        private CRM_Sepehr db;

        public UsersModelRepositories(CRM_Sepehr crmSepehr)
        {
            this.db = crmSepehr;
        }
        public IEnumerable<UsersModel> GetAllUsers()
        {
            return db.UsersModels;
        }

        public UsersModel GetUserById(int id)
        {
            return db.UsersModels.Find(id);
        }

        public bool InsertUser(UsersModel usersModel)
        {
            try
            {
                db.UsersModels.Add(usersModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUser(UsersModel usersModel)
        {
            try
            {
                db.Entry(usersModel).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteUser(UsersModel usersModel)
        {
            try
            {
                db.Entry(usersModel).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var user = GetUserById(userId);
                DeleteUser(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save()
        {
            return Convert.ToBoolean(db.SaveChanges());
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class RoleModel
    {
        [Display(Name = "کد")]
        [Key]
        public int RoleID { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(100)]
        public string Role { get; set; }

        [Display(Name = "وضعیت")]
        public bool Enabled { get; set; }

        public virtual List<UsersModel> UsersModels { get; set; }

        public RoleModel() {}
    }
}
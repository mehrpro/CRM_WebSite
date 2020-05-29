using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class UsersModel
    {
        [Key]
        [Display(Name = "کد")]
        public int ID { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "نام")]
        [MaxLength(100)]
        public string FName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string LName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [MaxLength(200)]
        public string FullName { get; set; }

        [Display(Name = "آدرس")]
        [MaxLength(350)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string AddressOne { get; set; }

        [Display(Name = "آدرس دوم")]
        [MaxLength(350)]
        public string AddressTwo { get; set; }

        [Display(Name = "تلفن ثابت")]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20)]
        public string Mobile { get; set; }

        [Display(Name = "نمابر")]
        [MaxLength(20)]
        public string FaxNumber { get; set; }

        [Display(Name = "شرکت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string CompanyName { get; set; }

        [Display(Name = "تاریخ ثبت", AutoGenerateField = false)]
        public DateTime DateTimeRegister { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }

        [Url]
        [Display(Name = "وب سایت")]
        [MaxLength(250)]
        public string WebSite { get; set; }

        [Display(Name = "نقش", AutoGenerateField = false)]
        public int RoleID { get; set; }

        [Display(Name = "وضعیت کاربری", AutoGenerateField = false)]
        public bool EnableUser { get; set; }


        public virtual RoleModel RoleModel { get; set; }

        public UsersModel()
        {
                
        }
    }
}
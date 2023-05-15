using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.RegisterInformation.Infrastructures.ListMessage
{
    public static class ShowMessage
    {
        public static string SubmitSuccess { get; set; } = "ثبت اطلاعات با موفقیت انجام شد";
        public static string SubmitFailed { get; set; } = "در ثبت اطلاعات خطایی رخ داده است";
        public static string UpdateSuccess { get; set; } = "ویرایش اطلاعات با موفقیت انجام شد";
        public static string UpdateFailed { get; set; } = "در ویرایش اطلاعات خطایی رخ داده است";

        public static string RepeatSubmitUser { get; set; } = "نام کاربری تکراری می باشد";
        public static string ExsistUser { get; set; } = "کاربری با این مشخصات یافت نشد";
        public static string FindFailed { get; set; } = "اطلاعاتی یافت نشد";

        public static string Failed { get; set; } = " خطایی نامشخص رخ داده است";

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.RegisterInformation.Domain
{
    public class CarInfo
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public Guid Id { get; set; }

        /// <summary>
        /// سریال VIN خودرو
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(60)]
        public string VinNumber { get; set; }

        /// <summary>
        /// شماره موتور  خودرو
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(60)]
        public string MotorNum { get; set; }

        /// <summary>
        /// شماره شاسی  خودرو
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(60)]
        public string Chassis { get; set; }

        /// <summary>
        /// کلاس خودرو-مثال:سواری
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(60)]
        public string CarClass { get; set; }

        /// <summary>
        /// کاربری خودرو-مثال:سواری
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(60)]
        public string CarType { get; set; }

        /// <summary>
        /// سیستم خودرو-مثال:پراید
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(60)]
        public string SystemType { get; set; }

        /// <summary>
        /// تیپ خودرو-مثال:141
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(60)]
        public string CarTip { get; set; }

        /// <summary>
        /// سیستم سوخت رسانی-دونوع:انژکتوری یا کاربراتور
        /// <para>1 = انژکتوری</para>
        /// <para>2 = کاربراتور</para>
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        public string FuelSystem { get; set; }

        /// <summary>
        /// نوع سوخت رسانی-سه نوع:بنزینی-دوگانه-گازوئیلی
        /// <para>1 = بنزینی</para>
        /// <para>2 = دوگانه</para>
        /// <para>3 = گازوئیلی</para>
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(30)]
        public string FuelType { get; set; }

        /// <summary>
        /// مدل خودرو-مثال:1398
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(10)]
        public string CarModel { get; set; }

        /// <summary>
        /// رنگ خودرو-مثال:قرمز
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(80)]
        public string CarColor { get; set; }

        /// <summary>
        /// <para>مثال:25-ج-921-ایران61</para>
        /// <para>610525921</para>
        /// <para>61 = سریال پلاک</para>
        /// <para>05 = کد حرف</para>
        /// <para>25 = دو رقم سمت چپ</para>
        /// <para>921 = قسمت سه رقمی پلاک</para>
        /// <para>کد حروف به شرح زیر می باشد:</para>
        /// <para>01 => الف</para>
        /// <para>02 => ب</para>
        /// <para>03 => ت</para>
        /// <para>04 => ج</para>
        /// <para>05 => د</para>
        /// <para>06 => س</para>
        /// <para>07 => ص</para>
        /// <para>08 => ط</para>
        /// <para>09 => ع</para>
        /// <para>10 => ق</para>
        /// <para>11 => ل</para>
        /// <para>12 => م</para>
        /// <para>13 => ن</para>
        /// <para>14 => و</para>
        /// <para>15 => ه</para>
        /// <para>16 => ی</para>
        /// <para>18 => گ</para>
        /// <para>19 =>معلولین => ژ</para>
        /// </summary>
        [Column(TypeName = "NVARCHAR")]
        [StringLength(25)]
        public string PlaqueCoded { get; set; }
        public DateTime SubmitDateTime { get; set; } = DateTime.Now;
        public int Enable { get; set; } = 1;
        public int Delete { get; set; } = 0;
    
        /// <summary>
        /// navigation property
        /// </summary>
        [ForeignKey("UserId")]

        /// <summary>
        ///فعال کردن lazyLoading
        ///http://www.tahlildadeh.com/ArticleDetails/%D8%A2%D9%85%D9%88%D8%B2%D8%B4-Navigation-Property-%D8%AF%D8%B1-EF 
        ///روش های غیرفعال سازی lazy loading
        ///هنگام اعلان برخی از navigation property ها، کلیدواژه ی virtual را از تعریف آن حذف کنید.
        ///constructor => context => this.Configuration.LazyLoadingEnabled = false;
        /// </summary>
        public virtual User User { get; set; }
        public Guid UserId { get; set; }


    }
}
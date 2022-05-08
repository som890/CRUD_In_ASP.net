using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppSoccer.Models
{
    public class Soccer
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên!")]
        [Display(Name = "Tên đội bóng")]
        public string TenDoi { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập logo!")]
        [Display(Name = "Logo")]
        public string LoGo { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập số cầu thủ!")]
        [Display(Name = "Số cầu thủ")]
        public int SoCauThu { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập ngày tạo!")]
        [Display(Name = "Ngày tạo")]
        public DateTime NgayTao { set; get; }
    }
   
      
}
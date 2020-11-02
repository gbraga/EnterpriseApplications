using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Models
{
    public class ResponseResult
    {
        public string Title { get; set; }
        public int status { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }
}

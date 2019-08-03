using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Common.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Resuult { get; set; }
    }
}

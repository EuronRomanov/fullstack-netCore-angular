using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Dto
{
    public class ResponseDto
    {
        public string Message {get; set;}="Success";

        public bool IsSuccessed {get; set;}=true;

        public object? Data {get; set;}=null;
    }
}
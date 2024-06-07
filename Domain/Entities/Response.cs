using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Response<T>
    {
        public Response(){ }

        public Response(T data, string message = null)
        {
            Success = true;
            Message = message;
            Result = data;
        }
        public Response(string message)
        {
            Success = false;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}

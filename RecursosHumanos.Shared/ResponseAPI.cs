using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursosHumanos.Shared
{
    public class ResponseAPI<T>
    {
        public bool EsCorrecto{get;set;}

        public T? Value { get;set;}

        public string? Mensaje { get;set;}
        public object? Valor { get; set; }
    }
}

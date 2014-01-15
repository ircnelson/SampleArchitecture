using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleArchiteture.Dominio.Exceptions
{
    /// <summary>
    /// Exception que armazena o valor do objeto <typeparamref name="T" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Exception<T> : Exception
        where T : class 
    {
        public T Target { get; private set; }
        
        public Exception(T target, string message, params object[] @params) 
            : base(string.Format(message, @params))
        {
            Target = target;
        }

        public Exception(T target)
            : this(target, target.ToString())
        {
        }

    }
}

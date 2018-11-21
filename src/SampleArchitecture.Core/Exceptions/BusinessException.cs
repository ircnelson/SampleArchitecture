using System;

namespace SampleArchitecture.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
    
    public class BusinessException<T> : BusinessException
    {
        public T Target { get; }
        
        public BusinessException(T target, string message, params object[] @params) 
            : base(string.Format(message, @params))
        {
            Target = target;
        }

        public BusinessException(T target)
            : this(target, target.ToString())
        {
        }
    }
}
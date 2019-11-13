using System;

namespace BibliotecaBase.Exceptions
{
    internal class DomainException : ApplicationException
    {
        public DomainException(string msg) : base(msg)
        {
        }
    }
}
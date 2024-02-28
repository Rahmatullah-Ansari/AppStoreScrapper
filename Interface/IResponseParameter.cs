using System;

namespace AppStoreScarpper.Interface
{
    public interface IResponseParameter
    {
        Exception Exception { get; set; }
        bool HasError { get; set; }
        string Response { get; set; }
    }
}
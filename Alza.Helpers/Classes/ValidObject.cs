using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Helpers.Classes
{
    /// <summary>
    /// Default IsValid is false
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidObject<T> 
    {
        public bool IsValid { get; private set; }
        public T Value { get; private set; }

        public ValidObject()
        {
            this.IsValid = false;
        }
        public ValidObject(T value)
        {
            this.IsValid = true;
            this.Value = value;
        }
    }
}

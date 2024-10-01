using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace untitled.Interfaces
{
    /// <summary>
    /// An object that is cloneable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface ICustomCloneable<T>
    {
        /// <summary>
        /// Clone the object this is called on.
        /// </summary>
        /// <returns>A deep clone of the object.</returns>
        public abstract T Clone();
    }
}

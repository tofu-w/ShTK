using System;

namespace ShTK.IO.Bindings
{
    /// <summary>
    /// Bindables are user preferences for an application that can be easily written to a single file
    /// </summary>
    public class Bindable <T> : IBindable
    {
        public Type type { get => typeof (T); }

        public dynamic Value;


    }
}

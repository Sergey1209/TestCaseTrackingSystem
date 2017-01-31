using System;

namespace DataAccess.Initializers
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class InitializerAttribute : Attribute
    {
        public InitializerAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}

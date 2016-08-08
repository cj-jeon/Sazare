using System;

namespace Sazare.Common
{
    /// <summary>
    ///     サンプルを表す属性です.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class SampleAttribute : Attribute
    {
    }
}
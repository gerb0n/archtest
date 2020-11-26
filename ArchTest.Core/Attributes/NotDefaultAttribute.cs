using System;
using System.ComponentModel.DataAnnotations;

namespace ArchTest.Core.Attributes
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class NotNullOrDefaultAttribute : ValidationAttribute
    {
        public const string DefaultErrorMessage = "The {0} field must not be empty";
        public NotNullOrDefaultAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            switch (value)
            {
                case Guid guid:
                    return guid != Guid.Empty;
                default:
                    return true;
            }
        }
    }
}

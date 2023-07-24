using API.Contracts;
using System.ComponentModel.DataAnnotations;

namespace API.Utilities.Validations
{
    public class EmailDuplicatePropertyAttribute : ValidationAttribute
    {
        private readonly string _guidPropertyName;
        private readonly string _propertyName;

        public EmailDuplicatePropertyAttribute(string guidPropertyName, string propertyName)
        {
            _guidPropertyName = guidPropertyName;
            _propertyName = propertyName;
        }

        /*
         * <summary>
         * This method is used to validate the uniqueness of the email and phone number.
         * </summary>
         * <param name="value">The value of the property to validate.</param>
         * <param name="validationContext">The context information about the validation operation.</param>
         * <returns>ValidationResult</returns>
         * <remarks>
         * This method will check if email and phone number is exist or not
         * </remarks>
         */
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return ValidationResult.Success;

            var accountRepository = (IAccountRepository)validationContext.GetService(typeof(IAccountRepository))!;
            var guidProperty = validationContext.ObjectType.GetProperty(_guidPropertyName);
            var guidValue = guidProperty?.GetValue(validationContext.ObjectInstance, null) as Guid?;
            //Console.WriteLine("value : " + value);
            //Console.WriteLine("employee repository : " + accountRepository);
            var entity = accountRepository?.GetByEmail(value.ToString());
            if (entity is null) return ValidationResult.Success;
            return (entity.Guid == guidValue ? ValidationResult.Success : new ValidationResult($"{_propertyName} '{value}' already exists."))!;
        }
    }
}

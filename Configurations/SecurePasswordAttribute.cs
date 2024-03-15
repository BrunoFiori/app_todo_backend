using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace App_Todo_Backend.Configurations
{
    public class SecurePasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Senha é obrigatorio.");
            }

            var password = value.ToString();

            // A senha deve ter pelo menos 8 caracteres, pelo menos 1 letra maiúscula, 1 letra minúscula e 1 caractere especial.
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$"))
            {
                return new ValidationResult("A senha deve conter ao menos 8 caracteres, 1 caracter maiúsculo e 1 caracter especial (!,@,#,$,%,¨,&,*)");
            }

            return ValidationResult.Success;
        }
    }
}

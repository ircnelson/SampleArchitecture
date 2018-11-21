using FluentValidation;
using FluentValidation.Validators;

namespace SampleArchitecture.Application.Validators
{
    public class CpfCnpjValidator : PropertyValidator
    {
        public CpfCnpjValidator() : base("{PropertyName}")
        {
            
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return true;
        }
    }

    public static class FluentValidatorCustomExtensions
    {
        public static IRuleBuilderOptions<T, string> CpfCnpj<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CpfCnpjValidator());
        }
    }
}
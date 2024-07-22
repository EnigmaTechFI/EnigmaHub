using EnigmaHub.Domain.Constants;
using EnigmaHub.Domain.Context;
using EnigmaHub.Domain.Dto;
using FluentValidation;
using NLog;

namespace EnigmaHub.Validator;

public class CustomerMarketingDataValidator : AbstractValidator<CustomerMarketingData>
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public CustomerMarketingDataValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("L'email non può essere vuota.")
            .WithErrorCode(Error.CustomError.EMPTY_FIELD.ToString())
            .NotNull().WithMessage("L'email non può essere vuota.")
            .WithErrorCode(Error.CustomError.EMPTY_FIELD.ToString())
            .EmailAddress().WithMessage("L'email deve essere un indirizzo valido.")
            .WithErrorCode(Error.CustomError.EMAIL_NOT_CORRECT.ToString());
        
        RuleFor(user => user.Phone)
            .NotEmpty().WithMessage("Il numero di telefono non può essere vuoto.")
            .WithErrorCode(Error.CustomError.EMPTY_FIELD.ToString())
            .NotNull().WithMessage("Il numero di telefono non può essere vuoto.")
            .WithErrorCode(Error.CustomError.EMPTY_FIELD.ToString())
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Il numero di telefono deve essere un numero valido.")
            .WithErrorCode(Error.CustomError.PHONE_NOT_CORRECT.ToString());
    }

    public async Task<ResultDto> Validator(CustomerMarketingData customerMarketingData)
    {
        try
        {
            var dataValidation = await ValidateAsync(customerMarketingData);
            if (!dataValidation.IsValid)
                return new ResultDto(
                    false,
                    dataValidation.Errors.Select(s => $"{s.ErrorMessage}").FirstOrDefault(),
                    (Enum.Parse<Error.CustomError>(dataValidation.Errors.Select(s => $"{s.ErrorCode}").FirstOrDefault())),
                    Error.VALIDATION_ERROR);
            return new ResultDto(true);
        }
        catch (Exception e)
        {
            Logger.Error(e, $"Errore durante la validazione dei dati cliente");
            return new ResultDto(
                false,
                "Fatal error",
                (Error.CustomError.GENERAL),
                Error.VALIDATION_ERROR);
        }
    }
}
namespace EnigmaHub.Domain.Constants;

public class Error
{

    public enum CustomError
    {
        GENERAL = -1,
        NOERROR,
        DB_RAW_NOT_FOUND,
        UNAUTHORIZED,
        DELETE_ERROR_REFERENCE,
        
        /*INPUT VALIDATOR ERROR*/
        EMPTY_FIELD = 10,
        EMPTY_OBJECT,
        MAX_LIMIT_FIELD,
        MIN_LIMIT_FIELD,
        LENGTH_LIMIT_FIELD,
        VALUE_NOT_CORRECT,
        EMAIL_NOT_CORRECT,
        PHONE_NOT_CORRECT,
        DATE_NOT_CORRECT,
        VALUE_ALREADY_PRESENT,
        
        /*MEDIA VALIDATOR ERROR*/
        MEDIA_EXTENSION_NOT_SUPPORTED = 20,
        
        /*STRIPE ERROR*/
        VALIDATE_ACCOUNT_STRIPE = 40,
        EMPTY_FIELD_STRIPE,
    }

    public const string VALIDATION_ERROR = "VALIDATION_ERROR";
    public const string AJAX_ERROR = "AJAX_ERROR";
    public const string SQL_INSERT_ERROR = "SQL_INSERT_ERROR";
    public const string SQL_UPDATE_ERROR = "SQL_UPDATE_ERROR";
    public const string SQL_GET_ERROR = "SQL_GET_ERROR";
    public const string SQL_DELETE_ERROR = "SQL_DELETE_ERROR";
    public const string FORM_ERROR = "FORM_ERROR";
    public const string AUTH_ERROR = "AUTH_ERROR";
    public const string EMAIL_ERROR = "EMAIL_ERROR";
    public const string PHONE_ERROR = "PHONE_ERROR";
    public const string API_ERROR = "API_ERROR";
}
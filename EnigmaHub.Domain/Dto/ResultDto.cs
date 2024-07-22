using EnigmaHub.Domain.Constants;

namespace EnigmaHub.Domain.Dto;

public class ResultDto
{
    public ResultDto(bool success, string message, Error.CustomError desc, string type)
    {
        Error = new ErrorDto(message, desc, type);
        Success = success;
    }

    public ResultDto(bool success) : this(success, "", Constants.Error.CustomError.NOERROR, ""){}

    public bool Success { get; set; }
    public ErrorDto Error { get; set; }
}

public class ErrorDto
{
    public ErrorDto(string message, Error.CustomError enumDesc, string type)
    {
        Message = message;
        EnumDesc = enumDesc;
        Type = type;
    }
    
    public string Message { get; set; }
    public Error.CustomError EnumDesc { get; set; }
    public int Code => (int)EnumDesc;
    public string Type { get; set; }
    public string Log => $"ERR{Code}: {Message}";
}
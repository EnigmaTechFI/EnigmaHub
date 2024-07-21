using EliteDomus.Domain.Constants;

namespace EliteDomus.Domain.Dto;

public class ResultDto
{
    public ResultDto(bool success, string message, EliteDomusError.CustomError desc, string type)
    {
        Error = new ErrorDto(message, desc, type);
        Success = success;
    }

    public ResultDto(bool success) : this(success, "", Domain.Constants.EliteDomusError.CustomError.NOERROR, ""){}

    public bool Success { get; set; }
    public ErrorDto Error { get; set; }
}

public class ErrorDto
{
    public ErrorDto(string message, EliteDomusError.CustomError enumDesc, string type)
    {
        Message = message;
        EnumDesc = enumDesc;
        Type = type;
    }
    
    public string Message { get; set; }
    public EliteDomusError.CustomError EnumDesc { get; set; }
    public int Code => (int)EnumDesc;
    public string Type { get; set; }
    public string Log => $"ERR{Code}: {Message}";
}
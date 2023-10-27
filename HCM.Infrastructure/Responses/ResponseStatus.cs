namespace HCM.Infrastructure.Responses;

public class ResponseStatus
{
    public bool IsSuccess { get; set; }

    public string? Message { get; set; }

    public static ResponseStatus Error(string message)
    {
        return new ResponseStatus { IsSuccess = false, Message = message };
    }

    public static ResponseStatus Success()
    {
        return new ResponseStatus { IsSuccess = true };
    }
}
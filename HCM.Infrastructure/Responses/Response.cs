﻿namespace HCM.Infrastructure.Responses;

using Microsoft.AspNetCore.Http;

public class Response
{
    public static IResult OkData<T>(T payload, string? error = null)
    {
        ResponseStatus status = CheckStatus(error!);

        return Results.Ok(new DataResponse<T>(payload, status));
    }

    public static IResult OkPage<T>(
        List<T> payload,
        int page,
        int pageSize,
        int pageNumber,
        string? error = null)
        where T : class
    {
        ResponseStatus status = CheckStatus(error!);

        PageMetadata pageInfo = new()
        {
            Page = page,
            PageSize = pageSize,
            PageNumber = pageNumber
        };

        return Results.Ok(new PagedDataResponse<T>(payload, pageInfo, status));
    }

    public static IResult NotFound(string message, params string[] parameters)
    {
        return Results.NotFound(new BaseResponse(ResponseStatus.Error(string.Format(message, parameters))));
    }

    public static IResult BadRequest(string message, params string[] parameters)
    {
        return Results.BadRequest(new BaseResponse(ResponseStatus.Error(string.Format(message, parameters))));
    }

    public static IResult Ok()
    {
        return Results.Ok(new BaseResponse(ResponseStatus.Success()));
    }

    private static ResponseStatus CheckStatus(string error)
    {
        ResponseStatus status;

        if (error is not null)
        {
            status = ResponseStatus.Error(error);
        }
        else
        {
            status = ResponseStatus.Success();
        }

        return status;
    }
}
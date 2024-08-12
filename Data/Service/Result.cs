// using Service.Data.Context;
using Service.Data.Model;
using Service.Data.Request;
using Service.Data.Response;
// using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Data.Services;

public class Result
{
    public bool Success { get; set; }
    public string? Message { get; set; }
}

public class Result<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}
using app.Dto;
using app.Service;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOperationService, OperationService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapPost("/calculate", (IOperationService service, OperationRequest request) => service.Calculate(request));

app.Run();


[ExcludeFromCodeCoverage]
public static partial class Program {}
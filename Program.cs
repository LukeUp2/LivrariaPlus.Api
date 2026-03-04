using System.Text.Json.Serialization;
using LivrariaPlus.Api.Extensions;
using LivrariaPlus.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add<ExceptionFilter>();
    })
    .AddJsonOptions(options =>
    {
        // Garante que o conversor de string para Enum está ativo
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);

builder.Services.ConfigureHttpJsonOptions(opt =>
{
    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

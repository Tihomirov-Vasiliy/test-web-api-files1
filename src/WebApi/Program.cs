using WebApi.CustomExceptionMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Add services from service layer
builder.Services.AddServiceLayerServices(builder.Configuration);
//Add services from web api layer
builder.Services.AddWebApiServices(builder.Configuration);

var app = builder.Build();

//Add global Exception handler custom middleware
app.UseMiddleware(typeof(ExceptionMiddleware));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

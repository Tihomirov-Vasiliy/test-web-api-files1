using WebApi.CustomExceptionMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add services from application layer
builder.Services.AddApplicationServices();
//Add services from service layer
builder.Services.AddServiceLayerServices(builder.Configuration);

var app = builder.Build();

//Add global Exception handler custom middleware
app.UseMiddleware(typeof(ExceptionMiddleware));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

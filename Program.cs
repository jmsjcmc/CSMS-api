using Csms_api;
using Csms_api.Extensions;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.ScopeService();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

builder.Services.AddDbContext<AppDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddCustomCors();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpContextAccessor();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();

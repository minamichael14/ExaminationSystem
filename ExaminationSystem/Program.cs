using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ExaminationSystem.Config;
using ExaminationSystem.Data;
using ExaminationSystem.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule(new AutofacModule());
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var key = Encoding.UTF8.GetBytes(Constants.SecretKey);
builder.Services.AddAuthentication(opts => 
{
    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts=>
{
    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = Constants.JWTIssuer,
        ValidateIssuer = true,

        ValidAudience = Constants.JWTAudience,
        ValidateAudience = true,

        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuerSigningKey = true,

        ValidateLifetime = true
    };
});


builder.Services.AddAuthorization();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<GlobalErrorHandlerMiddleware>();

app.Run();

using Business.DependencyResolvers;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TokenOptions = Core.Utilities.Security.JWT.TokenOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

TokenOptions tokenOptions =builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true, // Issuer'� validate etmeli mi?
            ValidateAudience = true,// Audience'� validate etmeli mi?
            ValidateLifetime = true, // S�reyi validate etmeli mi?
            ValidateIssuerSigningKey = true, // Security key validate etmeli mi?
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)), // Valid security key de�eri
            ValidIssuer = tokenOptions.Issuer,// Valid Issuer de�eri
            ValidAudience = tokenOptions.Audience,// Valid Audience de�eri

        };
    });
var app = builder.Build();

app.UseGlobalExtensionHandling();

// Configure the HTTP request pipeline.
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

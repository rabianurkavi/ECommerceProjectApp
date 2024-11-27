using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Mapping;
using Core.Helpers.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer �emas�n� kullanan JWT Yetkilendirme ba�lad� \r\n\r\n 'Bearer' [bo�luk] girin ve token� yaz�n�z. "
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[] {}
        }
    });
});


#region JWT
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Authentication ve JWT ayarlar�
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.SecurityKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // E�er issuer kontrol� yapmak isterseniz true yap�n
        ValidateAudience = false, // Audience kontrol� yoksa false b�rak�n
        ValidateLifetime = true, // Token s�resini do�rular
        ValidateIssuerSigningKey = true, // Security key do�rulamas�
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
#endregion
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDal, EfUserDal>();

builder.Services.AddDbContext<ECommerceProjectAppDbContext>();
MapsterConfig.RegisterMappings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API V1");
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

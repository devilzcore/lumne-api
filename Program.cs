using System.Net;
using System.Text.Json.Serialization;
using dotnet_angular_blog.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.WebHost.ConfigureKestrel(serverOptions =>
{
  serverOptions.Listen(IPAddress.Any, 7257);
});

builder.Services.AddDbContext<BlogContext>(opt =>
  opt.UseMySQL(builder.Configuration.GetConnectionString("BlogDbConnection")));

builder.Services.AddDbContext<UserContext>(opt =>
opt.UseMySQL(builder.Configuration.GetConnectionString("BlogDbConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
  options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddControllers().AddJsonOptions(x =>
  x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<UserContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
  options.SaveToken = true;
  options.RequireHttpsMetadata = false;
  options.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidAudience = configuration["JWT:ValidAudience"],
    ValidIssuer = configuration["JWT:ValidIssuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
  };
});

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
  builder.AllowAnyOrigin()
  .AllowAnyMethod()
  .AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("MyPolicy");

app.Run();

using Domain;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using update.Mapper;
using update.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependecy inyection
builder.Services.AddScoped<IUserInfrastructure, UserInfrastructure>();
builder.Services.AddScoped<IUserDomain, UserDomain>();

builder.Services.AddScoped<IActivityInfrastructure, ActivityInfrastructure>();
builder.Services.AddScoped<IActivityDomain, ActivityDomain>();

builder.Services.AddScoped<ICommunityInfrastructure, CommunityInfrastructure>();
builder.Services.AddScoped<ICommunityDomain, CommunityDomain>();

builder.Services.AddScoped<IParticipationInfrastructure, ParticipationInfrastructure>();
builder.Services.AddScoped<IParticipationDomain, ParticipationDomain>();

builder.Services.AddScoped<ILocationInfrastructure, LocationInfrastructure>();
builder.Services.AddScoped<ILocationDomain, LocationDomain>();

builder.Services.AddScoped<IRoleInfrastructure, RoleInfrastructure>();
builder.Services.AddScoped<IRoleDomain, RoleDomain>();

builder.Services.AddScoped<IEncryptDomain, EncryptDomain>();
builder.Services.AddScoped<ITokenDomain, TokenDomain>();

builder.Services.AddScoped<ICommunityMemberInfrastructure, CommunityMemberInfrastructure>();
builder.Services.AddScoped<ICommunityMemberDomain, CommunityMemberDomain>();

//Conexion a MySQL 
var connectionString = builder.Configuration.GetConnectionString("upDateConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

/*builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));*/

builder.Services.AddDbContext<UpdateDbContext>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

builder.Services.AddAutoMapper(
    typeof(ModelToResponse),
    typeof(InputToModel)
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<UpdateDbContext>())
{
    context.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cors
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
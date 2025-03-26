using Assignment_2;
using Business.Models;
using DataAccess.DAO;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepository;
using Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FunewsManagementContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("FUNewsManagementDB")));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});

builder.Services.AddScoped<AccountDAO>();
builder.Services.AddScoped<AdminDAO>();
builder.Services.AddScoped<StaffDAO>();

builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.MapHub<ArticleHub>("/articleHub");
app.UseAuthorization();

app.MapRazorPages();

app.Run();

using Application;
using ApplicationEntry;
using ApplicationEntry.CommandDispatcherImpls;
using ApplicationEntry.QueryDispatcherImpls;
using BlazorServerUI.Popups;
using BlazorServerUI.StateContainers.Profile;
using JsonData;
using Microsoft.AspNetCore.Authentication.Negotiate;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add custom services
{
    {
        // add dispatchers
        builder.Services.AddScoped<ICommandDispatcher, CommandDispatcherWithServiceProvider>();
        builder.Services.AddScoped<IQueryDispatcher, QueryDispatcherWithServiceProvider>();
    }
    
    {
        // add layers
        builder.Services.AddApplicationLayerServices();
        builder.Services.AddJsonDataAccess();
    }

    {
        // blazor services
        builder.Services.AddScoped<SnackBarHandler>();
        builder.Services.AddScoped<ProfileStateContainer>();
    }
}
// End custom services

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/ExceptionPage");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
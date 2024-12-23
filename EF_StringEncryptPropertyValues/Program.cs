using EF_StringEncryptPropertyValues.Classes;
using EF_StringEncryptPropertyValues.Data;
using EF_StringEncryptPropertyValues.Models;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static ConfigurationLibrary.Classes.ConfigurationHelper;
using MiscSettings = EF_StringEncryptPropertyValues.Models.MiscSettings;

namespace EF_StringEncryptPropertyValues;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        SetupLogging.Development();

        
        builder.Services.AddOptions<ConnectionStrings>()
            .BindConfiguration(nameof(ConnectionStrings))
            .ValidateDataAnnotations()
            .Validate(connections =>
            {
                if (string.IsNullOrEmpty(connections.DefaultConnection))
                {
                    return false;
                }

                SqlConnectionStringBuilder ssb = new(connections.DefaultConnection);

                using var cn = new SqlConnection(ssb.ConnectionString);

                try
                {
                    cn.Open();
                    return true;
                }
                catch 
                {
                    return false;
                }

            }, "Invalid connection string")
            .ValidateOnStart();

        builder.Services.Configure<MiscSettings>(nameof(MiscSettings),
            builder.Configuration.GetSection(nameof(MiscSettings)));

        builder.Services.AddOptions<List<MiscSettings>>()
            .BindConfiguration(nameof(MiscSettings))
            .Validate(settings =>
            {

                // get count of items
                var itemCount = ConfigurationRoot()
                    .GetSection(nameof(MiscSettings))
                    .GetChildren().Count();
                /*
                 * When reading in items, if TheEnum can not convert its left out
                 */
                return settings.Count == itemCount;
            }, $"Invalid count of {nameof(MiscSettings)}")
            .ValidateOnStart();


        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging());

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }

}

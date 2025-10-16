
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;

namespace RecipeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var cs = builder.Configuration.GetConnectionString("RecipeDb");
            Console.WriteLine($"[Startup] RecipeDb CS: {cs}");
            builder.Services.AddDbContext<RecipeDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("RecipeDb")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<RecipeRepository>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<RecipeDbContext>();
                dbContext.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

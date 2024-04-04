using ResAccess.DTO;
using ResAccess.Implementations;
using ResAccess.Interfaces;

namespace ResAccess.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IResAccessManager, ResAccessManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.Map("/api/requests", (GetAccessStatusRequest req) =>
            //{
            //    if (req.Resource != "res") 
            //    {
            //        return Results.BadRequest(new { message = "Invalid age" });
            //    }

            //    return Results.NotFound();
            //});
            app.MapControllers();

            app.Run();
        }
    }
}

using Microsoft.AspNetCore.Builder;

namespace SistemaCompra.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prova Sisprev V1");
            });
        }
    }
}

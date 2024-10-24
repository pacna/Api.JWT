namespace Api.JWT.StartupExtensions;

internal static class ApplicationBuilderExtension
{
    internal static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder application, bool isDev)
    {
        if (isDev)
        {
            return application
                    .UseSwagger()
                    .UseSwaggerUI(options => 
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api.JWT");
                        options.RoutePrefix =  string.Empty;
                    });
        }

        return application;
    }
}
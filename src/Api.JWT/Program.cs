using Api.JWT.Settings;
using Api.JWT.StartupExtensions;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
ApplicationSetting setting = ApplicationParser.Parse(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddCustomMediatR()
    .AddSwaggerDoc()
    .AddSetting(setting)
    .AddContexts()
    .AddServices()
    .AddRepositories()
    .AddCustomControllers()
    .AddControllerConvention()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

WebApplication? app = builder.Build();

app
    .UseCustomSwagger(app.Environment.IsDevelopment()) // Configure the HTTP request pipeline.
    .UseHttpsRedirection();

app
    .MapControllers()
    .WithOpenApi();

app.Run();

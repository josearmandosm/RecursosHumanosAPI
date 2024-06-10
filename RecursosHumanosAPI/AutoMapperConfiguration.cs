using RecursosHumanosAPI;

public class AutoMapperConfiguration
{
    public static void Configure(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Startup));
    }
}

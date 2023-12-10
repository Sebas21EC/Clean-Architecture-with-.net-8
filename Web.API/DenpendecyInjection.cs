namespace Web.API
{
    public static class DenpendencyInjection
    {
      
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

            return services;
        }
       
    }
}

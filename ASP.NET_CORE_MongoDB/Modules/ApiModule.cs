using ASP.NET_CORE_MongoDB.Builders;
using ASP.NET_CORE_MongoDB.Handlers;
using ASP.NET_CORE_MongoDB.Mappers;
using ASP.NET_CORE_MongoDB.Repositories;
using ASP.NET_CORE_MongoDB.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace ASP.NET_CORE_MongoDB.Modules
{
    public static class ApiModule
    {
        public static void AddDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient>(x => new MongoClient(configuration.GetConnectionString("MongoDB")));
            services.AddScoped(x => x.GetService<IMongoClient>().StartSession());

            services.AddScoped<IPeopleCreateCommandHandler, PeopleCreateCommandHandler>();
            services.AddScoped<IPeopleUpdateCommandHandler, PeopleUpdateCommandHandler>();
            services.AddScoped<IPeopleRemoveCommandHandler, PeopleRemoveCommandHandler>();
            services.AddScoped<IPeopleRemoveLogicCommandHandler, PeopleRemoveLogicCommandHandler>();
            
            services.AddScoped<IPeopleService, PeopleService>();

            services.AddScoped<IPeopleMapper, PeopleMapper>();
            
            services.AddScoped<IBuildPeopleFilter, PeopleFilterBuilder>();

            services.AddScoped<IPeopleRepository, PeopleRepository>();
        }
    }
}

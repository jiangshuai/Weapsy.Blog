﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Weapsy.Blog.Data.Configuration;

// ReSharper disable InconsistentNaming

namespace Weapsy.Blog.Data.Factories
{
    public class MSSQLDbContextFactory : IDbContextFactory
    {
        public DataProvider Provider { get; } = DataProvider.MSSQL;

        private readonly string _connectionString;

        public MSSQLDbContextFactory()
        {
            
        }

        public MSSQLDbContextFactory(IOptions<ConnectionStrings> connectionStringsOptions)
        {
            _connectionString = connectionStringsOptions.Value.BlogConnection;
        }

        public IServiceCollection RegisterDbContextFactory(IServiceCollection services)
        {
            services.AddTransient<IDbContextFactory, MSSQLDbContextFactory>();

            return services;
        }

        public IServiceCollection RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        public BlogDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new BlogDbContext(optionsBuilder.Options);
        }
    }
}
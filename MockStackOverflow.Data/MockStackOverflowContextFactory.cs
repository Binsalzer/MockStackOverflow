using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStackOverflow.Data
{
    public class MockStackOverflowContextFactory : IDesignTimeDbContextFactory<MockStackOverflowContext>
    {
        public MockStackOverflowContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}MockStackOverflow.Web"))
               .AddJsonFile("appsettings.json")
               .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new MockStackOverflowContext(config.GetConnectionString("ConStr"));
        }
    }
}

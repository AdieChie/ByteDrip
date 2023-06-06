using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.EntityFrameworkCore
{
    public static class e_commerceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<e_commerceDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<e_commerceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

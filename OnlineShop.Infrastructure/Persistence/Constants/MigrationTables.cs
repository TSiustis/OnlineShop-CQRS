using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Persistence.Constants;
public static class MigrationTables
{
    public const string WriteMigrationTable = "__WriteEFMigrationsHistory";
    public const string ReadMigrationTable = "__CssReadEFMigrationsHistory";
}

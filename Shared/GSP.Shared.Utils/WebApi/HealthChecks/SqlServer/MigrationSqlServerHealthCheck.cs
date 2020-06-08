using Dawn;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GSP.Shared.Utils.WebApi.HealthChecks.SqlServer
{
    public class MigrationSqlServerHealthCheck : IHealthCheck
    {
        private const string MigrationCheckQuery =
            "SELECT COUNT(*) FROM [dbo].[__EFMigrationsHistory] WHERE MigrationId = @migrationName";

        private readonly string _connectionString;

        private readonly string _migrationName;

        public MigrationSqlServerHealthCheck(string connectionString, string migrationName)
        {
            _connectionString =
                Guard.Argument(connectionString, nameof(connectionString)).NotNull().NotEmpty();

            _migrationName =
                Guard.Argument(migrationName, nameof(migrationName)).NotNull().NotEmpty();
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync(cancellationToken);

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = MigrationCheckQuery;

                        SqlParameter migrationNameParameter = new SqlParameter("@migrationName", SqlDbType.NVarChar)
                        {
                            Value = _migrationName
                        };

                        command.Parameters.Add(migrationNameParameter);

                        int recordCount = (int)await command.ExecuteScalarAsync(cancellationToken);

                        return recordCount > 0
                            ? HealthCheckResult.Healthy()
                            : HealthCheckResult.Unhealthy($"Migration {_migrationName} not found");
                    }
                }
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(context.Registration.FailureStatus, exception: ex);
            }
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CoreHealth6
{
    /// <summary>
    /// 数据库健康检查
    /// </summary>
    public class DatabaseHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            using (var conn = new System.Data.SqlClient.SqlConnection("Server=.;Initial Catalog=master;Integrated Security=true"))
            {
                try
                {
                    conn.Open();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy());
                }
            }
            return Task.FromResult(HealthCheckResult.Healthy());
        }
    }
}

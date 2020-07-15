using Microsoft.OpenApi.Models;
using System.Linq;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TickTime.Api.Helpers.Swagger
{
    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var versionParameter = operation.Parameters.Single(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }
}

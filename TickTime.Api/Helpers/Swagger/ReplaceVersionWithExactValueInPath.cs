using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TickTime.Api.Helpers.Swagger
{
    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags ??= new List<OpenApiTag>();
            
            var oap = new OpenApiPaths();
            foreach (var (key, value) in swaggerDoc.Paths)
                oap.Add(key.Replace("v{version}", swaggerDoc.Info.Version),
                    value);

            swaggerDoc.Paths = oap;
        }
    }
}

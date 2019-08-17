using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace NetCore.Test.SwaggerTagHelper
{
    public class SwaggerDocTag:IDocumentFilter
    {
        public SwaggerDocTag()
        {
        }

        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<Tag>
            {
                new Tag { Name = "Values", Description = "测试模块" },

            };
        }
          
    }
}

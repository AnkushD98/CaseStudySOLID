using System.Web.Http;
using WebActivatorEx;
using CaseStudyPart2;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CaseStudyPart2
{
    public static class SwaggerConfig
    {
        public static void Register()
        {

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        
                        c.SingleApiVersion("v1", "CaseStudyPart2");

                        
                    })
                .EnableSwaggerUi(c =>
                    {
                       
                    });
        }
    }
}

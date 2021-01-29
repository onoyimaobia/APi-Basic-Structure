using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace SmartaceApi.ModelHelper
{
    public  static class SwaggerConfigExtension
    {
        private const string ApiCodeDescription = @"In this API, the following codes are maintained as general codes for resources returned from the endpoints:
                                                   Success = 000. Unauthenticated = 49. ResourceAlreadyExist = 60. ResourceNoLongerInuse = 65.
                                                   NoData = 69. NoPermission = 79. BadRequest = 89. ServiceError = 99.";

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SMARTACE API",
                    Description = $"Welcome to Smartace API V1. {ApiCodeDescription}",
                    Contact = new OpenApiContact
                    {
                        Name = "Innovantics",
                        Email = string.Empty,
                        Url = new Uri("https://smartace.ng"),
                    }
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}

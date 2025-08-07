
using DocumentFormat.OpenXml.EMMA;
using Microsoft.OpenApi.Models;
using System.ComponentModel;

namespace PetHomeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //ע��Swagger������������һ���Ͷ��Swagger �ĵ�
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PetHomeAPI",
                    Description = "A simple example ASP.NET Core Web API",
                    //TermsOfService = "http:com"

                });

                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
                var xmlPath = Path.Combine(basePath, "PetHomeAPI.xml");
                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

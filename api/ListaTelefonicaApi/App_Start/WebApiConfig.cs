using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ListaTelefonicaApi
{

    public class MicrosecondEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds((long)reader.Value / 1000d);
        }
    }

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Converters.Add(new MicrosecondEpochConverter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

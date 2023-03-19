using System.Text.Json;
using System.Text.Json.Serialization;

namespace System;

public static class ApiExtensions
{
    public static IMvcBuilder AddJsonConfigurations(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        return mvcBuilder;
    }
}

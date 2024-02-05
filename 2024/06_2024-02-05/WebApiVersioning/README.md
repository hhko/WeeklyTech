# 2024년 Weekly #06 | WebApi Versioning

```cs
var apiVersioningBuilder = builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"),
        new UrlSegmentApiVersionReader());
});
```

## QueryStringApiVersionReader
```
new QueryStringApiVersionReader("api-version")
/api/StringList?api-version=1.0
Params
    api-version     1.0
```

## HeaderApiVersionReader
```
new HeaderApiVersionReader("x-Version")
/api/StringList
Headers
    x-version       2.0
```

## MediaTypeApiVersionReader
```
new MediaTypeApiVersionReader("ver")
/api/StringList
Headers
    Accept          application/json;ver=2.0
```

## UrlSegmentApiVersionReader
```
new UrlSegmentApiVersionReader()
/api/v3/StringList

[Route("api/v{version:apiVersion}/example")]
[ApiVersion("1")]
[ApiVersion("2")]
[Produces("application/json")]
[ApiController]
public class ExamplesController : ControllerBase
{
    [HttpGet]
    public string ExampleBoth()
    {
        return "same in both versions";
    }

    [MapToApiVersion("1")]
    [HttpGet("result")]
    public string ExampleV1()
    {
        return "result v1";
    }

    [MapToApiVersion("2")]
    [HttpGet("result")]
    public string ExampleV2()
    {
        return "result v2";
    }
}
```

- https://code-maze.com/aspnetcore-api-versioning/
  - Versioning 종류 설명
    ```
    Asp.Versioning.Mvc.ApiExplorer
    Asp.Versioning.Mvc
    ```
- https://infinum.com/handbook/dotnet/api/versioning
  - UrlSegmentApiVersionReader 설명
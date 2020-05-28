# Igrm.OpenSkyApi
OpenSky API .NET client implementation, please refer to https://opensky-network.org/apidoc/rest.html for more details.

Example: retrieve all planes flying now over certain area defined by latitude-longitude coordinates

```C#
using HttpClient httpClient = new HttpClient();
IOpenSkyClient client = new OpenSkyClient(httpClient);
IAllStateVectorsRequestBuilder builder = new AllStateVectorsRequestBuilder();
AllStateVectorsRequestModel request = builder.WithBoundingBox(45.8389m, 5.9962m, 47.8229m, 10.5226m).Build();
AllStateVectorsResponseModel response = await client.GetAllStateVectorsAsync(request);
```

![Nuget](https://img.shields.io/nuget/v/Igrm.OpenSkyApi)
using FastEndpoints;

namespace UgandaGeoDataApi.Features.Uganda.ViewModels
{
    public class CountySearchRequest
    {
        [QueryParam]
        public string? Name { get; set; }
    }
}

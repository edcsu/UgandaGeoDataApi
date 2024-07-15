using FastEndpoints;

namespace UgandaGeoDataApi.Features.Uganda.ViewModels
{
    public class SubCountySearchRequest
    {
        [QueryParam]
        public string? Name { get; set; }
    }
}

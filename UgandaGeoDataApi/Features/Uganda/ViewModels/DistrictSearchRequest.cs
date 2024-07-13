using FastEndpoints;

namespace UgandaGeoDataApi.Features.Uganda.ViewModels
{
    public class DistrictSearchRequest
    {
        [QueryParam]
        public string? Name { get; set; }
    }
}

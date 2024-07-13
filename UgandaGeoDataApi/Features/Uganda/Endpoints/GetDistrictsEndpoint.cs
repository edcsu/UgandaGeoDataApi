using FastEndpoints;
using UgandaGeoDataApi.Features.Uganda.Models;
using UgandaGeoDataApi.Features.Uganda.Services;
using UgandaGeoDataApi.Features.Uganda.ViewModels;

namespace UgandaGeoDataApi.Features.Uganda.Endpoints
{
    public class GetDistrictsEndpoint : Endpoint<DistrictSearchRequest, IEnumerable<DistrictViewModel>>
    {
        public JsonFileService FileService { get; set; }

        public override void Configure()
        {
            Get("/api/districts");
            AllowAnonymous();
            Description(b => b
            .ProducesProblemDetails(400, "application/json+problem") //if using RFC errors 
            .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(DistrictSearchRequest req, CancellationToken ct)
        {
            var districts = FileService.GetDistricts();

            List<DistrictViewModel> viewModels = [];
            foreach (var district in districts)
            {
                viewModels.Add(MapFromEntity(district));
            };

            await SendAsync(viewModels, cancellation: ct);
        }

        public DistrictViewModel MapFromEntity(District district) => new()
        {
            Id = district.Id,
            Name = district.Name,
        };
    }
}

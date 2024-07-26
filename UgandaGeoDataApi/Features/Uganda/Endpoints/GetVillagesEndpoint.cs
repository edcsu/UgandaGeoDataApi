using FastEndpoints;
using UgandaGeoDataApi.Features.Uganda.Models;
using UgandaGeoDataApi.Features.Uganda.Services;
using UgandaGeoDataApi.Features.Uganda.ViewModels;

namespace UgandaGeoDataApi.Features.Uganda.Endpoints
{
    public class GetVillagesEndpoint : Endpoint<VillageSearchRequest, IEnumerable<VillageViewModel>>
    {
        public required JsonFileService FileService { get; set; }
        
        public override void Configure()
        {
            Get("/api/villages");
            AllowAnonymous();
            Description(b => b
            .ProducesProblemDetails(400, "application/json+problem") //if using RFC errors 
            .ProducesProblemFE<InternalErrorResponse>(500));
            Options(x => x.WithTags("Villages"));
        }

        public override async Task HandleAsync(VillageSearchRequest req, CancellationToken ct)
        {
            var villages = FileService.GetVillages(req);
            
            List<VillageViewModel> viewModels = [];
            foreach (var village in villages)
            {
                viewModels.Add(MapFromEntity(village));
            };

            await SendAsync(viewModels, cancellation: ct);
        }

        public VillageViewModel MapFromEntity(Village village) => new()
        {
            Id = village.Id,
            Name = village.Name,
            Parish = village.Parish,
        };
    }
}

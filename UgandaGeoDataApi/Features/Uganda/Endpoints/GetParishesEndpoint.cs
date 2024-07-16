using FastEndpoints;
using UgandaGeoDataApi.Features.Uganda.Models;
using UgandaGeoDataApi.Features.Uganda.Services;
using UgandaGeoDataApi.Features.Uganda.ViewModels;

namespace UgandaGeoDataApi.Features.Uganda.Endpoints
{
    public class GetParishesEndpoint : Endpoint<ParishSearchRequest, IEnumerable<ParishViewModel>>
    {
        public required JsonFileService FileService { get; set; }
        
        public override void Configure()
        {
            Get("/api/parishes");
            AllowAnonymous();
            Description(b => b
            .ProducesProblemDetails(400, "application/json+problem") //if using RFC errors 
            .ProducesProblemFE<InternalErrorResponse>(500));
        }

        public override async Task HandleAsync(ParishSearchRequest req, CancellationToken ct)
        {
            var parishes = FileService.GetParishes();
            
            List<ParishViewModel> viewModels = [];
            foreach (var parish in parishes)
            {
                viewModels.Add(MapFromEntity(parish));
            };

            await SendAsync(viewModels, cancellation: ct);
        }

        public ParishViewModel MapFromEntity(Parish parish) => new()
        {
            Id = parish.Id,
            Name = parish.Name,
            Subcounty = parish.Subcounty,
        };
    }
}

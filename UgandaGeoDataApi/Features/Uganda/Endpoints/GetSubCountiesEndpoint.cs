using FastEndpoints;
using UgandaGeoDataApi.Features.Uganda.Models;
using UgandaGeoDataApi.Features.Uganda.Services;
using UgandaGeoDataApi.Features.Uganda.ViewModels;

namespace UgandaGeoDataApi.Features.Uganda.Endpoints
{
    public class GetSubCountiesEndpoint : Endpoint<SubCountySearchRequest, IEnumerable<SubCountyViewModel>>
    {
        public required JsonFileService FileService { get; set; }
        
        public override void Configure()
        {
            Get("/api/subcounties");
            AllowAnonymous();
            Description(b => b
            .ProducesProblemDetails(400, "application/json+problem") //if using RFC errors 
            .ProducesProblemFE<InternalErrorResponse>(500));
            Options(x => x.WithTags("SubCounties"));
        }

        public override async Task HandleAsync(SubCountySearchRequest req, CancellationToken ct)
        {
            var subCounties = FileService.GetSubCounties();
            
            List<SubCountyViewModel> viewModels = [];
            foreach (var subCounty in subCounties)
            {
                viewModels.Add(MapFromEntity(subCounty));
            };

            await SendAsync(viewModels, cancellation: ct);
        }

        public SubCountyViewModel MapFromEntity(SubCounty subCounty) => new()
        {
            Id = subCounty.Id,
            Name = subCounty.Name,
            County = subCounty.County,
        };
    }
}

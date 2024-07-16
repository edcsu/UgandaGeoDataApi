using FastEndpoints;
using UgandaGeoDataApi.Features.Uganda.Models;
using UgandaGeoDataApi.Features.Uganda.Services;
using UgandaGeoDataApi.Features.Uganda.ViewModels;

namespace UgandaGeoDataApi.Features.Uganda.Endpoints
{
    public class GetCountiesEndpoint : Endpoint<CountySearchRequest, IEnumerable<CountyViewModel>>
    {
        public required JsonFileService FileService { get; set; }
        
        public override void Configure()
        {
            Get("/api/counties");
            AllowAnonymous();
            Description(b => b
            .ProducesProblemDetails(400, "application/json+problem") //if using RFC errors 
            .ProducesProblemFE<InternalErrorResponse>(500));
            Options(x => x.WithTags("Counties"));
        }

        public override async Task HandleAsync(CountySearchRequest req, CancellationToken ct)
        {
            var counties = FileService.GetCounties();
            
            List<CountyViewModel> viewModels = [];
            foreach (var County in counties)
            {
                viewModels.Add(MapFromEntity(County));
            };

            await SendAsync(viewModels, cancellation: ct);
        }

        public CountyViewModel MapFromEntity(County County) => new()
        {
            Id = County.Id,
            Name = County.Name,
            District = County.District,
        };
    }
}

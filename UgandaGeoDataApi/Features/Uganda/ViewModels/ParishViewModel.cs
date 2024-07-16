using System.Text.Json;

namespace UgandaGeoDataApi.Features.Uganda.ViewModels
{
    public class ParishViewModel
    {
        public string Id { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Subcounty { get; set; } = default!;

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}

﻿using System.Text.Json;

namespace UgandaGeoDataApi.Features.Uganda.Models
{
    public class County
    {
        public string Id { get; set; } = default!;
        
        public string Name { get; set; } = default!;
        
        public string District { get; set; } = default!;

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}

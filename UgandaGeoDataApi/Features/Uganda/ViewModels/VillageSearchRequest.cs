﻿using FastEndpoints;

namespace UgandaGeoDataApi.Features.Uganda.ViewModels
{
    public class VillageSearchRequest
    {
        [QueryParam]
        public string? Name { get; set; }
    }
}

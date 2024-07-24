using System.Text.Json;
using UgandaGeoDataApi.Features.Uganda.Models;
using UgandaGeoDataApi.Features.Uganda.ViewModels;

namespace UgandaGeoDataApi.Features.Uganda.Services
{
    public class JsonFileService
    {
        public JsonFileService(IWebHostEnvironment webHostEnvironment) 
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string VillagesFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "Features", "Uganda", "Repositories", "villages.json"); }
        }
        
        private string ParishesFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "Features", "Uganda", "Repositories", "parishes.json"); }
        }
        
        private string SubCountiesFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "Features", "Uganda", "Repositories", "subcounties.json"); }
        }
        
        private string CountiesFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "Features", "Uganda", "Repositories", "counties.json"); }
        }
        
        private string DistrictsFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "Features", "Uganda", "Repositories", "districts.json"); }
        }

        private readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public IEnumerable<District> GetDistricts(DistrictSearchRequest districtSearchRequest)
        {
            using StreamReader streamReader = new(DistrictsFileName);
            var json = streamReader.ReadToEnd();
            var districts = JsonSerializer.Deserialize<IEnumerable<District>>(json, Options) ?? [];
            if (string.IsNullOrWhiteSpace(districtSearchRequest.Name))
            {
                return districts;
            }
            else
            {
                return districts.Where(it => it.Name.Contains(districtSearchRequest.Name));
            }
        }

        public IEnumerable<County> GetCounties(CountySearchRequest countySearchRequest)
        {
            using StreamReader streamReader = new(CountiesFileName);
            var json = streamReader.ReadToEnd();
            var counties = JsonSerializer.Deserialize<IEnumerable<County>>(json, Options) ?? [];
            if(string.IsNullOrWhiteSpace(countySearchRequest.Name)) 
            { 
                return counties; 
            } 
            else 
            { 
                return counties.Where(it => it.Name.Contains(countySearchRequest.Name));
            }
        }

        public IEnumerable<SubCounty> GetSubCounties(SubCountySearchRequest subCountySearchRequest)
        {
            using StreamReader streamReader = new(SubCountiesFileName);
            var json = streamReader.ReadToEnd();
            var subCounties = JsonSerializer.Deserialize<IEnumerable<SubCounty>>(json, Options) ?? [];
            if (string.IsNullOrWhiteSpace(subCountySearchRequest.Name))
            {
                return subCounties;
            }
            else 
            {
                return subCounties.Where(it => it.Name.Contains(subCountySearchRequest.Name));
            }
        }

        public IEnumerable<Parish> GetParishes(ParishSearchRequest parishSearchRequest)
        {
            using StreamReader streamReader = new(ParishesFileName);
            var json = streamReader.ReadToEnd();
            var parishes = JsonSerializer.Deserialize<IEnumerable<Parish>>(json, Options) ?? [];
            if (string.IsNullOrWhiteSpace(parishSearchRequest.Name))
            {
                return parishes;
            }
            else 
            {
                return parishes.Where(it => it.Name.Contains(parishSearchRequest.Name));
            }
        }

        public IEnumerable<Village> GetVillages()
        {
            using StreamReader streamReader = new(VillagesFileName);
            var json = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<IEnumerable<Village>>(json, Options) ?? [];
        }
    }
}

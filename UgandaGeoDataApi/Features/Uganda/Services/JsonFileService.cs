using System.Text.Json;
using UgandaGeoDataApi.Features.Uganda.Models;

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

        public IEnumerable<District> GetDistricts()
        {
            using StreamReader streamReader = new(DistrictsFileName);
            var json = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<IEnumerable<District>>(json, Options) ?? [];
        }

        public IEnumerable<County> GetCounties()
        {
            using StreamReader streamReader = new(CountiesFileName);
            var json = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<IEnumerable<County>>(json, Options) ?? [];
        }

        public IEnumerable<SubCounty> GetSubCounties()
        {
            using StreamReader streamReader = new(SubCountiesFileName);
            var json = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<IEnumerable<SubCounty>>(json, Options) ?? [];
        }

        public IEnumerable<Parish> GetParishes()
        {
            using StreamReader streamReader = new(ParishesFileName);
            var json = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<IEnumerable<Parish>>(json, Options) ?? [];
        }

        public IEnumerable<Village> GetProducts()
        {
            using StreamReader streamReader = new(VillagesFileName);
            var json = streamReader.ReadToEnd();
            return JsonSerializer.Deserialize<IEnumerable<Village>>(json, Options) ?? [];
        }
    }
}

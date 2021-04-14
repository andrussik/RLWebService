using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DAL.Solr.Repositories.Contracts;
using DTO.SearchEngine;
using LuceneExtensions.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SolrNet;

namespace DAL.Solr.Repositories.App
{
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        private readonly ISolrOperations<Publication> _solr;
        public PublicationRepository(ISolrOperations<Publication> solr, IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _solr = solr;
        }

        private IEnumerable<JObject> CreateDocuments<T>(IEnumerable<T> objs)
        {
            var result = new List<JObject>();

            foreach (var obj in objs)
            {
                var json = JsonConvert.SerializeObject(obj);
                var jObject = JObject.FromObject(obj!);
                jObject.Add("Json", json);
                result.Add(jObject);
            }

            return result;
        }

        private IEnumerable<T> GetDocuments<T>(IEnumerable<string> jsons)
        {
            var result = new List<T>();
            foreach (var json in jsons)
            {
                var obj = JsonConvert.DeserializeObject<T>(json);
                result.Add(obj);
            }
            
            return result;
        }
        
        public async Task AddRangeAsync<T>(string index, IEnumerable<T> publications)
        {
            var idPropertyName = IdProperty.GetIdPropertyName<T>();
            var urlString = $"{index}/update/json/docs?commit=true&f=$FQN:/**&f=id:/{idPropertyName}";
            var documents = CreateDocuments(publications);
            var json = JsonConvert.SerializeObject(documents);
            var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            
            await _httpClient.PostAsync(urlString, content);
        }

        public async Task<IEnumerable<Publication>> FuzzySearchAsync(string searchString)
        {
            var searchStrings = searchString
                .Split(" ")
                .Select(s => s + "~").ToList();
            var joinTitleString = string
                .Join(" ", searchStrings.Select(s => "Title:" + s));
            var joinAuthorString = string
                .Join(" ", searchStrings.Select(s => "Author:" + s));
            var query = $"{joinTitleString} {joinAuthorString}";
            
            var urlString = $"publication_core/query?q={query}&rows=10&fl=Json&wt=json.nl";
            var itemResponse = await _httpClient.GetFromJsonAsync<QueryResponse>(urlString);
            var jsons = itemResponse?.Response?.Docs
                ?.Select(doc => doc.Json) ?? new List<string>();

            var publications = GetDocuments<Publication>(jsons!);

            return publications;
        }
        
        
        public class QueryResponse
        {
            public Response? Response { get; set; }
        }

        public class Response
        {
            public int NumFound { get; set; }
            public int Start { get; set; }
            public bool NumFoundExact { get; set; }
            public ICollection<Doc>? Docs { get; set; }
        }

        public class Doc
        {
            public string Json { get; set; } = default!;
        }
    }
}
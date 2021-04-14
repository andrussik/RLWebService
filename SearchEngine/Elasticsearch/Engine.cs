using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace SearchEngine.Elasticsearch
{
    public class Engine
    {
        private static IElasticLowLevelClient _elasticLowLevelClient;

        public Engine(IElasticLowLevelClient elasticLowLevelClient)
        {
            _elasticLowLevelClient = elasticLowLevelClient;
        }

        public static async Task CreateIndex<T>(T data, int id)
        {
            var lowLevelClient = new ElasticLowLevelClient();
            var typeName = typeof(T).Name;
            Console.WriteLine(typeName);
            var indexResponse = await _elasticLowLevelClient.IndexAsync<BytesResponse>(typeName, id.ToString(), PostData.Serializable(data));
            byte[] responseBytes = indexResponse.Body;
            Console.WriteLine(responseBytes);
        }
        
        public static async Task BulkIndex(IEnumerable<object> data)
        {
            var lowLevelClient = new ElasticLowLevelClient();
            var indexResponse = await lowLevelClient.BulkAsync<StringResponse>(PostData.MultiJson(data));
            var responseStream = indexResponse.Body;
        }

        public static async Task<string> Search(string searchQuery, string indexName)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(searchQuery);
            Console.WriteLine(indexName);
            var lowLevelClient = new ElasticLowLevelClient();
            var searchResponse = await lowLevelClient.SearchAsync<StringResponse>(indexName, PostData.Serializable(new
            {
                from = 0,
                size = 50,
                query = new
                {
                    match = new
                    {
                        Title = new
                        {
                            query = searchQuery
                        }
                    }
                }
            }));

            var successful = searchResponse.Success;
            var responseJson = searchResponse.Body;

            Console.WriteLine(responseJson);
            Console.WriteLine("---------------");
            return responseJson;
        }
    }
}
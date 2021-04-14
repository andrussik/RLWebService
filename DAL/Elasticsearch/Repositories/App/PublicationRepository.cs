using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Elasticsearch.Repositories.Contracts;
using DTO.SearchEngine;
using Nest;

namespace DAL.Elasticsearch.Repositories.App
{
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        public PublicationRepository(IElasticClient elasticClient) : base(elasticClient)
        {
        }
        
        public async Task IndexManyAsync(IEnumerable<Publication> publications)
        {
            await _elasticClient.IndexManyAsync(publications, "publication");
        }

        public async Task<ISearchResponse<Publication>> ScrollAsync(string? scrollId = null)
        {
            if (scrollId == null)
            {
                var result = await _elasticClient.SearchAsync<Publication>(s => s
                    .Index("publication")
                    .Size(10000)
                    .Scroll("1m")
                );

                return result;
            }
            else
            {

                var result = await _elasticClient.ScrollAsync<Publication>("1m", scrollId);
                return result;
            }
        }

        public async Task<IEnumerable<Publication>> FuzzySearchAsync(string searchString)
        {
            var result = await _elasticClient.SearchAsync<Publication>(s => s
                .Index("publication")
                .From(0)
                .Size(10000)
                .Query(q => q
                    .MultiMatch(c => c
                        .Fields(f => f
                            .Field(p => p.Title)
                            .Field(p => p.Author)
                        )
                        .Query(searchString)
                        .Fuzziness(Fuzziness.Auto)
                    )
                )
            );

            var publications = result.Documents;
            return publications;

        // }

        // var result = await _elasticClient.SearchAsync<Publication>(s => s
            //     .Index("publication")
            //     .From(0)
            //     .Size(25)
            //     .Query(q => q
            //             .MultiMatch(c => c
            //                     .Fields(f => f
            //                             .Field(p => p.Title)
            //                             .Field(p => p.Author)
            //                         // .Field(p => p.PublishYear)
            //                     )
            //                     .Query(searchString)
            //                     // .Analyzer("estonian")
            //                     // .Boost(1.1)
            //                     // .Slop(2)
            //                     .Fuzziness(Fuzziness.Auto)
            //                 // .PrefixLength(2)
            //                 // .MaxExpansions(2)
            //                 // .Type(TextQueryType.MostFields)
            //             )
            //
            //         // .Fuzzy(c => c
            //         //     .Field(p => p.Title)
            //         //     .Fuzziness(Fuzziness.EditDistance(4))
            //         //     .Value(searchString)
            //         //     .MaxExpansions(100)
            //         //     .PrefixLength(3)
            //         //     .Rewrite(MultiTermQueryRewrite.ConstantScore)
            //         //     .Transpositions()
            //         // )
            //     )
            // );
            //
            // // Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
            // var publications = result.Documents;
            // return publications;
        }
        
        // Task<IEnumerable<Publication>> FuzzySearchAsync(string searchString);
    }
}
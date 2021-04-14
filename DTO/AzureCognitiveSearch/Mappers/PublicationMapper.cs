using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DTO.Sierra;
using MarcReader;

namespace DTO.AzureCognitiveSearch.Mappers
{
    public class PublicationMapper
    {
        public static IEnumerable<Publication> Map(string marcString)
        {
            var publications = new List<Publication>();

            using (var ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(marcString)))
            {
                {
                    using (var reader = new MarcStreamReader(ms, "UTF-8"))
                    {
                        foreach (var record in reader)
                        {
                            var dataFields = record.GetDataFields();

                            var languageCode = dataFields
                                .FirstOrDefault(x => x.Tag == "008")
                                ?.Tag?.Substring(35, 37);

                            var isbn = dataFields
                                .FirstOrDefault(x => x.Tag == "020")
                                ?.GetSubfields()
                                ?.FirstOrDefault(x => x.Code == 'a')
                                ?.Data;

                            var author = string.Join(" ",
                                dataFields
                                    .FirstOrDefault(x => x.Tag == "100")
                                    ?.GetSubfields()
                                    ?.Select(x => x.Data)
                                    .ToList() ?? new List<string>()
                            );

                            // var title = string.Join(" ",
                            //     dataFields
                            //         .FirstOrDefault(x => x.Tag == "245")
                            //         ?.GetSubfields()
                            //         ?.Select(x => x.Data)
                            //         .ToList() ?? new List<string>()
                            // );
                            
                            var mainTitle = dataFields
                                .FirstOrDefault(x => x.Tag == "245")
                                ?.GetSubfields()
                                ?.FirstOrDefault(x => x.Code == 'a')
                                ?.Data.TrimEnd('/',' ') ?? "";
                            var subTitle = dataFields
                                .FirstOrDefault(x => x.Tag == "245")
                                ?.GetSubfields()
                                ?.FirstOrDefault(x => x.Code == 'b')
                                ?.Data.TrimEnd('/',':',' ') ?? "";
                            var title = string.Join(" ", mainTitle, subTitle);

                            var publishYearString = dataFields
                                .FirstOrDefault(x => x.Tag == "260")
                                ?.GetSubfields()
                                ?.LastOrDefault(x => x.Code == 'c')
                                ?.Data ?? "";
                            publishYearString = Regex.Replace(publishYearString,"\\D","");
                            int? publishYear;
                            publishYear = int.TryParse(publishYearString, out var result) ? result : null;

                            if (isbn != null)
                            {
                                var publication = new Publication
                                {
                                    // Isbn = isbn,
                                    Title = title,
                                    Author = author,
                                    PublishYear = publishYear,
                                    // LanguageCode = languageCode
                                };
                                publications.Add(publication);
                            }
                        }
                    }
                }
            }

            return publications;
        }

        public static Publication Map(Bib bib)
        {
            return new()
            {
                Id = bib.Id,
                Title = bib.Title,
                Author = bib.Author,
                PublishYear = bib.PublishYear,
                Lang = bib.Lang != null ? new Language{Code = bib.Lang.Code, Name = bib.Lang.Name} : null,
                MaterialType = bib.MaterialType != null ? new MaterialType{Code = bib.MaterialType.Code, Name = bib.MaterialType.Value} : null
            };
        }

        public static IEnumerable<Publication> Map(IEnumerable<Bib> bibs)
        {
            var result = new List<Publication>();
            foreach (var bib in bibs)
            {
                var publication = Map(bib);
                result.Add(publication);
            }

            return result;
        }
        
        public static Publication Map(SearchEngine.Publication publication)
        {
            return new()
            {
                Id = publication.Id,
                Title = publication.Title,
                Author = publication.Author,
                PublishYear = publication.PublishYear,
                Lang = publication.Lang != null ? new Language{Code = publication.Lang.Code, Name = publication.Lang.Name} : null,
                MaterialType = publication.MaterialType != null ? new MaterialType{Code = publication.MaterialType.Code, Name = publication.MaterialType.Name} : null,
                Items = ItemMapper.Map(publication.Items ?? Array.Empty<SearchEngine.Item>()).ToList()
            };
        }

        public static IEnumerable<Publication> Map(IEnumerable<SearchEngine.Publication> publications)
        {
            var result = new List<Publication>();
            foreach (var publication in publications)
            {
                result.Add(Map(publication));
            }

            return result;
        }
    }
}
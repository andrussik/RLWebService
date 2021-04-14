using System;
using System.Collections.Generic;
using System.Linq;
using DTO.SearchEngine;
using DTO.Sierra;

namespace DTO.PublicApi.Mappers
{
    public static class BookMapper
    {
        public static Book Map(Bib bib)
        {
            var book = new Book
            {
                Id = bib.Id,
                Title = bib.Title,
                Author = bib.Author,
                PublishYear = bib.PublishYear
            };

            return book;
        }

        public static IEnumerable<Book> Map(IEnumerable<Bib> bibs)
        {
            var books = new List<Book>();
            
            foreach (var bib in bibs)
            {
                var book = Map(bib);
                
                books.Add(book);
            }

            return books;
        }
        
        public static IEnumerable<Book> Map(SearchResponse searchResponse)
        {
            var bibs = searchResponse.Entries
                ?.Where(entry => entry.Bib != null)
                .Select(entry => entry.Bib!).ToList() ?? new List<Bib>();
            var books = Map(bibs);

            return books;
        }
        
        public static Book Map(Publication publication)
        {
            return new ()
            {
                Title = publication.Title ?? "",
                Author = publication.Author ?? "",
                PublishYear = publication.PublishYear,
                Lang = publication.Lang != null 
                    ? new Language{Code = publication.Lang!.Code, Name = publication.Lang.Name} 
                    : null,
                MaterialType = publication.MaterialType != null 
                    ? new MaterialType{Code = publication.MaterialType.Code, Name = publication.MaterialType.Name} 
                    : null,
                Items = ItemMapper.Map(publication.Items ?? Array.Empty<SearchEngine.Item>()).ToList()
            };
        }
        
        public static IEnumerable<Book> Map(IEnumerable<Publication> publications)
        {
            var result = new List<Book>();

            foreach (var publication in publications)
            {
                result.Add(Map(publication));
            }

            return result;
        }
        public static Book Map(AzureCognitiveSearch.Publication publication)
        {
            return new ()
            {
                Title = publication.Title ?? "",
                Author = publication.Author ?? "",
                PublishYear = publication.PublishYear,
                Lang = publication.Lang != null 
                    ? new Language{Code = publication.Lang!.Code, Name = publication.Lang.Name} 
                    : null,
                MaterialType = publication.MaterialType != null 
                    ? new MaterialType{Code = publication.MaterialType.Code, Name = publication.MaterialType.Name} 
                    : null,
                Items = ItemMapper.Map(publication.Items ?? Array.Empty<AzureCognitiveSearch.Item>()).ToList()
            };
        }
        
        public static IEnumerable<Book> Map(IEnumerable<AzureCognitiveSearch.Publication> publications)
        {
            var result = new List<Book>();

            foreach (var publication in publications)
            {
                result.Add(Map(publication));
            }

            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers.Classic;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Util;
using LuceneExtensions.DataAnnotations;

namespace LuceneSearchEngine
{
    public class LuceneSearchEngineCore
    {
        // Ensures index backward compatibility
        private const LuceneVersion LuceneVersion48 = LuceneVersion.LUCENE_48;
        private const string IndexDirPath = "/Users/andre/git/RLTest/RLWebService/LuceneSearchEngine/index";
        private static readonly DirectoryInfo IndexDir = new DirectoryInfo(IndexDirPath);

        private IndexWriter GetWriter()
        {
            var dir = FSDirectory.Open(IndexDir);

            // Create an analyzer to process the text
            var analyzer = new StandardAnalyzer(LuceneVersion48);

            // Create an index writer
            var indexConfig = new IndexWriterConfig(LuceneVersion48, analyzer);
            var writer = new IndexWriter(dir, indexConfig);

            return writer;
        }

        private IndexReader GetReader(IndexWriter writer)
        {
            var reader = writer.GetReader(applyAllDeletes: true);
            return reader;
        }

        private Document CreateDocument<T>(T item)
        {
            var doc = item.ToDocument();

            return doc;
        }

        private IEnumerable<Document> CreateDocuments<T>(IEnumerable<T> items)
        {
            var documents = new List<Document>();

            foreach (var obj in items)
            {
                var document = CreateDocument(obj);
                documents.Add(document);
            }

            return documents;
        }

        public void AddOrUpdateDocuments<T>(IEnumerable<T> items)
        {
            items = items.ToList();

            var query = new BooleanQuery();
            BooleanQuery.MaxClauseCount = 10000;

            foreach (var item in items)
            {
                var hasIdProperty = IdProperty.HasIdProperty<T>();
                if (hasIdProperty)
                {
                    var id = IdProperty.GetIdValue<T, string>(item);
                    query.Add(new TermQuery(new Term("Id", id)), Occur.SHOULD);
                }
            }
            
            var documents = CreateDocuments(items);

            using var writer = GetWriter();
            
            // Delete existing documents
            writer.DeleteDocuments(query);

            // Add new documents
            writer.AddDocuments(documents);
            
            writer.Commit();
            writer.Dispose();
        }

        public IEnumerable<T> Search<T>(string searchString)
        {
            using var writer = GetWriter();
            using var reader = GetReader(writer);
            
            var analyzer = new StandardAnalyzer(LuceneVersion48);
            var searchFields = new[] {"Title", "Author"};
            var parser = new MultiFieldQueryParser(
                LuceneVersion48,
                searchFields,
                analyzer
            );
            var terms = searchString.Split(" ");
            terms = terms.Select(term => term + "~").ToArray();
            var query = new BooleanQuery();
            foreach (var term in terms)
            {
                query.Add(parser.Parse(term), Occur.SHOULD);
            }

            var searcher = new IndexSearcher(reader);
            
            var hits = searcher.Search<T>(query, 15);

            var result = new List<T>();

            foreach (var scoreDoc in hits.ScoreDocs)
            {
                var doc = searcher.Doc(scoreDoc.Doc);
                var item = doc.ToObject<T>();
                result.Add(item);
            }

            reader.Dispose();
            writer.Dispose();
            return result;
        }
    }
}
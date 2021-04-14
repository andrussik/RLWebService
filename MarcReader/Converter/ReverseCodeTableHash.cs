using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using MarcReader.Properties;

namespace MarcReader.Converter
{
    /// <summary>
    ///  <c>ReverseCodeTableHash</c> defines a data structure to facilitate
    ///  UnicodeToAnsel character conversion.
    /// </summary>
    public class ReverseCodeTableHash : ReverseCodeTable
    {
        #region Default Instance

        private static ReverseCodeTableHash _defaultInstance = default!;
        public static ReverseCodeTableHash DefaultInstance
        {
            get 
            {
                if (_defaultInstance == null)
                {
                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(Resources.codetables)))
                    {
                        _defaultInstance = new ReverseCodeTableHash(stream);
                    }
                }
                return _defaultInstance; 
            }
        }

        #endregion

        #region Fields
        
        protected IDictionary<char, IDictionary<int, char[]>> charsets = null!;

        protected HashSet<char> combining = null!;

        #endregion

        public override bool IsCombining(char c)
        {
            return combining.Contains(c);
        }

        public override IDictionary<int, char[]> GetCharTable(char c)
        {
            IDictionary<int, char[]> value = null!;
            if (charsets.TryGetValue(c, out value!))
            {
                return value;
            }

            return null!;
        }

        public ReverseCodeTableHash(Stream byteStream)
        {
            try
            {
                var reader = new ReverseCodeTableXmlReader();
                reader.Read(byteStream);
                charsets = reader.CharSets;
                combining = reader.CombiningChars;
            }
            catch (Exception e)
            {
                throw new MarcException(e.Message, e);
            }

        }

        public ReverseCodeTableHash(String filename)
        {
            try
            {
                using (var fs = new FileStream(filename, FileMode.Open))
                {
                    var reader = new ReverseCodeTableXmlReader();
                    reader.Read(fs);
                    charsets = reader.CharSets;
                    combining = reader.CombiningChars;
                }
            }
            catch (Exception e)
            {
                throw new MarcException(e.Message, e);
            }
        }

        public ReverseCodeTableHash(Uri uri)
        {
            try
            {
                using (var stream = WebRequest.Create(uri).GetResponse().GetResponseStream())
                {
                    var reader = new ReverseCodeTableXmlReader();
                    reader.Read(stream);
                    charsets = reader.CharSets;
                    combining = reader.CombiningChars;
                }
            }
            catch (Exception e)
            {
                throw new MarcException(e.Message, e);
            }
        }
    }
}
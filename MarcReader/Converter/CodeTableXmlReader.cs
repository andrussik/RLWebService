using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MarcReader.Converter
{
    public class CodeTableXmlReader
    {
        #region Fields
        private IDictionary<int, IDictionary<int, char>> sets = default!;

        private IDictionary<int, char> charset = default!;

        private IDictionary<int, HashSet<int>> combiningchars = default!;

        /** Data element identifier */
        private int isocode;

        private int marc;

        private bool useAlt = false;

        private bool isCombining;

        private HashSet<int> combining = default!;

        #endregion

        #region Properties

        public IDictionary<int, IDictionary<int, char>> CharSets
        {
            get
            {
                return sets;
            }
        }

        public IDictionary<int, HashSet<int>> CombiningChars
        {
            get
            {
                return combiningchars;
            }
        }

        #endregion

        public void Read(Stream stream)
        {
            var root = XElement.Load(stream);
            combiningchars = new Dictionary<int, HashSet<int>>();
            sets = root.Descendants("characterSet")
                       .Select(a =>
                       {
                           combining = new HashSet<int>();
                           isocode = Convert.ToInt32((a.Attribute("ISOcode")!.Value), 16);
                           charset = a.Elements("code")
                                       .Select(c =>
                                       {
                                           isCombining = c.Elements("isCombining").Any() ?
                                                   c.Element("isCombining")!.Value == "true" : false;
                                           marc = Convert.ToInt32(c.Element("marc")!.Value, 16);
                                           if (isCombining)
                                               combining.Add(marc);
                                           return new
                                           {
                                               marc = marc,
                                               alt = (useAlt && c.Elements("alt").Any()) || 
                                                     !c.Elements("ucs").Any() || 
                                                     string.IsNullOrEmpty(c.Element("ucs")!.Value) ?
                                                   Convert.ToChar(Convert.ToInt32(c.Element("alt")!.Value, 16)) :
                                                   Convert.ToChar(Convert.ToInt32(c.Element("ucs")!.Value, 16))
                                           };
                                       }).ToDictionary(v => v.marc, v => v.alt);

                           combiningchars.Add(isocode, combining);
                           return new
                           {
                               ISOcode = isocode,
                               Code = charset
                           };
                       }).ToDictionary(d => d.ISOcode, d => d.Code);
        }
    }
}
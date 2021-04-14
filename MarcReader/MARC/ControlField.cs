using System;
using System.Text.RegularExpressions;

namespace MarcReader.MARC
{
    public class ControlField : VariableField, IControlField
    {
        #region Ctors

        public ControlField()
        {
        }
        public ControlField(String tag)
            : base(tag)
        {
        }

        public ControlField(String tag, String data)
            : base(tag)
        {
            Data = data;
        }

        #endregion

        public string Data { get; set; } = default!;

        public override string ToString()
        {
            return base.ToString() + " " + Data;
        }
        public override bool Find(String pattern)
        {
            return Regex.IsMatch(Data ?? string.Empty, pattern);
        }
    }
}
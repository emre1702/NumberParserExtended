using System;
using System.Collections.Generic;
using System.Text;

namespace NumberParserExtended.Common.Interfaces
{
    public interface ITabConverterHelper
    {
        /// <summary>
        /// Converts every tab in every line to space(s)
        /// </summary>
        /// <param name="lines"></param>
        void ConvertToSpaces(string[] lines);
    }
}

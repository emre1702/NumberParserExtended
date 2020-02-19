using System;
using System.Collections.Generic;
using System.Text;

namespace NumberParserExtended.Common.Interfaces
{
    public interface IParsingHelper
    {
        /// <summary>
        /// Parse the numbers representations.
        /// </summary>
        /// <param name="numbersLines">Lines read from the numbers file</param>
        /// <param name="mappings">Mappings to detect the numbers</param>
        /// <returns>Result - list of numbers in a string</returns>
        string Parse(string[] numbersLines, List<(int, string[])> mappings);
    }
}

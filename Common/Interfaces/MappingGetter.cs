using System;
using System.Collections.Generic;

namespace NumberParserExtended.Common.Interfaces
{
    public interface IMappingGetter
    {
        /// <summary>
        /// Get the setted mappings for the numbers file 
        /// to be able to detect the numbers.
        /// </summary>
        /// <param name="info">Any info given to the method (e.g. file path, SQL connection string etc.)</param>
        /// <returns>Tuple with number and lines for the number representation</returns>
        List<(int, string[])>? GetMappings(object info);
    }
}

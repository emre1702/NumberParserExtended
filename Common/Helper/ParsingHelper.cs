using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumberParserExtended.Common.Interfaces;

namespace NumberParserExtended.Common.Helper
{
    public class ParsingHelper : IParsingHelper
    {
        public string Parse(string[] numbersLines, List<(int, string[])> mappings)
        {
            // I use StringBuilder instead of a List of numbers 
            // to be able to easily add new lines
            var resultBuilder = new StringBuilder();

            int currentColumn = 0;
            int currentRow = 0;

            int maxColumns = numbersLines.Max(l => l.Length) ;
            int maxRows = numbersLines.Length;

            while (currentColumn <= maxColumns && currentRow <= maxRows)
            {
                int? foundNumber = null;
                // Testing every single mapping
                foreach (var mapping in mappings)
                {
                    int mappingWidth = mapping.Item2.Max(m => m.Length);
                    int mappingHeight = mapping.Item2.Length;

                    // Don't try this mapping if it would already exceeds the max rows or colums of the whole numbers file
                    if (currentRow + mappingHeight > maxRows)
                        continue;
                    if (currentColumn + mappingWidth > maxColumns)
                        continue;

                    bool found = true;
                    for (int i = currentRow; i < currentRow + mappingHeight && found; ++i)
                    for (int j = currentColumn; j < currentColumn + mappingWidth; ++j)
                    { 
                        if (mapping.Item2[i - currentRow].Length <= j - currentColumn)
                            break; 

                        // The char at one position is not the same -> wrong mapping
                        if (numbersLines.Length <= i 
                            || numbersLines[i].Length <= j
                            || numbersLines[i][j] != mapping.Item2[i-currentRow][j-currentColumn])
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
                    {
                        foundNumber = mapping.Item1;
                        break;
                    }
                }

                // We've detected the number
                if (foundNumber.HasValue)
                {
                    var mapping = mappings.First(m => m.Item1 == foundNumber.Value);
                    // Jump to the right side of the number
                    currentColumn += mapping.Item2.Max(a => a.Length) + 1;
                    resultBuilder.Append(foundNumber.Value + ", ");
                }
                else
                {
                    currentColumn += 1;
                }
                
                // Jump to the next row?
                if (currentColumn > maxColumns)
                {
                    currentColumn = 0;
                    currentRow += mappings[0].Item2.Length;
                    resultBuilder.AppendLine();
                    // Skip the empty rows
                    while (currentRow <= maxRows && numbersLines[1].Trim().Length == 0)
                    {
                        ++currentRow;
                    }
                    
                }
                    
            }

            // Nice output without useless line breaks or commas (at the end)
            if (resultBuilder.Length > 0)
                return resultBuilder.ToString().Trim('\n', '\r')[0..^2];

            return resultBuilder.ToString();
        }
    }
}

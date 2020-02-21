using System.Linq;
using NumberParserExtended.Common.Interfaces;

namespace NumberParserExtended.Common.Helper
{
    public class TabConverterHelper : ITabConverterHelper
    {
        public void ConvertToSpaces(string[] lines)
        {
            // In text editors the columns are kinda splitted by tab size.
            // If you enter a tab it can have a width of 1 to tab-width, depending on the position it was written.
            // The tabs go to the next tab position (tab size = 4 => 0, 4, 8, 12, 16, 20)
            // e.g. 3. column => 4. column, width = 1   
            // 4. column => 8. column, width 4  
            // 5. column => 8. column, width 3      etc.
            for (int i = 0; i < lines.Length; ++i)
            {
                var line = lines[i];
                int nextTabIndex = line.IndexOf('\t');
                while (nextTabIndex >= 0)
                {
                    int amountSpaces = Constants.TAB_SIZE - (nextTabIndex % Constants.TAB_SIZE);
                    line = line.Substring(0, nextTabIndex) + new string(' ', amountSpaces) + line.Substring(nextTabIndex + 1);
                    nextTabIndex = line.IndexOf('\t', nextTabIndex + 1);
                }
                lines[i] = line;
            }
        }
    }
}

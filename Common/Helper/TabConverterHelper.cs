using System.Linq;
using NumberParserExtended.Common.Interfaces;

namespace NumberParserExtended.Common.Helper
{
    public class TabConverterHelper : ITabConverterHelper
    {
        public void ConvertToSpaces(string[] lines)
        {
            // In text editors the tabs go either to the next character in the next columns 
            // or to the tab width that was set (usually 4) if no character was found before.
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

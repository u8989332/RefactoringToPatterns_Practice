using System.Text;

namespace ExtractParameter
{
    public class DecodingNode : Node
    {
        /// <summary>
        /// for unit testing
        /// </summary>
        internal Node CurDelegate { get; }

        public DecodingNode(StringBuilder textBuilder, int textBegin, int textEnd)
        {
            CurDelegate = new StringNode(textBuilder, textBegin, textEnd);
        }
    }
}
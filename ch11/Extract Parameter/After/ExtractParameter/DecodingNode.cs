namespace ExtractParameter
{
    public class DecodingNode : Node
    {
        /// <summary>
        /// for unit testing
        /// </summary>
        internal Node CurDelegate { get; }

        public DecodingNode(Node newDelegate)
        {
            CurDelegate = newDelegate;
        }
    }
}
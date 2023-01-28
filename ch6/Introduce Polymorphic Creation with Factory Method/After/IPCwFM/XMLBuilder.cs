using System.Text;

namespace IPCwFM
{
    public class XMLBuilder : IOutputBuilder
    {
        private StringBuilder sb = new StringBuilder();

        public XMLBuilder(string rootName)
        {
            sb.Append("I am XML" + rootName);
        }

        public void AddBelow(string name)
        {
            sb.Append(name);
        }

        public string Run()
        {
            return sb.ToString();
        }
    }
}

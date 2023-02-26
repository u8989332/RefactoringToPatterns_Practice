using System.Text;

namespace RITwC
{
    public class TagNode
    {
        private readonly string _name;
        private string _value;
        private readonly StringBuilder _attributes;
        private readonly List<TagNode> _children  = new List<TagNode>();

        public TagNode(string name)
        {
            _name = name;
            _attributes = new StringBuilder("");
        }

        public void AddAttribute(string attribute, string value)
        {
            _attributes.Append(" ");
            _attributes.Append(attribute);
            _attributes.Append("='");
            _attributes.Append(value);
            _attributes.Append("'");
        }

        public void AddValue(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            string result = "<" + _name + _attributes + ">";
            foreach (var node in _children)
            {
                result += node;
            }
            result += _value +
                     "</" + _name + ">";

            return result;
        }

        public void Add(TagNode child)
        {
            _children.Add(child);
        }
    }
}

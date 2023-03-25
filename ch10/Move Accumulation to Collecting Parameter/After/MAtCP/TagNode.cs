using System.Text;

namespace MAtCP
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
            StringBuilder result = new StringBuilder();
            AppendContentsTo(result);
            
                      

            return result.ToString();
        }

        public void Add(TagNode child)
        {
            _children.Add(child);
        }

        private void AppendContentsTo(StringBuilder result)
        {
            WriteOpenTagTo(result);
            WriteChildrenTo(result);
            WriteValueTo(result);
            WriteEndTagTo(result);
        }

        private void WriteEndTagTo(StringBuilder result)
        {
            result.Append("</");
            result.Append(_name);
            result.Append(">");
        }

        private void WriteValueTo(StringBuilder result)
        {
            result.Append(_value);
        }

        private void WriteChildrenTo(StringBuilder result)
        {
            foreach (var node in _children)
            {
                node.AppendContentsTo(result);
            }
        }


        private void WriteOpenTagTo(StringBuilder result)
        {
            result.Append("<");
            result.Append(_name);
            result.Append(_attributes);
            result.Append(">");
        }
    }
}

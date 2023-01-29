using System.Xml.Linq;

namespace ECwB
{
    public class TagNode
    {
        public string Attributes { get; private set; }
        public string TagName { get; }
        public string Value { get; }
        public List<TagNode> Children { get; } = new List<TagNode>();
        public TagNode Parent { get; set; }

        public TagNode(string name)
        {
            TagName = name;
        }

        public void Add(TagNode childNode)
        {
            childNode.Parent = this;
            Children.Add(childNode);
        }

        public override string ToString()
        {
            if (Children.Count == 0 && string.IsNullOrEmpty(Value))
            {
                return "<" + TagName + "/>";
            }

            var result = "<" + TagName + Attributes + ">";
            foreach (var child in Children)
            {
                result += child.ToString();
            }
            result += Value;
            result += "</" + TagName + ">";
            return result;
        }
    }

    public class TagBuilder
    {
        private TagNode _rootNode;
        private TagNode _currentNode;

        public TagBuilder(string rootTagName)
        {
            _rootNode = new TagNode(rootTagName);
            _currentNode = _rootNode;
        }

        public void AddChild(string childTagName)
        {
            AddTo(_currentNode, childTagName);
        }


        public void AddSibling(string siblingTagName)
        {
            AddTo(_currentNode.Parent, siblingTagName);
        }

        public string ToXml()
        {
            return _rootNode.ToString();
        }
        private void AddTo(TagNode parentNode, string tagName)
        {
            _currentNode = new TagNode(tagName);
            parentNode.Add(_currentNode);
        }
    }
}

namespace ComposedMethod
{
    public class MyList
    {
        private const int GrowthIncrement = 10;
        private int _size = 0;
        private readonly bool _readOnly;
        public object[] Elements { get; private set; } = Array.Empty<object>();

        public MyList(bool readOnly)
        {
            this._readOnly = readOnly;
        }

        public void Add(object element)
        {
            if (_readOnly)
            {
                return;
            }

            if (AtCapacity())
            {
                Grow();
            }

            AddElement(element);
        }

        private void AddElement(object element)
        {
            Elements[_size++] = element;
        }

        private void Grow()
        {
            object[] newElements = new object[Elements.Length + GrowthIncrement];
            for (int i = 0; i < _size; ++i)
            {
                newElements[i] = Elements[i];
            }

            Elements = newElements;
        }

        private bool AtCapacity()
        {
            return _size + 1 > Elements.Length;
        }
    }
}

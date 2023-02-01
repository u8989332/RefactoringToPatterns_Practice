namespace ComposedMethod
{
    public class MyList
    {
        private int _size = 0;
        private readonly bool _readOnly;
        public object[] Elements { get; private set; } = Array.Empty<object>();

        public MyList(bool readOnly)
        {
            this._readOnly = readOnly;
        }

        public void Add(object element)
        {
            if (!_readOnly)
            {
                int newSize = _size + 1;
                if (newSize > Elements.Length)
                {
                    object[] newElements = new object[Elements.Length + 10];
                    for (int i = 0; i < _size; ++i)
                    {
                        newElements[i] = Elements[i];
                    }
                    Elements = newElements;
                }

                Elements[_size++] = element;
            }
        }
    }
}

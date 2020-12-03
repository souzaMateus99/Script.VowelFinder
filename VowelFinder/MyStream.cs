using System.IO;

namespace VowelFinder
{
    public class MyStream : IStream
    {
        private readonly char[] _text;
        private int currentPosition = 0;
        
        public MyStream(string text)
        {
            _text = text.ToCharArray();
        }

        public MyStream(char[] text)
        {
            _text = text;
        }
        
        public char getNext()
        {
            var nextItem = _text[currentPosition];

            currentPosition++;

            return nextItem;
        }

        public bool hasNext()
        {
            return currentPosition < _text.Length;
        }
    }
}
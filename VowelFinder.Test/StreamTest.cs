using System;
using Xunit;

namespace VowelFinder.Test
{
    public class StreamTest
    {        
        [Fact]
        public void HasNext_ShouldBeReturnFalse()
        {            
            var myStream = new MyStream(string.Empty);

            Assert.Equal(false, myStream.hasNext());
        }

        [Theory]
        [InlineData("aAbBABacfe")]
        [InlineData("natalidade")]
        [InlineData("banana")]
        public void HasNext_ShouldBeReturnTrue(string text)
        {
            var myStream = new MyStream(text);

            Assert.Equal(true, myStream.hasNext());
        }

        [Fact]
        public void GetNext_ShouldBeThrowIndexOutOfRangeException()
        {
            var myStream = new MyStream(string.Empty);

            Assert.Throws<IndexOutOfRangeException>(() => myStream.getNext());
        }

        [Theory]
        [InlineData("aAbBABacfe", 'a')]
        public void GetNext_ShouldBeReturnTheCharValue(string text, char firstChar)
        {
            var myStream = new MyStream(text);

            Assert.Equal(firstChar, myStream.getNext());
        }
    }
}

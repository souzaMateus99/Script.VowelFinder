using Xunit;

namespace VowelFinder.Test
{
    public class LogicCharTest
    {        
        [Theory]
        [InlineData("aAbBABacfe", 'e')]
        [InlineData("natalidade", 'i')]
        [InlineData("mato", 'a')]
        [InlineData("mato", 'a')]
        public void Char_ShouldBeReturnFirstVowelAfterConsonant(string text, char charShouldBeReturn)
        {
            var myStream = new MyStream(text);
            
            Assert.Equal(charShouldBeReturn, Program.firstChar(myStream));
        }

        [Theory]
        [InlineData("matagal")]
        [InlineData("banana")]
        [InlineData("massa")]
        [InlineData("batata")]
        public void Char_ShouldBeReturnDefaultCharValue(string text)
        {
            var myStream = new MyStream(text);
            
            Assert.Equal(default(char), Program.firstChar(myStream));
        }
    }
}
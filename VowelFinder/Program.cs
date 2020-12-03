using System;

namespace VowelFinder
{
    public class Program
    {
        internal static readonly char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
        
        internal static void Main(string[] args)
        {            
            var stream = new MyStream("natalidade");
            var vowel = firstChar(stream);

            if(vowel is default(char))
            {
                Console.WriteLine("Não foi localizado vogal que não se repete após uma consoante");
            }
            else
            {
                Console.WriteLine($"Vogal encontrada: {vowel}");
            }

            Console.WriteLine("Pressione qualquer botão para finalizar");
            Console.ReadKey();
        }

        public static char firstChar(IStream input)
        {
            var charLength = 1;
            var previousChar = input.getNext();
            var vowelsFind = new char[charLength];

            while(input.hasNext())
            {
                var currentChar = input.getNext();
                
                if(!isVowel(previousChar) && isVowel(currentChar))
                {
                    var vowel = new char[++charLength];
                    
                    vowel[charLength - 1] = currentChar;
                    vowelsFind.CopyTo(vowel, 0);

                    vowelsFind = vowel;
                }

                previousChar = currentChar;
            }

            return getDifferentChar(vowelsFind);;
        }

        public static bool isVowel(char word, int vowelIndex = 0)
        {
            if(vowelIndex < vowels.Length)
            {
                if(isEqualsChar(word, vowels[vowelIndex]))
                {
                    return true;
                }

                return isVowel(word, ++vowelIndex);
            }
            
            return false;
        }

        public static bool isEqualsChar(char charOne, char charTwo)
        {
            return char.ToLower(charOne).Equals(char.ToLower(charTwo));
        }

        public static char getDifferentChar(char[] chars, int currentIndex = 1)
        {            
            if(currentIndex < chars.Length)
            {
                var currentChar = chars[currentIndex];
                
                for(var i = 0; i < chars.Length; i++)
                {
                    var nextChar = chars[i];

                    if(isEqualsChar(currentChar, nextChar) && i != currentIndex)
                    {
                        return getDifferentChar(chars, ++currentIndex);
                    }
                }

                return currentChar;
            }

            return default;
        }
    }
}

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

        /// <summary>
        /// Get the first vowel char in the Stream (<paramref name="input"/>)
        /// </summary>
        /// <remarks>
        /// Get the first vowel that don't repeat after a consonant
        /// </remarks>
        /// <param name="input">The Stream element</param>
        /// <returns>First vowel</returns>
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

        /// <summary>
        /// Verify if the word received (<paramref name="word"/>) is a vowel
        /// </summary>
        /// <param name="word">Word (char) to verify</param>
        /// <param name="vowelIndex"></param>
        /// <returns>If the word is a vowel</returns>
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

        /// <summary>
        /// Verifiy if the chars elements is equals
        /// </summary>
        /// <param name="charOne"></param>
        /// <param name="charTwo"></param>
        /// <returns>If the values received are equals</returns>
        public static bool isEqualsChar(char charOne, char charTwo)
        {
            return char.ToLower(charOne).Equals(char.ToLower(charTwo));
        }

        /// <summary>
        /// Get the first different char from char array
        /// </summary>
        /// <param name="chars">char array</param>
        /// <param name="currentIndex"></param>
        /// <returns>The first different char from array or default value</returns>
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

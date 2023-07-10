using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Word Frequency Analysis
            Console.WriteLine("Enter a sentence:");
            string sentence = Console.ReadLine();

            string[] words = GetWordsFromSentence(sentence);
            int[] wordFrequencies = CountWordFrequencies(words);

            Console.WriteLine("Word Frequency Analysis:");
            for (int i = 0; i < words.Length; i++)
            {
                if (wordFrequencies[i] > 0)
                {
                    Console.WriteLine("{0}: {1}", words[i], wordFrequencies[i]);
                }
            }

            // 2) Sentence Maker
            Console.WriteLine("Enter a number (N) for generating sentences:");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Generated Sentence {0}:", i + 1);
                string[] generatedSentence = GenerateSentence(words, 5);
                Console.WriteLine(string.Join(" ", generatedSentence));
            }

            // 3) Longest and Shortest Word Finder
            string longestWord = FindLongestWord(words);
            string shortestWord = FindShortestWord(words);

            Console.WriteLine("Longest Word(s):");
            foreach (string word in words)
            {
                if (word.Length == longestWord.Length)
                {
                    Console.WriteLine(word);
                }
            }

            Console.WriteLine("Shortest Word(s):");
            foreach (string word in words)
            {
                if (word.Length == shortestWord.Length)
                {
                    Console.WriteLine(word);
                }
            }

            // 4) Word Search
            Console.WriteLine("Enter a word to search:");
            string searchWord = Console.ReadLine();

            int searchCount = SearchWordCount(words, searchWord);
            if (searchCount > 0)
            {
                Console.WriteLine("The word \"{0}\" appears {1} time(s) in the sentence.", searchWord, searchCount);
            }
            else
            {
                Console.WriteLine("The word \"{0}\" does not appear in the sentence.", searchWord);
            }

            // 5) Palindrome Detector
            Console.WriteLine("Palindromic Words:");
            foreach (string word in words)
            {
                if (IsPalindrome(word))
                {
                    Console.WriteLine(word);
                }
            }

            // 6) Vowel/Consonant Counter
            Console.WriteLine("Vowel/Consonant Count:");
            foreach (string word in words)
            {
                int vowelCount = CountVowels(word);
                int consonantCount = CountConsonants(word);

                Console.WriteLine("{0}: Vowels={1}, Consonants={2}", word, vowelCount, consonantCount);
            }
            Console.ReadLine();

        }

        static string[] GetWordsFromSentence(string sentence) //Function of Getwordsfromsentencence
        {
            StringBuilder wordBuilder = new StringBuilder(); //String has been declared
            List<string> words = new List<string>();

            foreach (char c in sentence) //Foreach Loop has been applied to get words from sentence
            {
                if (Char.IsLetter(c))
                {
                    wordBuilder.Append(c);
                }
                else if (wordBuilder.Length > 0)
                {
                    words.Add(wordBuilder.ToString());
                    wordBuilder.Clear();
                }
            }

            if (wordBuilder.Length > 0)
            {
                words.Add(wordBuilder.ToString());
            }

            return words.ToArray();
        }

        static int[] CountWordFrequencies(string[] words) //Function cal for countword frequencies
        {
            int[] wordFrequencies = new int[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                if (wordFrequencies[i] == 0)
                {
                    string currentWord = words[i];
                    int count = 1;

                    for (int j = i + 1; j < words.Length; j++)
                    {
                        if (currentWord.Equals(words[j], StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                            wordFrequencies[j] = -1;  // Mark as counted
                        }
                    }

                    wordFrequencies[i] = count;
                }
            }

            return wordFrequencies;
        }

        static string[] GenerateSentence(string[] words, int length) //Function call generate sentence
        {
            List<string> generatedSentence = new List<string>();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(0, words.Length);
                generatedSentence.Add(words[randomIndex]);
            }

            return generatedSentence.ToArray();
        }

        static string FindLongestWord(string[] words) ////Function call for Finding Longest word
        {
            string longestWord = "";
            int maxLength = 0;

            foreach (string word in words)
            {
                if (word.Length > maxLength)
                {
                    maxLength = word.Length;
                    longestWord = word;
                }
            }

            return longestWord;
        }

        static string FindShortestWord(string[] words) //Function call for finding shortest word
        {
            string shortestWord = "";
            int minLength = Int32.MaxValue;

            foreach (string word in words)
            {
                if (word.Length < minLength)
                {
                    minLength = word.Length;
                    shortestWord = word;
                }
            }

            return shortestWord;
        }

        static int SearchWordCount(string[] words, string searchWord) //Function call for search word
        {
            int count = 0;

            foreach (string word in words)
            {
                if (word.Equals(searchWord, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsPalindrome(string word)
        {
            int left = 0;
            int right = word.Length - 1;

            while (left < right)
            {
                if (Char.ToLower(word[left]) != Char.ToLower(word[right]))
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        static int CountVowels(string word)
        {
            int count = 0;

            foreach (char c in word)
            {
                if (IsVowel(c))
                {
                    count++;
                }
            }

            return count;
        }

        static int CountConsonants(string word)
        {
            int count = 0;

            foreach (char c in word)
            {
                if (Char.IsLetter(c) && !IsVowel(c))
                {
                    count++;
                }
            }

            return count;
        }

        static bool IsVowel(char c)
        {
            c = Char.ToLower(c);
            return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
        }
    }

 }
        
    


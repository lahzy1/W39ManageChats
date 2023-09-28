using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace W39ManageChats.Model
{
    public class WordSearch
    {
        public int positiveWordCount { get; set; }
        public int negativeWordCount { get; set; }
        public int neutralWordCount { get; set; }
  
        /*
         * Looks through the sentiments for specific words.
         * If the word exists in the sentiment, the count for that sentiment is increased.
         */
        public void SearchForWord(string word, ListBox positiveChatListBox, ListBox negativeChatListBox, ListBox neutralChatListBox)
        {
            positiveWordCount = 0;
            foreach (var item in positiveChatListBox.Items)
            {
                if (ContainsWord(item.ToString(), word))
                {
                    positiveWordCount++;
                    Debug.WriteLine(item);
                }
            }

            negativeWordCount = 0;
            foreach (var item in negativeChatListBox.Items)
            {
                if (ContainsWord(item.ToString(), word))
                {
                    negativeWordCount++;
                    Debug.WriteLine(item);
                }
            }

            neutralWordCount = 0;
            foreach (var item in neutralChatListBox.Items)
            {
                if (ContainsWord(item.ToString(), word))
                {
                    neutralWordCount++;
                    Debug.WriteLine(item);
                }
            }
        }

        /*
         * Checks if the input contains the whole word.
         */
        public bool ContainsWord(string input, string search)
        {
            string pattern = @"\b" + Regex.Escape(search) + @"\b";
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

    }
}

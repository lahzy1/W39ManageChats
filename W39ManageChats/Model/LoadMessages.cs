using System;
using System.Diagnostics;
using System.Windows.Controls;
using System.Xml.Linq;

namespace W39ManageChats.ViewModel
{
    public class LoadMessages
    {
        /*
         * Gets all messages from the XML file, sorts them by sentiment, and adds them to a list box.
         */
        public void LoadChatMessages(ListBox positiveChatListBox, ListBox sadChatListBox, ListBox neutralListBox)
        {
            try
            {
                string fileName = "messages.xml";
                XDocument xdoc = XDocument.Load(fileName);

                positiveChatListBox.Items.Clear();

                foreach (XElement xElement in xdoc.Root.Elements())
                {
                    string sentiment = xElement.Name.LocalName;
                    Debug.WriteLine(sentiment + " sentiment");
                    foreach (XElement messageElement in xElement.Elements("message"))
                    {
                        string message = messageElement.Value;

                        ListBoxItem item = new ListBoxItem();
                        item.Content = message;

                        if (sentiment == "positive")
                        {
                            positiveChatListBox.Items.Add(item);
                        }
                        else if (sentiment == "negative")
                        {
                            sadChatListBox.Items.Add(item);
                        }
                        else if (sentiment == "neutral")
                        {
                            neutralListBox.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                System.Windows.MessageBox.Show("Error loading chat messages: " + exception.Message);
            }
        }
    }
}
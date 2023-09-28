using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using W39ManageChats.Helpers;
using W39ManageChats.Model;
using W39ManageChats.ViewModel;

namespace W39ManageChats.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICommand RemoveMessageCommand { get; private set; }
        public ICommand SearchWordCommand { get; private set; }
        LoadMessages loadedMessages = new LoadMessages();
        WordSearch wordSearch = new WordSearch();
        private ListBox currentListBox;
        private object selectedItem;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            loadedMessages.LoadChatMessages(positiveChatListBox, negativeChatListBox, neutralChatListBox);
            RemoveMessageCommand = new RelayCommand(RemoveMessages);
            SearchWordCommand = new RelayCommand(SearchWord);
        }

        private void SearchWord(object parameter)
        {
            string word = searchTextBox.Text;
            wordSearch.SearchForWord(word, positiveChatListBox, negativeChatListBox, neutralChatListBox);
            Result.Text = "The search found '" + word + "' " + wordSearch.positiveWordCount + " times in positive, " + wordSearch.neutralWordCount +
                " times in neutral and " + wordSearch.negativeWordCount + " times in negative chat messages.";
            searchTextBox.Clear();
        }

        private void RemoveMessages(object parameter)
        {
            if (currentListBox != null && selectedItem != null)
            {
                currentListBox.Items.Remove(selectedItem);
            }
            else
            {
                Debug.WriteLine("Failed to remove");
            }
        }
        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            currentListBox = sender as ListBox;
            selectedItem = currentListBox.SelectedItem;
        }
    }
}

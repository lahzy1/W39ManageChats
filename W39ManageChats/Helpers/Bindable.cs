using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace W39ManageChats.Helpers
{
    /*
     * Inform listeners that a property has changed, which triggers the PropertyChanged event.
     */
    public class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void propertyIsChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}

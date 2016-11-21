using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTools.ViewHandler.MessageBox
{
    public class MessageBoxViewModel : ViewModelBase
    {
        private Dictionary<string, object> yesNoCancelButtons;

        public Dictionary<string, object> ButtonsData { get; private set; }
        public RelayCommand MessageRelayCommand { get; set; }
        public object Result { get; private set; }
        public string Text { get; private set; }
        public string Title { get; private set; }
        public UserControlButtonsViewModel UCButtonsViewModel { get; private set; }
        public MessageBoxViewModel(string title, string text, Dictionary<string, object> buttonsContent)
        {
            MessageRelayCommand = new RelayCommand(OnCommandExecute);
            Text = text;
            Title = title;
            UCButtonsViewModel = new UserControlButtonsViewModel(buttonsContent,OnCommandExecute);
        }

        public MessageBoxViewModel(Dictionary<string, object> yesNoCancelButtons)
        {
            this.yesNoCancelButtons = yesNoCancelButtons;
        }

        private void OnCommandExecute(object value)
        {
            Result = value;
        }

    }
}

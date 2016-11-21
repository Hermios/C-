using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardTools.ViewHandler.MessageBox
{
    public class UserControlButtonsViewModel : ViewModelBase
    {
        public Dictionary<string, object> ButtonsData { get; private set; }
        public RelayCommand MessageRelayCommand { get; set; }
        private bool _closeSignal;
        private Action<object> _onCloseAction;

        public UserControlButtonsViewModel(Dictionary<string, object> buttonsContent, Action<object> onCloseAction)
        {
            MessageRelayCommand = new RelayCommand(OnCommandExecute);
            ButtonsData = buttonsContent;
            _onCloseAction = onCloseAction;
        }

        private void OnCommandExecute(object value)
        {
            _onCloseAction(value);
            CloseSignal = true;
        }

        public bool CloseSignal
        {
            get
            {
                return _closeSignal;
            }

            set
            {
                _closeSignal = value;
                OnPropertyChanged("CloseSignal");
            }
        }
    }
}

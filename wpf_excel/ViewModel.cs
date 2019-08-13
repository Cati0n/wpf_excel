using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace wpf_excel
{
    sealed class ViewModel : INotifyPropertyChanged
    {
        private Model _model;
        
        

        public string InvoiceNumber
        {
            get { return _model.InvoiceNumber; }
            set
            {
                if (_model.InvoiceNumber == value)
                    return;

                _model.InvoiceNumber = value;
                OnPropertyChanged();
            }
        }

        public ViewModel()
        {
            _model = new Model
            {
                InvoiceNumber = _model.InvoiceNumber
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}


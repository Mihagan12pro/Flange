using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

public class Controller : INotifyPropertyChanged
{
    public Controller(bool readOnly)
    {
        this.readOnly= readOnly;
    }



    private bool readOnly;
    public bool ReadOnly
    {
        get
        {
            return readOnly;
        }
            set
        {
            if (readOnly != value)
            {
                readOnly = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}

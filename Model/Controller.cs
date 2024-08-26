using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

public class Controller : INotifyPropertyChanged
{
    public Controller(Visibility visibility)
    {
        this.visibility= visibility;
    }



    private Visibility visibility;
    public Visibility Visibility
    {
        get
        {
            return visibility;
        }
            set
        {
            if (visibility != value)
            {
                visibility = value;
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

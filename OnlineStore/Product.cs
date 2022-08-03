using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OnlineStore;

public class Product
{
    private string? _name;
    private double _price;
    private string? _imageUrl;

    public string? Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyRaised();
        }
    }

    public double Price
    {
        get { return _price; }
        set { _price = value; OnPropertyRaised(); }
    }

    public string? ImageUrl
    {
        get { return _imageUrl; }
        set { _imageUrl = value; OnPropertyRaised(); }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyRaised([CallerMemberName] string? propertyname = null)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
    }

}


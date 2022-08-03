using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OnlineStore
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> productCopy { get; set; }

        EditWindow editWindow;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Products = new ObservableCollection<Product>
            {
                new Product{ Name = "Coca-Cola", Price = 2, ImageUrl = "Images/cola.jpg"},
                new Product{ Name = "Fanta", Price = 2, ImageUrl = "Images/fanta.jpg"},
                new Product{ Name = "Pepsi", Price = 2, ImageUrl = "Images/pepsi.jpg"},
                new Product{ Name = "Lipton", Price = 1.90, ImageUrl = "Images/lipton.jpg"},
                new Product{ Name = "Snickers", Price = 1.20, ImageUrl = "Images/snickers.jpg"},
                new Product{ Name = "Bounty", Price = 1.30, ImageUrl = "Images/bounty.jpg"},
                new Product{ Name = "Adicto", Price = 1.70, ImageUrl = "Images/adicto.jpg"},
                new Product{ Name = "KitKat", Price = 1.30, ImageUrl = "Images/kitKat.jpg"},
                new Product{ Name = "Tuc", Price = 1.50, ImageUrl = "Images/tuc.jpg"},
                new Product{ Name = "Lays", Price = 3, ImageUrl = "Images/lays.jpg"}
            };

            productCopy = Products;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            editWindow = new();
            editWindow.Visibilty = "Visible";
            editWindow.Show();
        }
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text.Length != 0 && txbSearch.Text != "Search")
            {
                List<Product> productsList = new();
                string searchText = txbSearch.Text.ToLower();

                productsList = productCopy.Where(p => p.Name.ToLower().StartsWith(searchText)).ToList();

                ObservableCollection<Product> newList = new(productsList);
                Products = newList;
                lbox_products.ItemsSource = newList;
            }

            else if (txbSearch.Text.Length == 0)
            {
                Products = productCopy;
                lbox_products.ItemsSource = Products;
            }
        }

        private void lbox_products_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            editWindow = new();
            editWindow.Product = (sender as ListBox)?.SelectedItem as Product;
            editWindow.Visibilty = "Hidden";
            editWindow.Show();
        }
    }
}

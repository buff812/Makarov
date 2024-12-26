using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppLists
{
    public partial class MainWindow : Window
    {
        private List<UserControl1.Product> _allProducts;

        public MainWindow()
        {
            InitializeComponent();

            _allProducts = new List<UserControl1.Product>
            {
                new UserControl1.Product
                {
                    Name = "Ноутбук",
                    Description = "Высокопроизводительный ноутбук для работы и игр",
                    Manufacturer = "Dell",
                    Price = 85000,
                    Stock = 5,
                    ImagePath = "Images/laptop.png"
                },
                new UserControl1.Product
                {
                    Name = "Смартфон",
                    Description = "Смартфон с отличной камерой и большим экраном",
                    Manufacturer = "Samsung",
                    Price = 55000,
                    Stock = 8,
                    ImagePath = "Images/phone.png"
                },
                new UserControl1.Product
                {
                    Name = "Наушники",
                    Description = "Беспроводные наушники с шумоподавлением",
                    Manufacturer = "Sony",
                    Price = 12000,
                    Stock = 15,
                    ImagePath = "Images/headphones.png"
                }
            };

            ProductList.ItemsSource = _allProducts;

            InitializeManufacturerFilter();
        }

        private void InitializeManufacturerFilter()
        {
            if (_allProducts != null)
            {
                var manufacturers = _allProducts
                    .Select(p => p.Manufacturer)
                    .Distinct()
                    .OrderBy(m => m)
                    .ToList();

                foreach (var manufacturer in manufacturers)
                {
                    ManufacturerFilter.Items.Add(new ComboBoxItem { Content = manufacturer });
                }

                ManufacturerFilter.Items.Insert(0, new ComboBoxItem { Content = "Все" });
            }
        }

        private void UpdateProductList(IEnumerable<UserControl1.Product> products)
        {
            if (products != null)
            {
                ProductList.ItemsSource = products.ToList();
            }
        }

        private void SearchBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();

            if (_allProducts != null)
            {
                var filteredProducts = _allProducts.Where(p =>
                    p.Name.ToLower().Contains(searchText) ||
                    p.Description.ToLower().Contains(searchText));
                UpdateProductList(filteredProducts);
            }
        }

        private void ManufacturerFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedManufacturer = (ManufacturerFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedManufacturer == "Все")
            {
                UpdateProductList(_allProducts);
                return;
            }

            if (_allProducts != null)
            {
                var filteredProducts = _allProducts.Where(p => p.Manufacturer == selectedManufacturer);
                UpdateProductList(filteredProducts);
            }
        }

        private void SortAscending_Click(object sender, RoutedEventArgs e)
        {
            if (_allProducts != null)
            {
                var sortedProducts = _allProducts.OrderBy(p => p.Price);
                UpdateProductList(sortedProducts);
            }
        }
        private void SortDescending_Click(object sender, RoutedEventArgs e)
        {
            if (_allProducts != null)
            {
                var sortedProducts = _allProducts.OrderByDescending(p => p.Price);
                UpdateProductList(sortedProducts);
            }
        }
    }
}
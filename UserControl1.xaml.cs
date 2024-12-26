using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppLists;

namespace WpfAppLists
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();


        }
        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Manufacturer { get; set; }
            public double Price { get; set; }
            public int Stock { get; set; }
            public string ImagePath { get; set; }
        }
    }
}

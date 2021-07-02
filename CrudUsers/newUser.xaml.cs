using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace CrudUsers
{
    /// <summary>
    /// Logique d'interaction pour newUser.xaml
    /// </summary>
    public partial class newUser : Window
    {

        public MainWindow w;
        public DataRow row;
        public newUser(MainWindow window)
        {
            InitializeComponent();
            w = window;
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            row = w.dt.NewRow();
            row["firstName"] = FirstNameBox.Text;
            row["lastName"] = LastNameBox.Text;
            row["email"] = EmailBox.Text;
            row["password"] = PasswordBox.Text;
            w.dt.Rows.Add(row);
            w.UpdateDB();
            Close();
        }

    }
}

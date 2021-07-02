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
using CrudUsers.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Reflection;

namespace CrudUsers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection conn;
        MySqlDataAdapter adap;
        DataSet ds;
        MySqlCommandBuilder cmdbl;
        ObservableCollection<User> users = new ObservableCollection<User>();
        DataView dv;
        public DataTable dt;

        public MainWindow()
        {
            InitializeComponent();

            
        }
        public void UpdateDB()
        {
            try
            {
                cmdbl = new MySqlCommandBuilder(adap);
                adap.Update(ds, "User");
                MessageBox.Show("Information updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                adapterMySQl();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=foodzup;UID=foodzup;PASSWORD=foodzup;PORT=3366";
            conn = new MySqlConnection(connectionString);
            adapterMySQl();
        }
        public void adapterMySQl()
        {
            conn.Open();
            adap = new MySqlDataAdapter("Select Id, firstName, lastName, email, role, password, refreshToken, refreshTokenExpires, cityCode, sponsorCode, picture, createdAt, updatedAt from user", conn);
            ds = new System.Data.DataSet();
            adap.Fill(ds, "User");
            conn.Close();
            dt = ds.Tables[0];
            dv = new DataView();
            dv.Table = dt;
            dgUsers.ItemsSource = dv;

        }

        private void Filter_Button_Click(object sender, RoutedEventArgs e)
        {
            dv.RowFilter = FilterBox.Text;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                dataRowView.Delete();
            }

            catch (Exception ex)
            {
                MessageBox.Show("This is not a valid row !");
            }
        }


        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            adapterMySQl();
            FilterBox.Text = "";


        }

        private void CreateUser_Button_Click(object sender, RoutedEventArgs e)
        {
            newUser nw = new newUser(this);
            nw.Show();
        }
    }
}

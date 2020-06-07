using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;


namespace Parser
{
    public class DataINN
    {


        public string Компания { get; set; }
        public string ИНН { get; set; }
        public string Руководитель { get; set; }
        public string Адресс { get; set; }
        public string ОКВЭД { get; set; }
        public DataINN() { }
        public DataINN(string INN)
        {
            Компания = "";
            ИНН = INN;
            Руководитель = "";
            Адресс = "";
            ОКВЭД = "";
        }
        public DataINN(string Company, string INN, string Manager, string Address, string OKBED)
        {
            Компания = Company;
            ИНН = INN;
            Руководитель = Manager;
            Адресс = Address;
            ОКВЭД = OKBED;
        }

    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
               
        }

        List<DataINN> Data = new List<DataINN>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            File.Text = file.FileName;
            using (StreamReader str = new StreamReader(File.Text))
            {
                Data.Add(new DataINN(str.ReadLine()));

            }

            INNGrid.ItemsSource = Data;



        }

        private void CollectData_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

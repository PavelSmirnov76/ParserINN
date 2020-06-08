using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
using System.Xml.Serialization;

namespace Parser
{
    

    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {
               
        }

        List<Parser.Class.DataINN> Data = new List<Parser.Class.DataINN>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            File.Text = file.FileName;
            using (StreamReader str = new StreamReader(File.Text))
            {
                Data.Add(new Parser.Class.DataINN(str.ReadLine()));

            }
        }
        private void CollectData_Click(object sender, RoutedEventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://egrul.nalog.ru/index.html";
            foreach (var c in Data)
            {       
                driver.FindElement(By.XPath(@".//div[@id='uni_text_1']/div/input[@id='query']")).SendKeys(c.INN);
                driver.FindElement(By.XPath(@".//button[@id='btnSearch']")).Click();
                Thread.Sleep(3000);
                var CompanyName = driver.FindElements(By.XPath(".//div[@id='resultContent']/div/div[2]/a"));
                c.Company = CompanyName[0].Text;
                var InformationAboutCompany = driver.FindElements(By.XPath(".//div[@id='resultContent']/div/div[3]/div"));
                string Information = InformationAboutCompany[0].Text;
                c.Address = Information.Substring(0, Information.IndexOf(", ОГРН"));
                c.Manager = Information.Substring(Information.IndexOf("Директор: ")+10);
            }
            driver.Close();
            INNGrid.ItemsSource = Data;
        }

        private void Serialization_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Parser.Class.DataINN));
            SaveFileDialog file = new SaveFileDialog();
            file.ShowDialog();
            foreach (var c in Data)
            using (FileStream fs = new FileStream(file.FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, c);

            }
        }
    }
}

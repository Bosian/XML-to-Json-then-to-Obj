using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白頁項目範本已記錄在 http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.root = new Root();
            car.root.data = new Data();
            car.root.data.text = "1";
            car.root.data.value = "2";
            car.root.list = new List<string>();

            for (int f = 0; f < 1; f++)
            {
                car.root.list.Add(f.ToString());
            }

            string xml = ToXml(car);

            string newXML = "<root>\r\n  <data value=\"2\">1</data>\r\n  <list>0</list>\r\n</root>";
            Car newCar = ToObj<Car>(newXML);
        }

        private static string ToXml(Car car)
        {
            string json = JsonConvert.SerializeObject(car);
            XDocument xdoc = JsonConvert.DeserializeXNode(json);
            string xml = xdoc.ToString();

            return xml;
        }

        private static T ToObj<T>(string xml)
        {
            XDocument xdoc = XDocument.Parse(xml);
            string json = JsonConvert.SerializeXNode(xdoc);
            T obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }

    }

}

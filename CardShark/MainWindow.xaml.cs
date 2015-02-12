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

namespace CardShark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateOrganizationComboBox();
        }

        //private void PopulateClassList()
        //{
        //    var classList = new List<string>();
        //    var shapeType = typeof(Shape);
        //    foreach (Type type in Assembly.GetAssembly(shapeType).GetTypes())
        //    {
        //        if (type.IsSubclassOf(shapeType) && !type.IsAbstract)
        //        {
        //            classList.Add(type.Name);
        //        }
        //    }
        //    ShapeType.ItemsSource = classList;
        //}

        private void PopulateOrganizationComboBox()
        {
            Organization[] list = new Organization[]
            {
                new Organization(1,"WWE"),
                new Organization(2,"UFC")
            };

            var organizationList = new List<string>();

            for (int i = 0; i < list.Length; i++)
            {
                organizationList.Add(list[i].Name);
            }

            OrganizationComboBox.ItemsSource = organizationList;
        }

        private void OrganizationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrganizationComboBox.SelectedIndex != -1)
            {
                EventComboBox.IsEnabled = true;
                PopulateEvents(OrganizationComboBox.SelectedItem.ToString());
            }
        }

        private void PopulateEvents(string org)
        {
            if (org == "WWE")
            {
                Event[] wwelist = new Event[]
                {
                    new Event(1, "Royal Rumble", "01/25/2015"),
                    new Event(2, "Fastlane", "02/22/2015")
                };

                var eventList = new List<string>();

                for (int i = 0; i < wwelist.Length; i++)
                {
                    eventList.Add(wwelist[i].eventName + " (" + wwelist[i].eventDate + ")");
                }

                EventComboBox.ItemsSource = eventList;
            }
            else if (org == "UFC")
            {
                Event[] ufclist = new Event[]
                {
                    new Event(1, "UFC 183", "01/31/2015"),
                    new Event(2, "UFC 184", "02/28/2015")
                };

                var eventList = new List<string>();

                for (int i = 0; i < ufclist.Length; i++)
                {
                    eventList.Add(ufclist[i].eventName + " (" + ufclist[i].eventDate + ")");
                }

                EventComboBox.ItemsSource = eventList;
            }
        }
    }
}

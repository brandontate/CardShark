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
using System.Data.Entity;
using CardShark.Model;
using CardShark.Data;

namespace CardShark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Database.SetInitializer(new DummyData());
            InitializeComponent();
            PopulateOrganizationComboBox();
        }

        //private void PopulateOrganizationComboBox()
        //{
        //    Organization[] list = new Organization[]
        //    {
        //        new Organization(1,"WWE"),
        //        new Organization(2,"UFC")
        //    };


        private void PopulateOrganizationComboBox()
        {
            var organizationList = new List<string>();

            using (var context = new CardContext())
            {
                foreach (var organization in context.Organizations)
	            {
                    organizationList.Add(organization.Name);
	            }
            }
            OrganizationComboBox.ItemsSource = organizationList;
        }

        //    var organizationList = new List<string>();

        //    for (int i = 0; i < list.Length; i++)
        //    {
        //        organizationList.Add(list[i].Name);
        //    }

        //    OrganizationComboBox.ItemsSource = organizationList;
        //}

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
            var eventList = new List<string>();
            using (var context = new CardContext())
            {
                if (org == "WWE")
                {
                    foreach (var eventitem in context.Events)
                    {
                        if (eventitem.OrganizationID == 1)
                        {
                            eventList.Add(eventitem.eventName);
                        }
                    }
                }
                else if (org == "UFC")
                {
                    foreach (var eventitem in context.Events)
                    {
                        if (eventitem.OrganizationID == 2)
                        {
                            eventList.Add(eventitem.eventName);
                        }
                    }
                }
                EventComboBox.ItemsSource = eventList;
            }
        }


            //var window = cardArea;
            //int counter = 0;
            //var wrapPanel = new WrapPanel { Name = "Match" + counter, VerticalAlignment = VerticalAlignment.Top };
            //wrapPanel.Children.Add(new Label { Content = "Label", Margin = new Thickness(0, 0, 10, 0) });
            //wrapPanel.Children.Add(new Label { Content = "Vs.", Margin = new Thickness(0) });
            //wrapPanel.Children.Add(new Label { Content = "Label", Margin = new Thickness(10, 0, 50, 0) });
            //wrapPanel.Children.Add(new ComboBox { Name = "GuessComboBox", Width = 120, Margin = new Thickness(0, 0, 5, 0), IsEnabled = false });
            //wrapPanel.Children.Add(new Label { Content = "Label", Margin = new Thickness(5, 0, 0, 0) });
            //window.Children.Add(wrapPanel);
            //counter++;




        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            var window = cardArea;
            int counter = 0;
            var wrapPanel = new WrapPanel { Name = "Match" + counter, VerticalAlignment = VerticalAlignment.Top };
            wrapPanel.Children.Add(new Label { Content = "Label", Margin = new Thickness(0, 0, 10, 0) });
            wrapPanel.Children.Add(new Label { Content = "Vs.", Margin = new Thickness(0) });
            wrapPanel.Children.Add(new Label { Content = "Label", Margin = new Thickness(10, 0, 50, 0) });
            wrapPanel.Children.Add(new ComboBox { Name = "GuessComboBox", Width = 120, Margin = new Thickness(0, 0, 5, 0), IsEnabled = false });
            wrapPanel.Children.Add(new Label { Content = "Label", Margin = new Thickness(5, 0, 0, 0) });
            window.Children.Add(wrapPanel);
            counter++;
        }
    }
}

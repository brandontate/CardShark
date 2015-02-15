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

        private void OrganizationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrganizationComboBox.SelectedIndex != -1)
            {
                if (EventComboBox.SelectedIndex != -1)
                {
                    EventComboBox.SelectedIndex = -1;
                }
                int orgID = GetOrganizationID(OrganizationComboBox.SelectedItem.ToString());
                EventComboBox.IsEnabled = true;
                PopulateEvents(orgID);
            }
        }

        private void EventComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cardArea.Children.Count != 0)
            {
                cardArea.Children.Clear();
            }
            if(EventComboBox.SelectedIndex != -1) 
            {
                int eventID = GetEventID(EventComboBox.SelectedItem.ToString());
                PopulateEventCard(eventID);
            }
        }

        private int GetEventID(string eventName)
        {
            using (var context = new CardContext())
            {
                foreach (var eventItem in context.Events)
                {
                    if (eventName == eventItem.eventName)
                    {
                        return eventItem.id;
                    }            
                }
            }
            throw new ArgumentException();
        }

        private int GetOrganizationID(string company)
        {
            using (var context = new CardContext())
            {
                foreach (var organization in context.Organizations)
	            {
                    if (company == organization.Name)
                    {
                        return organization.id;
                    }
	            }
            }
            throw new ArgumentException();
        }

        private void PopulateEvents(int companyID)
        {
            var eventList = new List<string>();
            using (var context = new CardContext())
            {
                foreach (var eventItem in context.Events)
                {
                    if(companyID == eventItem.OrganizationID)
                    {
                        eventList.Add(eventItem.eventName);
                    }
                }
            }

            EventComboBox.ItemsSource = eventList;
        }

        private void PopulateEventCard(int eventID)
        {
            var matchList = new List<string>();
            var window = cardArea;
            int counter = 0;
            var wrapPanel = new WrapPanel { Name = "Match_" + counter, VerticalAlignment = VerticalAlignment.Top };
            var pickComboBox = new ComboBox { Name = "GuessComboBox_" + counter, Width = 120, Margin = new Thickness(0, 0, 5, 0) };
            using (var context = new CardContext())
            {
                foreach (var match in context.Matches)
                {
                    if (eventID == match.EventID)
                    {
                        wrapPanel.Children.Add(new Label { Name = "FirstOpponent_" + counter, Content = match.FirstOppenent, Margin = new Thickness(0, 0, 10, 0) });
                        wrapPanel.Children.Add(new Label { Content = "Vs.", Margin = new Thickness(0) });
                        wrapPanel.Children.Add(new Label { Name = "SecondOpponent_" + counter, Content = match.SecondOppenent, Margin = new Thickness(10, 0, 50, 0) });
                        wrapPanel.Children.Add(pickComboBox);
                        pickComboBox.Items.Add(match.FirstOppenent);
                        pickComboBox.Items.Add(match.SecondOppenent);
                        wrapPanel.Children.Add(new Label { Name = "FightResults_" + counter, Content = match.Winner, Margin = new Thickness(5, 0, 0, 0) });
                        window.Children.Add(wrapPanel);
                        counter++;
                    }
                }
            }
        }
    }
}

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

            //var query = from c in customers
            //            where c.Country == Countries.Greece
            //            select new { c.Name, c.City };

            using (var context = new CardContext())
            {
                var query = from o in context.Organizations
                            orderby o.Name
                            select o;

                foreach (var organization in query)
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
                var query = (from e in context.Events
                            orderby e.eventDate
                            select e).ToList();
                foreach (var eventItem in query)
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
            using (var context = new CardContext())
            {
                var query = (from m in context.Matches
                            where m.Event.id == eventID
                            select m).ToList();
                foreach (var match in query)
                {
                    var window = cardArea;
                    var wrapPanel = new WrapPanel { Name = "Match_" + match.MatchID, VerticalAlignment = VerticalAlignment.Top };
                    var pickComboBox = new ComboBox { Name = "GuessComboBox_" + match.MatchID, Width = 120, Margin = new Thickness(0, 0, 5, 0) };
                    var second = new Label { Name = "SecondOpponent_" + match.MatchID, Content = match.SecondOppenent, Margin = new Thickness(10, 0, 50, 0) };
                    var vs = new Label { Content = "Vs.", Margin = new Thickness(0) };
                    var first = new Label { Name = "FirstOpponent_" + match.MatchID, Content = match.FirstOppenent, Margin = new Thickness(0, 0, 10, 0) };
                    var winner = new Label { Name = "FightResults_" + match.MatchID, Content = match.Winner, Margin = new Thickness(5, 0, 0, 0) };

                    wrapPanel.Children.Add(first);
                    wrapPanel.Children.Add(vs);
                    wrapPanel.Children.Add(second);
                    wrapPanel.Children.Add(pickComboBox);
                    pickComboBox.Items.Add(match.FirstOppenent);
                    pickComboBox.Items.Add(match.SecondOppenent);
                    wrapPanel.Children.Add(winner);
                    window.Children.Add(wrapPanel);
                    //Grid.SetColumn(first, 1);
                    //Grid.SetColumn(vs, 2);
                    //Grid.SetColumn(second, 3);
                    //Grid.SetColumn(pickComboBox, 5);
                    //Grid.SetColumn(winner, 6);
                }
            }
        }
    }
}

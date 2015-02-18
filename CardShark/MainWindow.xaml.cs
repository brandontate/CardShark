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

        private int GetEventID(string checkEvent)
        {
            using (var context = new CardContext())
            {
                foreach (var eventItem in context.Events)
                {
                    var year = eventItem.eventDate.Year;
                    var month = eventItem.eventDate.Month;
                    var day = eventItem.eventDate.Day;
                    string eventName = String.Format("{0} ({1}/{2}/{3})", eventItem.eventName, month, day, year);  
                    if (checkEvent == eventName)
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

        private void OrganizationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cardArea.RowDefinitions.Count != 0) { cardArea.RowDefinitions.Clear(); }
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
                CalculateEventAccuracy(eventID);
            }
        }

        private void CalculateEventAccuracy(int eventID)
        {
            using (var context = new CardContext())
            {

                int guessCount = (from m in context.Matches
                            join g in context.Guesses
                            on m.id equals g.MatchID
                            where m.EventID == eventID
                            select m.Guesses).Count();

                if (guessCount != 0)
                {
                    int correct = (from m in context.Matches
                                   join g in context.Guesses
                                   on m.EventID equals eventID
                                   where m.Winner == g.guess
                                   select m).Count();

                    int total = (from m in context.Matches
                                 where m.EventID == eventID
                                 select m).Count();

                    string percent = string.Format("{0:0%}", ((double)correct / total));
                    EventAccuracy.Text = percent;
                }
                else
                {
                    EventAccuracy.Text = ""; 
                }
            }
        }

        private void PopulateOrganizationComboBox()
        {
            var organizationList = new List<string>();

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
                        var year = eventItem.eventDate.Year;
                        var month = eventItem.eventDate.Month;
                        var day = eventItem.eventDate.Day;
                        string eventName = String.Format("{0} ({1}/{2}/{3})", eventItem.eventName, month, day, year);
                        eventList.Add(eventName);
                    }
                }
            }
            EventComboBox.ItemsSource = eventList;
        }

        private void PopulateEventCard(int eventID)
        {
            if (cardArea.RowDefinitions.Count != 0) { cardArea.RowDefinitions.Clear(); }
            using (var context = new CardContext())
            {
                var query = (from e in context.Events
                             join m in context.Matches
                             on e.id equals m.EventID
                             where m.EventID == eventID
                             select new 
                             { 
                                 match_id = m.id,
                                 winner = m.Winner,
                                 first = m.FirstOppenent,
                                 second = m.SecondOppenent,
                                 date = e.eventDate,
                             }).ToList();
                int rowCount = 0;

                foreach (var match in query)
                {
                    var newRow = new RowDefinition();
                    newRow.Height = new GridLength(30);
                    cardArea.RowDefinitions.Add(newRow);
                    bool timeCheck = (DateTime.Now < match.date);
                    var first = new Label { Name = "FirstOpponent_" + match.match_id, Content = match.first };
                    var vs = new Label { Content = "Vs.", Margin = new Thickness(0) };
                    var second = new Label { Name = "SecondOpponent_" + match.match_id, Content = match.second };
                    var pickComboBox = new ComboBox { Name = "GuessComboBox_" + match.match_id, IsEnabled = timeCheck, Height = 25 };
                    var winner = new Label { Name = "FightResults_" + match.match_id, Content = match.winner };

                    cardArea.Children.Add(first);
                    cardArea.Children.Add(vs);
                    cardArea.Children.Add(second);
                    cardArea.Children.Add(pickComboBox);
                    pickComboBox.Items.Add(match.first);
                    pickComboBox.Items.Add(match.second);
                    pickComboBox.Items.Add("Not Sure");
                    cardArea.Children.Add(winner);

                    Grid.SetColumn(first, 0);
                    Grid.SetColumn(vs, 1);
                    Grid.SetColumn(second, 2);
                    Grid.SetColumn(pickComboBox, 3);
                    Grid.SetColumn(winner, 4);
                    Grid.SetRow(first, rowCount);
                    Grid.SetRow(vs, rowCount);
                    Grid.SetRow(second, rowCount);
                    Grid.SetRow(pickComboBox, rowCount);
                    Grid.SetRow(winner, rowCount);
                    rowCount++;
                }
            }
        }
    }
}

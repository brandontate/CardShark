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
                int rowCount = 0;

                var window = cardArea;
                //RowDefinition[] rowArr = new RowDefinition[query.Count];

                //for (int i = 0; i < query.Count; i++)
                //{
                //    rowArr[i] = new RowDefinition();
                //    rowArr[i].Height = new GridLength(30);
                //    window.RowDefinitions.Add(rowArr[i]);
                //}

                if (window.RowDefinitions.Count != 0) { window.RowDefinitions.Clear(); }

                foreach (var match in query)
                {
                    var newRow = new RowDefinition();
                    newRow.Height = new GridLength(30);
                    window.RowDefinitions.Add(newRow);

                    //var wrapPanel = new WrapPanel { Name = "Match_" + match.MatchID, VerticalAlignment = VerticalAlignment.Top };
                    var pickComboBox = new ComboBox { Name = "GuessComboBox_" + match.MatchID };
                    var second = new Label { Name = "SecondOpponent_" + match.MatchID, Content = match.SecondOppenent };
                    var vs = new Label { Content = "Vs.", Margin = new Thickness(0) };
                    var first = new Label { Name = "FirstOpponent_" + match.MatchID, Content = match.FirstOppenent };
                    var winner = new Label { Name = "FightResults_" + match.MatchID, Content = match.Winner };

                    window.Children.Add(first);
                    window.Children.Add(vs);
                    window.Children.Add(second);
                    window.Children.Add(pickComboBox);
                    pickComboBox.Items.Add(match.FirstOppenent);
                    pickComboBox.Items.Add(match.SecondOppenent);
                    window.Children.Add(winner);
                    //window.Children.Add(wrapPanel);

                    //Grid.SetColumnSpan(wrapPanel, 5);
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

        int counter = 0;

        //private void AddRow_Click(object sender, RoutedEventArgs e)
        //{
        //    var window = cardArea;
        //    var pickComboBox = new ComboBox { Name = "GuessComboBox_" + counter };
        //    var second = new Label { Name = "SecondOpponent_" + counter, Content = "Label" };
        //    var vs = new Label { Content = "Vs.", Margin = new Thickness(0) };
        //    var first = new Label { Name = "FirstOpponent_" + counter, Content = "Label" };
        //    var winner = new Label { Name = "FightResults_" + counter, Content = "Label" };
        //    var newRow = new RowDefinition();
        //    newRow.Height = new GridLength(30);

        //    window.RowDefinitions.Add(newRow);

        //    //var wrapPanel = new WrapPanel { Name = "Match" + counter, VerticalAlignment = VerticalAlignment.Top };
        //    window.Children.Add(first);
        //    window.Children.Add(vs);
        //    window.Children.Add(second);
        //    window.Children.Add(pickComboBox);
        //    window.Children.Add(winner);
        //    //window.Children.Add(wrapPanel);

        //    Grid.SetRow(first, counter);
        //    Grid.SetColumn(first, 0);
        //    Grid.SetRow(vs, counter);
        //    Grid.SetColumn(vs, 1);
        //    Grid.SetRow(second, counter);
        //    Grid.SetColumn(second, 2);
        //    Grid.SetRow(pickComboBox, counter);
        //    Grid.SetColumn(pickComboBox, 3);
        //    Grid.SetRow(winner, counter);
        //    Grid.SetColumn(winner, 4);

        //    counter++;
        //}
    }
}

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using CardShark.Data;
using CardShark.Repository;
using CardShark.Model;
using System.Windows.Documents;


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

        private void OrganizationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cardArea.RowDefinitions.Count != 0) { cardArea.RowDefinitions.Clear(); }
            if (OrganizationComboBox.SelectedIndex != -1)
            {
                if (EventComboBox.SelectedIndex != -1)
                {
                    EventComboBox.SelectedIndex = -1;
                }
                int orgID = GuessRepository.guessRepo.GetOrganizationID(OrganizationComboBox.SelectedItem.ToString());
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
            if (EventComboBox.SelectedIndex != -1)
            {
                int eventID = GuessRepository.guessRepo.GetEventID(EventComboBox.SelectedItem.ToString());
                PopulateEventCard(eventID);
                InsertEventAccuracy(eventID);
                
            }
        }

        private void InsertEventAccuracy(int eventID)
        {
            EventAccuracy.Text = GuessRepository.guessRepo.CalculateEventAccuracy(eventID);
        }

        private void PopulateOrganizationComboBox()
        {
            var organizationList = GuessRepository.guessRepo.GetOrganizations();
            OrganizationComboBox.ItemsSource = organizationList;
        }

        private void PopulateEvents(int companyID)
        {
            var eventList = GuessRepository.guessRepo.GetEvents(companyID);
            EventComboBox.ItemsSource = eventList;
        }

        private void PopulateEventCard(int eventID)
        {
            if (cardArea.RowDefinitions.Count != 0) { cardArea.RowDefinitions.Clear(); }
            List<Match> matches = GuessRepository.guessRepo.GetEventCard(eventID);
            int rowCount = 0;
            foreach (var match in matches)
            {
                var newRow = new RowDefinition();
                newRow.Height = new GridLength(30);
                cardArea.RowDefinitions.Add(newRow);
                //bool timeCheck = (DateTime.Now < match.EventDate);  IsEnabled = timeCheck, 
                var first = new Label { Name = "FirstOpponent_" + match.id, Content = match.FirstOppenent };
                var vs = new Label { Name = "vs", Content = "Vs.", Margin = new Thickness(0) };
                var second = new Label { Name = "SecondOpponent_" + match.id, Content = match.SecondOppenent };
                var pickComboBox = new ComboBox { Name = "GuessComboBox_" + match.id, Height = 25, };
                var winner = new Label { Name = "FightResults_" + match.id, Content = match.Winner };

                cardArea.Children.Add(first);
                cardArea.Children.Add(vs);
                cardArea.Children.Add(second);
                cardArea.Children.Add(pickComboBox); 
                pickComboBox.Items.Add(match.FirstOppenent);
                pickComboBox.Items.Add(match.SecondOppenent);
                pickComboBox.Items.Add("Not Sure");
                cardArea.Children.Add(winner);

                

                string previousGuess = GuessRepository.guessRepo.RetrieveSavedGuess(match.id);

                if (previousGuess != null)
                {
                    pickComboBox.SelectedIndex = pickComboBox.Items.IndexOf(previousGuess);
                }

                //foreach (ListBoxItem item in pickComboBox.Items)
                //{
                //    if (item.Name == previousGuess)
                //    {
                //        item.IsSelected = true;
                //    }
                //}

                

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<ComboBox> guessComboBoxes = GuessRepository.guessRepo.FindCardComboBoxes(cardArea);
            GuessRepository.guessRepo.UpdateGuess(guessComboBoxes);
        }
    }
}

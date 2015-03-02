using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CardShark.Model;
using System.Windows.Controls;


namespace CardShark.Repository
{
    public interface IGuessRepository
    {

        void Update(Match M, string current);
        List<ComboBox> FindCardComboBoxes(Grid name);
        void UpdateGuess(List<ComboBox> guessComboBoxes);

        //List Events based on organization
        List<string> GetEvents(int companyID);

        //List of available organizations
        List<string> GetOrganizations();

        //List of the card based on event
        List<Match> GetEventCard(int eventID);

        //Get Event ID
        int GetEventID(string checkEvent);

        //Get Organization ID
        int GetOrganizationID(string company);
        
        //Calculate Accuracy based on event
        string CalculateEventAccuracy(int eventID);
        
        //Calculate Accuracy based on organization

        //Get Saved Guess
        string RetrieveSavedGuess(int matchID);
        
    }
}

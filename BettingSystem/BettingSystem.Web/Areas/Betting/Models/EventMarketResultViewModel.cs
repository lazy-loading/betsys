using System.Collections.Generic;
using System.Linq;
using BettingSystem.Web.Models;

namespace BettingSystem.Web.Areas.Betting.Models
{
    public class EventMarketResultViewModel
    {
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public Dictionary<string, List<SelectionViewModel>> SelectionsByParticipant { get; set; }

        public List<string> GetSelectionHeaders() => SelectionsByParticipant.Select(x => x.Key).ToList();

        public SelectionViewModel[][] SelectionsAsParticipantArray()
        {
            SelectionViewModel[][] array =
                new SelectionViewModel[SelectionsByParticipant.Keys.Count][];

            int participantI = 0;
            foreach (KeyValuePair<string, List<SelectionViewModel>> x in SelectionsByParticipant)
            {
                array[participantI] = new SelectionViewModel[x.Value.Count];

                int selectionI = 0;
                foreach (SelectionViewModel y in x.Value)
                {
                    array[participantI][selectionI] = y;
                    selectionI++;
                }
                participantI++;
            }

            return array;
        }
    }
}
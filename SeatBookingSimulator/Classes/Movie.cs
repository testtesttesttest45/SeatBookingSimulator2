using System;
using System.Collections.Generic;
using System.Text;

namespace SeatBookingSimulator.Classes
{
    [Serializable]
    internal class Movie
    {
        public SeatDoubleLinkedList SeatList { get; set; }
        public List<int> PersonSeatList { get; set; }
        public List<int> PersonMaxList { get; set; }
        public List<SeatDoubleLinkedList> personActionList { get; set; }
        public string Row { get; set; }
        public string Seats { get; set; }
        public string RowDivider { get; set; }
        public string ColDivider { get; set; }

       
        public Movie()
        {
            SeatList = new SeatDoubleLinkedList();
            PersonSeatList = new List<int> { 0, 0, 0, 0 }; // person a b c d respectively
            PersonMaxList = new List<int> { 0, 0, 0, 0 };
            personActionList = new List<SeatDoubleLinkedList>();
            personActionList.Add(new SeatDoubleLinkedList());
            personActionList.Add(new SeatDoubleLinkedList());
            personActionList.Add(new SeatDoubleLinkedList());
            personActionList.Add(new SeatDoubleLinkedList());
        }
    }


}

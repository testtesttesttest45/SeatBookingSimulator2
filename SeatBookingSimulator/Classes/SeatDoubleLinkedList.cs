using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SeatBookingSimulator.Classes
{
    [Serializable]
    internal class SeatDoubleLinkedList
    {
        //"Always make sure" that this "start" refers to the first node of the list.
        public Node Start { get; set; }
        public Node Current { get; set; }
        public bool isUndoLast = false;
        public SeatDoubleLinkedList()
        {
            this.Start = null;
        }//End of constructor

        public void InsertNextToCurrent(Seat pSeatData)
        {
            Node newNode = new Node(pSeatData);
            if (this.Current == null)
            {
                this.Current = newNode;
                return;
            }
            Node p = this.Current;
            p.Next = newNode;
            newNode.Prev = p;
            this.Current = newNode;
        }

        public Node Undo()
        {
            if (this.Current.Prev != null)
            {
                Node p = this.Current;
                this.Current = p.Prev;
                return p;
            }
            if(isUndoLast == false)
            {
                isUndoLast = true;
                return this.Current;
            }
            return null;
        }

        public Node Redo()
        {
            if (isUndoLast == true)
            {
                isUndoLast = false;
                return this.Current;
            }
            if (this.Current.Next != null)
            {
                Node p = this.Current.Next;
                this.Current = p;
                return p;
            }
            return null;
        }

        public void InsertAtEnd(Seat pSeatData)
        {
            Node newNode = new Node(pSeatData);
            if (this.Start == null)
            {
                this.Start = newNode;
                return;
            }
            Node p = this.Start;
            // Traverse through the list until the p refers to
            // the last node.
            while (p.Next != null)
            {
                p = p.Next;
            }// End of while
            p.Next = newNode;
            newNode.Prev = p;
        }//End of InsertAtEnd
        public Seat SearchByRowAndColumn(int pRow, int pColumn)
        {
            Node p = this.Start;
            while (p != null)
            {
                if ((p.Seat.Column == pColumn) && (p.Seat.Row == pRow))
                {
                    //If the node referenced by p satisfies the
                    //search criteria, exit the loop
                    //The p will reference the node which satisfies
                    //the search criteria before exiting the while loop.
                    break;//Exit the while loop
                }
                p = p.Next; //Continue to the next node
            }//While loop
            if (p == null)
            {
                return null;
            }
            else
            {
                return p.Seat;
            }//End of if..else block
        }//End of SearchByRowAndColumn

     
        public List<Label> GenerateLabels()
        {
            List<Label> labels = new List<Label>();
            Node p = this.Start;
            while (p != null)
            {
                Label labelSeat = p.Seat.CreateLabel();
                labels.Add(labelSeat);

                p = p.Next; //Continue to the next node
            }//While loop
            if (p == null)
            {
                return labels;
            }
            else
            {
                return labels;
            }//End of if..else block
        }//End of SearchByRowAndColumn
    }//End of class
}//End of namespace

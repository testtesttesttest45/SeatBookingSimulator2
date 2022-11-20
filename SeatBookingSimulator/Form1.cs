using SeatBookingSimulator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeatBookingSimulator
{
    public partial class Form1 : Form
    {
        Movie movie = new Movie();
        //SeatDoubleLinkedList seatList = new SeatDoubleLinkedList();
        string personBooking = "";
        int personBookingNum = -1;
        Color personColor;
        //List<int> personSeatList = new List<int> { 0, 0, 0, 0 };
        //List<int> personMaxList = new List<int> { 0, 0, 0, 0 };
        bool isEditorMode = false; 
    
        public Form1()
        {
            InitializeComponent();
            textBox_MaxSeats.BackColor = Color.DarkGray;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
          Seat s = new Seat();  s.Row = 1;   s.Column = 1;
            seatList.InsertAtEnd(s);
            s = new Seat(); s.Row = 1; s.Column = 2;
            seatList.InsertAtEnd(s);
            s = new Seat(); s.Row = 1;  s.Column = 3;
            seatList.InsertAtEnd(s);
            labelMessage.Text = "Double Linked List has been built";
            

            Label labelSeat = new Label();//Instantiate a new Label type object, labelSeat
            labelSeat.Text = "A1";//Set the Text property by using a string
            labelSeat.Location = new Point(50, 50);//Create a Point type object which has x,y coordinate info
            labelSeat.Size = new Size(60,60);//Create a Size type object which has the width, height info
            labelSeat.TextAlign = ContentAlignment.MiddleCenter;//Align the Text to mid - center
            labelSeat.BorderStyle = BorderStyle.FixedSingle;//Make the border visible
            labelSeat.BackColor = Color.LightBlue;//Set the background color
            labelSeat.Font = new Font("Calibri", 14, FontStyle.Bold);
            labelSeat.ForeColor = Color.Black;
            labelSeat.Tag = new SeatInfo() { Row = 1, Column = 1 };
            // Adding this control to the Panel control, panelSeats
            this.panelSeats.Controls.Add(labelSeat);
            */
        }//End of Form1_Load

        private void UpdateDisabledSeats()
        {
            int maxRow = Convert.ToInt32(textRow.Text);
            int maxCol = Convert.ToInt32(textCol.Text);
            for (int y = 1; y <= maxRow; y++)
            {
                for (int x = 1; x <= maxCol; x++)
                {
                    Seat currSeat = movie.SeatList.SearchByRowAndColumn(y, x);


                    if (currSeat != null && currSeat.BookStatus == true)
                    {
                        Seat topSeat = movie.SeatList.SearchByRowAndColumn(y - 1, x);
                        Seat botSeat = movie.SeatList.SearchByRowAndColumn(y + 1, x);
                        Seat leftSeat = movie.SeatList.SearchByRowAndColumn(y, x - 1);
                        Seat rightSeat = movie.SeatList.SearchByRowAndColumn(y, x + 1);
                        if (topSeat != null && topSeat.BookStatus == false)
                        {
                            topSeat.CanBook = false;
                        }
                        if (botSeat != null && botSeat.BookStatus == false)
                        {
                            botSeat.CanBook = false;
                        }
                        if (leftSeat != null && leftSeat.BookStatus == false)
                        {
                            leftSeat.CanBook = false;
                        }
                        if (rightSeat != null && rightSeat.BookStatus == false)
                        {
                            rightSeat.CanBook = false;
                        }
                    }
                }
            }
            EnableAllSeats();
        }// end of UpdateDisabled seats for Disabling nearby seats booked by person X

        private void LabelSeat_Click(object sender, EventArgs e)
        {
            if (personBooking == "")
            {
                return;
            }

            string maxSeatsStr = textBox_MaxSeats.Text;
            if (maxSeatsStr == "")
            {
                MessageBox.Show("Please set a maximum number of seats first.");
                return;
            }

            int maxSeats = Convert.ToInt32(maxSeatsStr);
            Label label = (Label)sender;
            SeatInfo seatInfo = (SeatInfo)label.Tag;
            //MessageBox.Show(String.Format("Row {0} Column {1}",seatInfo.Row,seatInfo.Column));
            Seat seat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            if (seat.CanBook == false)
            {
                MessageBox.Show("Seat is disabled!");
                return;
            }

            if (seat.BookStatus == true && seat.BookByPerson != personBooking)
            {
                MessageBox.Show($"Seat is taken by Person {seat.BookByPerson}.");
                return;
            }

            if (seat.BookStatus == false)
            {
                if (movie.PersonSeatList[personBookingNum] + 1 > maxSeats)
                {
                    MessageBox.Show($"Max seats selected!");
                    return;
                }
                // test person seat list , seats booked by A
                int seatSelected = movie.PersonSeatList[personBookingNum];
                if (seatSelected > 0)
                {
                    Seat topSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row - 1, seatInfo.Column);
                    Seat botSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row + 1, seatInfo.Column);
                    Seat leftSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
                    Seat rightSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
                    bool isLeftSeatByPerson = false;
                    bool isTopSeatByPerson = false;
                    if (topSeat != null && topSeat.BookByPerson == personBooking)
                    {
                        isTopSeatByPerson = true;
                    }
                    bool isBotSeatByPerson = false;
                    if (botSeat != null && botSeat.BookByPerson == personBooking)
                    {
                        isBotSeatByPerson = true;
                    }
                    if (leftSeat != null)
                    {
                        if (leftSeat.BookByPerson == personBooking)
                        {
                            isLeftSeatByPerson = true;
                        }
                        

                    }
                    bool isRightSeatByPerson = false;
                    if (rightSeat != null)
                    {
                        if (rightSeat.BookByPerson == personBooking)
                        {
                            isRightSeatByPerson = true;
                        }
                       
                    }
                    if ((isRightSeatByPerson == false && isLeftSeatByPerson == false) && (isTopSeatByPerson == false && isBotSeatByPerson == false))
                    {
                        MessageBox.Show("Can only book adjacent seats!");
                        return;
                    }
                }
                else
                {
                    Seat leftSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
                    Seat rightSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
                    if ((rightSeat != null && rightSeat.BookByPerson != "") || (leftSeat != null && leftSeat.BookByPerson != ""))
                    {
                        MessageBox.Show("Cannot book a seat beside another person");
                        return;
                    }
                }
                // not booked, after click,become status true according to colour of who booked
                seat.BookStatus = true;
                label.BackColor = personColor;
                seat.BookByPerson = personBooking;
                movie.PersonSeatList[personBookingNum] += 1; // more than 1, cannot book more than 2, less than 1, unlimited books
                movie.personActionList[personBookingNum].InsertNextToCurrent(seat);
            }
            else
            {
                // deselecting seats , deselecting by adjacent only
                int seatSelected = movie.PersonSeatList[personBookingNum];
                if (seatSelected > 0)
                {
                    Seat leftSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
                    Seat rightSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
                    bool isLeftSeatByPerson = false;
                    if (leftSeat != null)
                    {
                        if (leftSeat.BookByPerson == personBooking)
                        {
                            isLeftSeatByPerson = true;
                        }
                    }
                    bool isRightSeatByPerson = false;
                    if (rightSeat != null)
                    {
                        if (rightSeat.BookByPerson == personBooking)
                        {
                            isRightSeatByPerson = true;
                        }
                    }
                    if (isRightSeatByPerson == true && isLeftSeatByPerson == true)
                    {
                        MessageBox.Show("Can only book adjacent seats/ Unselect outer seats booked first");
                        return;
                    }
                }// available seats, booked by no one
                seat.BookStatus = false; // status false = not booked
                label.BackColor = Color.LightGray;
                seat.BookByPerson = "";
                movie.PersonSeatList[personBookingNum] -= 1; // negative one, if not seats will give error: max  seats selected
                movie.personActionList[personBookingNum].InsertNextToCurrent(seat);
            }

        }//labelSeatClick

        public void PerformClickSeat(Label label, SeatInfo seatInfo)
        {
            string maxSeatsStr = textBox_MaxSeats.Text;
            int maxSeats = Convert.ToInt32(maxSeatsStr);
            Seat seat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
            if (seat.CanBook == false)
            {
                MessageBox.Show("Seat is disabled!");
                return;
            }

            if (seat.BookStatus == true && seat.BookByPerson != personBooking)
            {
                MessageBox.Show($"Seat is taken by Person {seat.BookByPerson}.");
                return;
            }

            if (seat.BookStatus == false)
            {
                if (movie.PersonSeatList[personBookingNum] + 1 > maxSeats)
                {
                    MessageBox.Show($"Max seats selected!");
                    return;
                }
                // test person seat list , seats booked by A
                int seatSelected = movie.PersonSeatList[personBookingNum];
                if (seatSelected > 0)
                {
                    Seat leftSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
                    Seat rightSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
                    bool isLeftSeatByPerson = false;
                    if (leftSeat != null)
                    {
                        if (leftSeat.BookByPerson == personBooking)
                        {
                            isLeftSeatByPerson = true;
                        }
                        

                    }
                    bool isRightSeatByPerson = false;
                    if (rightSeat != null)
                    {
                        if (rightSeat.BookByPerson == personBooking)
                        {
                            isRightSeatByPerson = true;
                        }
                        
                    }
                    if (isRightSeatByPerson == false && isLeftSeatByPerson == false)
                    {
                        MessageBox.Show("Can only book adjacent seats!");
                        return;
                    }
                }
                else
                {
                    Seat leftSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
                    Seat rightSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
                    if ((rightSeat != null && rightSeat.BookByPerson != "") || (leftSeat != null && leftSeat.BookByPerson != ""))
                    {
                        MessageBox.Show("Cannot book a seat beside another person");
                        return;
                    }
                }
                // not booked, after click,become status true according to colour of who booked
                seat.BookStatus = true;
                label.BackColor = personColor;
                seat.BookByPerson = personBooking;
                movie.PersonSeatList[personBookingNum] += 1; // more than 1, cannot book more than 2, less than 1, unlimited books
            }
            else
            {
                // deselecting seats , deselecting by adjacent only
                int seatSelected = movie.PersonSeatList[personBookingNum];
                if (seatSelected > 0)
                {
                    Seat leftSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column - 1);
                    Seat rightSeat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column + 1);
                    bool isLeftSeatByPerson = false;
                    if (leftSeat != null)
                    {
                        if (leftSeat.BookByPerson == personBooking)
                        {
                            isLeftSeatByPerson = true;
                        }
                    }
                    bool isRightSeatByPerson = false;
                    if (rightSeat != null)
                    {
                        if (rightSeat.BookByPerson == personBooking)
                        {
                            isRightSeatByPerson = true;
                        }
                    }
                    if (isRightSeatByPerson == true && isLeftSeatByPerson == true)
                    {
                        MessageBox.Show("Can only book adjacent seats/ Unselect outer seats booked first");
                        return;
                    }
                }// available seats, booked by no one
                seat.BookStatus = false; // status false = not booked
                label.BackColor = Color.LightGray;
                seat.BookByPerson = "";
                movie.PersonSeatList[personBookingNum] -= 1; // negative one, if not seats will give error: max  seats selected
            }
        }

        public Label GetPositionLabel(SeatInfo si)
        {
            foreach (Control c in this.panelSeats.Controls)
            {
                Label label = (Label)c;
                SeatInfo seatInfo = (SeatInfo)label.Tag;
                if(seatInfo.Row == si.Row && seatInfo.Column == si.Column)
                {
                    return label;
                }
            }
            return null;
        }

        public void Undo()
        {
            if(personBookingNum < 0)
            {
                return;
            }
            Node n = movie.personActionList[personBookingNum].Undo();
            if(n != null)
            {
                SeatInfo si = new SeatInfo();
                si.Column = n.Seat.Column;
                si.Row = n.Seat.Row;
                Label l = GetPositionLabel(si);
                if (l != null)
                {
                    PerformClickSeat(l, si);
                }
                
            }
        }

        public void Redo()
        {
            if (personBookingNum < 0)
            {
                return;
            }
            Node n = movie.personActionList[personBookingNum].Redo();
            if (n != null)
            {
                SeatInfo si = new SeatInfo();
                si.Column = n.Seat.Column;
                si.Row = n.Seat.Row;
                Label l = GetPositionLabel(si);
                if (l != null)
                {
                    PerformClickSeat(l, si);
                }

            }
        }

        public void CreateSeats(object sender, System.EventArgs e)
        {
            // Reset the panel each time Generate Seats is clicked
            movie.SeatList = new SeatDoubleLinkedList();
            this.panelSeats.Controls.Clear();
            labelMessage.Text = ("Generated Seats in Normal Mode!");
            if (textRow.Text == "" || textCol.Text == "")
            {
                return;
            }
            int maxRow = Convert.ToInt32(textRow.Text);
            int maxCol = Convert.ToInt32(textCol.Text);
            string dividerRow = textBox_RowDiv.Text;// 2,3,6 -> 10
            string dividerCol = textBox_ColDiv.Text;
            string[] divRowList = new string[0];
            string[] divColList = new string[0];
            if (dividerRow != "")
            {
                divRowList = dividerRow.Split(","); //["2", "3", "6"]["10"]
            }
            if (dividerCol != "")
            {
                divColList = dividerCol.Split(",");
            }

            int x, y;
            int seatWidth = 60;
            int seatHeight = 60;
            int divRowIndex = -1;

            int rowShifted = 0;

            if (divRowList.Length > 0)
            {
                divRowIndex = 0;
            }

            for (y = 1; y <= maxRow; y++)
            {
                int divColIndex = -1;
                int colShifted = 0;
                if (divRowList.Length > 0 && divRowIndex < divRowList.Length)
                {
                    if (y == Convert.ToInt32(divRowList[divRowIndex]) + 1)
                    {
                        rowShifted += 1;
                        divRowIndex += 1;
                    }
                }
                if (divColList.Length > 0)
                {
                    divColIndex = 0;
                }
                for (x = 1; x <= maxCol; x++)
                {
                    if (divColList.Length > 0 && divColIndex < divColList.Length)
                    {
                        if (x == Convert.ToInt32(divColList[divColIndex]) + 1)
                        {
                            colShifted += 1;
                            divColIndex += 1;
                        }
                    }
                    int finalY = y + rowShifted;
                    int finalX = x + colShifted;
                    Label labelSeat = new Label()
                    {
                        Width = seatWidth,
                        Height = seatHeight,
                        Top = 75 + (y * (seatHeight + 20) + rowShifted * seatHeight),
                        Left = 10 + (x * (seatWidth + 20) + colShifted * seatWidth),
                        BackColor = Color.LightPink
                    };
                    Seat seat = new Seat();
                    seat.Row = y;
                    seat.Column = x;
                    seat.BookByPerson = "";
                    seat.CanBook = true;
                    labelSeat.Click += new System.EventHandler(LabelSeat_Click);
                    labelSeat.Text = seat.ComputeSeatLabel();
                    labelSeat.Tag = new SeatInfo() { Row = y, Column = x };
                    labelSeat.Enabled = false;
                    movie.SeatList.InsertAtEnd(seat);
                    this.panelSeats.Controls.Add(labelSeat);
                };
            }

        }//End of method

        
        

        private void EnableAllSeats()
        {
            textBox_MaxSeats.Enabled = true;
            textBox_MaxSeats.BackColor = Color.LightGray;
            foreach (Control c in this.panelSeats.Controls)
            {
                Label label = (Label)c;
                SeatInfo seatInfo = (SeatInfo)label.Tag;
                Seat seat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                c.Enabled = true;
                if (seat != null && seat.BookStatus == true) // if seat is booked
                {
                    continue;
                }

                if (seat.CanBook)
                {
                    c.BackColor = Color.LightGray;
                }
                else
                {
                    c.BackColor = Color.LightPink;
                }
            }
        }
        
        private void UpdateMaxSeats()
        {
            if (movie.PersonSeatList[personBookingNum] > 0)
            {
                textBox_MaxSeats.Text = movie.PersonSeatList[personBookingNum].ToString();
            }
            else
            {
                textBox_MaxSeats.Text = "";
            }
        }
        private void ButtonA_Click(object sender, EventArgs e)
        {
            Button ButtonA = (Button)sender;
            labelMessage.Text = ("Person A is booking");
            EnableAllSeats();
            personBooking = "A";
            personBookingNum = 0;
            personColor = ButtonA.BackColor;
            UpdateMaxSeats();
            UpdateDisabledSeats();
        }

        private void ButtonB_Click(object sender, EventArgs e)
        {
            Button ButtonB = (Button)sender;
            labelMessage.Text = ("Person B is booking");
            EnableAllSeats();
            personBooking = "B";
            personBookingNum = 1;
            personColor = ButtonB.BackColor;
            UpdateMaxSeats();
            UpdateDisabledSeats();
        }

        private void ButtonC_Click(object sender, EventArgs e)
        {
            Button ButtonC = (Button)sender;
            labelMessage.Text = ("Person C is booking");
            EnableAllSeats();
            personBooking = "C";
            personBookingNum = 2;
            personColor = ButtonC.BackColor;
            UpdateMaxSeats();
            UpdateDisabledSeats();
        }

        private void ButtonD_Click(object sender, EventArgs e)
        {
            Button ButtonD = (Button)sender;
            labelMessage.Text = ("Person D is booking");
            EnableAllSeats();
            personBooking = "D";
            personBookingNum = 3;
            personColor = ButtonD.BackColor;
            UpdateMaxSeats();
            UpdateDisabledSeats();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulation Reset!");
            personBookingNum = -1;
            personBooking = "";
            ButtonA.Enabled = true;
            ButtonA.Text = ("Person A Booking");
            ButtonB.Enabled = true;
            ButtonB.Text = ("Person B Booking");
            ButtonC.Enabled = true;
            ButtonC.Text = ("Person C Booking");
            ButtonD.Enabled = true;
            ButtonD.Text = ("Person D Booking");
            movie.PersonSeatList = new List<int> { 0, 0, 0, 0 };
            movie.PersonMaxList = new List<int> { 0, 0, 0, 0 };
            CreateSeats(sender, e);
            
        }

        private void ButtonEditorMode_Click(object sender, EventArgs e)
        {
            Button editorButton = (Button)sender;
            if (!isEditorMode)
            {
                editorButton.Text = "Exit Editor Mode";
                labelMessage.Text = ("Seat editor enabled");
                isEditorMode = true;
            }
            else
            {
                editorButton.Text = "Enter Editor Mode";
                labelMessage.Text = ("Exited seat editor");
                
                isEditorMode = false;
            }
        }

       

        private void ButtonEnableAll_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.panelSeats.Controls)
            {
                Label label = (Label)c;
                SeatInfo seatInfo = (SeatInfo)label.Tag;
                Seat seat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                if (seat.BookStatus == false)
                {
                    seat.CanBook = true;
                    c.BackColor = Color.LightGray;

                }

                //c.BackColor = Color.LightGray; 
            }
            //enableAllSeats();

        }

        private void ButtonDisableAll_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.panelSeats.Controls)
            {
                Label label = (Label)c;
                SeatInfo seatInfo = (SeatInfo)label.Tag;
                Seat seat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                if (seat.BookStatus == false)
                {
                    seat.CanBook = false;
                    c.BackColor = Color.LightPink;

                }
            }
            //disableAllSeats();
            //Button buttonDisableAll = (Button)sender;
            //foreach (Control c in this.panelSeats.Controls)
            //{
            //    Label label = (Label)c;
            //    SeatInfo seatInfo = (SeatInfo)label.Tag;
            //    c.Enabled = false;
            //    c.BackColor = Color.LightPink; // here
            //}
        }

        // save and render Max seats value when I go back to a person's booking button
        private void MaxSeatsChanged(object sender, EventArgs e)
        {
            if (personBookingNum > -1)
            {
                if (textBox_MaxSeats.Text != "")
                {
                    int newMaxSeat = Convert.ToInt32(textBox_MaxSeats.Text);
                    int personMaxSeat = movie.PersonMaxList[personBookingNum];
                    int seatCreated = movie.PersonSeatList[personBookingNum];
                    if (seatCreated <= newMaxSeat)
                    {
                        movie.PersonMaxList[personBookingNum] = newMaxSeat;
                    }
                    else
                    {
                        MessageBox.Show("Selected seats is more than max seats, unselect your seats first.");
                        textBox_MaxSeats.Text = $"{personMaxSeat}";
                    }
                }

            }
        }

        private void TextRow_TextChanged(object sender, EventArgs e)
        {
            movie.Row = ((TextBox)sender).Text;
        }

        private void TextCol_TextChanged(object sender, EventArgs e)
        {
            movie.Seats = ((TextBox)sender).Text;
        }

        private void TextBox_RowDiv_TextChanged(object sender, EventArgs e)
        {
            movie.RowDivider = ((TextBox)sender).Text;
        }

        private void TextBox_ColDiv_TextChanged(object sender, EventArgs e)
        {
            movie.ColDivider = ((TextBox)sender).Text;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data is saved!");
            Stream stream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\..\\Data"));
            saveFileDialog.Filter = "Data Files (*.dat)|*.dat";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    BinaryFormatter f = new BinaryFormatter();
                    f.Serialize(stream, movie);
                    stream.Close();
                }
            }
        }
        //Load
        public void CreateSeatsFromLoadedMovie()
        {
            this.panelSeats.Controls.Clear();
            //-- 3 commands to appreciate the concept of dynamically added
            //-- event handler method
            //Button button = (Button)sender;
            //button.Enabled = false;
            //MessageBox.Show("Click");
            if (textRow.Text == "" || textCol.Text == "")
            {
                return;
            }
            int maxRow = Convert.ToInt32(textRow.Text);
            int maxCol = Convert.ToInt32(textCol.Text);
            string dividerRow = textBox_RowDiv.Text;// what if 2,3,6 -> 10
            string dividerCol = textBox_ColDiv.Text;
            string[] divRowList = new string[0]; // assigning empty string array
            string[] divColList = new string[0];
            if (dividerRow != "")
            //compute actual numbers and compute in row div, assign top and left pos, each square is top left to bottom right, 60x60,
            //for extra spacing to seperate squares, row shift codes divides more distance
            {
                divRowList = dividerRow.Split(","); //["2", "3", "6"]["10"]
            }
            if (dividerCol != "")
            {
                divColList = dividerCol.Split(",");
            }

            int x, y;
            int seatWidth = 60;
            int seatHeight = 60;
            int divRowIndex = -1; // int must not be null, assign a magic value 

            int rowShifted = 0;

            if (divRowList.Length > 0)
            {
                divRowIndex = 0;
            }

            for (y = 1; y <= maxRow; y++) // by horizontal, y , row
            {
                int divColIndex = -1;
                int colShifted = 0;
                if (divRowList.Length > 0 && divRowIndex < divRowList.Length)
                {
                    if (y == Convert.ToInt32(divRowList[divRowIndex]) + 1)
                    {
                        rowShifted += 1;
                        divRowIndex += 1;
                    }
                }
                if (divColList.Length > 0)
                {
                    divColIndex = 0;
                }
                for (x = 1; x <= maxCol; x++)
                {
                    if (divColList.Length > 0 && divColIndex < divColList.Length)
                    {
                        if (x == Convert.ToInt32(divColList[divColIndex]) + 1)
                        {
                            colShifted += 1;
                            divColIndex += 1;
                        }
                    }
                    int finalY = y + rowShifted;
                    int finalX = x + colShifted;
                    Label labelSeat = new Label()
                    {
                        Width = seatWidth,
                        Height = seatHeight,
                        Top = 75 + (y * (seatHeight + 20) + rowShifted * seatHeight),
                        Left = 10 + (x * (seatWidth + 20) + colShifted * seatWidth),
                        BackColor = Color.LightPink
                    };
                    Seat seat = movie.SeatList.SearchByRowAndColumn(y, x);
                    labelSeat.Click += new System.EventHandler(LabelSeat_Click);
                    labelSeat.Text = seat.ComputeSeatLabel();
                    labelSeat.Tag = new SeatInfo() { Row = y, Column = x };
                    labelSeat.Enabled = false;
                    this.panelSeats.Controls.Add(labelSeat);
                };
            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {

            string filePath;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\..\\Data"));
            openFileDialog.Filter = "Data Files (*.dat)|*.dat";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;

                BinaryFormatter f = new BinaryFormatter();
                Stream stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read);

                if (stream.Length != 0)
                {
                    movie = (Movie)f.Deserialize(stream);
                }
                stream.Close();
            }

            textBox_RowDiv.Text = movie.RowDivider;
            textBox_ColDiv.Text = movie.ColDivider;
            textRow.Text = movie.Row;
            textCol.Text = movie.Seats;
            CreateSeatsFromLoadedMovie();
            foreach (Control c in this.panelSeats.Controls)
            {
                // save all seat status,including colours
                Label label = (Label)c;
                SeatInfo seatInfo = (SeatInfo)label.Tag;
                Seat seat = movie.SeatList.SearchByRowAndColumn(seatInfo.Row, seatInfo.Column);
                if (seat != null && seat.BookStatus == true)
                {
                    if (seat.BookByPerson == "A")
                    {
                        c.BackColor = ButtonA.BackColor;
                    }
                    else if (seat.BookByPerson == "B")
                    {
                        c.BackColor = ButtonB.BackColor;
                    }
                    else if (seat.BookByPerson == "C")
                    {
                        c.BackColor = ButtonC.BackColor;
                    }
                    else if (seat.BookByPerson == "D")
                    {
                        c.BackColor = ButtonD.BackColor;
                    }

                    continue;
                }

                if (seat.CanBook)
                {
                    c.BackColor = Color.LightGray;
                }
                else
                {
                    c.BackColor = Color.LightPink;
                }
            }

        }//End of buttonLoad_Click

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            Undo();

        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            Redo();
        }


    }//End of Form1 class


}//End of namespace

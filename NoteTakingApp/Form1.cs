using System.Data;

namespace NoteTakingApp
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();   //dataTable instance is going to act as the backend for our data grid view
        bool editing = false;   

        public NoteTaker()
        {
            InitializeComponent();
        }

        private void NoteTaker_Load(object sender, EventArgs e) 
        {
            notes.Columns.Add("Title");  //column in the data table grid
            notes.Columns.Add("Note");  //column in the data table grid
            notes.Columns.Add("Review"); //column in the data table grid
            
            previousNotes.DataSource = notes;  //will display the info in notes
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)  //delete method
        {
            try
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();  //choose a cell in the column and delete
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid note chosen");
            }
        }

        private void loadButton_Click(object sender, EventArgs e)  //load method
        {
            titleBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            reviewBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[2].ToString();

            editing = true;
        }

        private void saveButton_Click(object sender, EventArgs e)  //save method
        {
            if(editing)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = noteBox.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Review"] = reviewBox.Text;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text, reviewBox.Text);
            }
            //titleBox.Text = "";
            //noteBox.Text = "";
            //reviewBox.Text = "";

            titleBox.Clear();
            noteBox.Clear();
            reviewBox.Clear();

            editing = false;  
        }

        private void newNoteButton_Click(object sender, EventArgs e)  //new method
        {
            //titleBox.Text = "";
            //noteBox.Text = "";
            //reviewBox.Text = "";

            titleBox.Clear();
            noteBox.Clear();
            reviewBox.Clear();
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)  //be able to double click on the data grid table and show the loaded information
        {
            titleBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            reviewBox.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[2].ToString();
            editing = true;
        }

        private void previousNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
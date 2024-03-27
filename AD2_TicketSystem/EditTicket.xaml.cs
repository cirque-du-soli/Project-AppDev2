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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace AD2_TicketSystem
{
    /// <summary>
    /// Interaction logic for NewTicket.xaml
    /// </summary>
    public partial class EditTicket : Window
    {
        public int ticketId;
        public EditTicket(int ticketId)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            LoadTicketDetails(ticketId);
        }

        //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-C7TQR79C;Initial Catalog=TicketDb;Integrated Security=True;Encrypt=False");
        SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;Initial Catalog=TicketDb;Trusted_Connection=True;Integrated Security=True;Encrypt=False");
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            CbxDepartment.Items.Add("Finance");
            CbxDepartment.Items.Add("Accounts");
            CbxDepartment.Items.Add("HR");
            CbxDepartment.Items.Add("Administration");
            CbxDepartment.Items.Add("IT");
        }

        private void LoadTicketDetails(int studentId)
        {
            
                try
                {
                    
                    string query = @"SELECT Department, Subject, RegDate, Details FROM Tickets WHERE ID= @Id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", ticketId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            CbxDepartment.SelectedValue = reader["Department"].ToString();
                            TbxSubject.Text = reader["Subject"].ToString();
                            
                           
                            TbxRegDatePicker.SelectedDate = Convert.ToDateTime(reader["RegDate"]);
                           
                            TbxMessageDetails.Text = reader["Details"] != DBNull.Value ? reader["Details"].ToString() : "";
                        }
                        reader.Close();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            
        }

        private void ClearFields()
        {
            CbxDepartment.SelectedValue = null;
            TbxSubject.Text = "";
            TbxRegDatePicker.SelectedDate = null;
            TbxMessageDetails.Text = "";
            

        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsValid()
        {
           
            if (TbxSubject.Text == string.Empty)
            {

                MessageBox.Show("Subject is Empty");
                return false;
            }
            if (CbxDepartment.SelectedValue == null)
            {

                MessageBox.Show("Department must be Selected");
                return false;
            }
            if (TbxRegDatePicker.Text == string.Empty)
            {

                MessageBox.Show("Date should be Entered");
                return false;
            }
            return true;
        }

        private void BtnEditTicket_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    
                    SqlCommand cmd = new SqlCommand("UPDATE Tickets SET Department = @department, Subject = @subject, RegDate = @regDate, Details=@message WHERE ID = @Id;", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@department", CbxDepartment.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@subject", TbxSubject.Text);
                    cmd.Parameters.AddWithValue("@regDate", TbxRegDatePicker.SelectedDate);
                    cmd.Parameters.AddWithValue("@message", TbxMessageDetails.Text );
                    cmd.Parameters.AddWithValue("@Id", ticketId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Ticket Updated Successfully");
                    this.Close();

                }
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            
        }
    }
}

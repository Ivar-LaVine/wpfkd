using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace DentalCabinetWPF.Pages
{
    /// <summary>
    /// Interaction logic for DoctorsPageDlg.xaml
    /// </summary>
    public partial class DoctorsPageDlg : Page
    {
        private Page Page;
        private SqlConnection DatabaseSqlConnection;
        int Mode;
        int Role;
        int DocId;
        private OpenFileDialog OpenFileDialog;
        public DoctorsPageDlg(Page Page, SqlConnection DatabaseSqlConnection, int Mode, int Role, int DocId)
        {
            InitializeComponent();
            this.Page = Page;
            this.DatabaseSqlConnection = DatabaseSqlConnection;
            this.Mode = Mode;
            this.Role = Role;
            this.DocId = DocId;
            LoadPositions();
            LoadInfo();
            OpenFileDialog = new OpenFileDialog();
        }
        private void LoadInfo()
        {
            if (Mode == 0)
            {
                CaptionLabel.Content = "Add a new doctor";
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                PatronymicTextBox.Text = "";
                PhoneTextBox.Text = "";
                MailTextBox.Text = "";
                PositionComboBox.SelectedValue = -1;
            }
            else
            {
                CaptionLabel.Content = "Edit current doctor";
                string s = "select surname, name, patronymic, dob, phone, mail, reg_date, pos_id " +
                    "from doctor " +
                    "where (doc_id = " + DocId.ToString() + ") ";
                SqlCommand Command = new SqlCommand(s, DatabaseSqlConnection);
                SqlDataReader Reader = Command.ExecuteReader();
                Reader.Read();
                SurnameTextBox.Text = Reader.GetString(0);
                NameTextBox.Text = Reader.GetString(1);
                PatronymicTextBox.Text = Reader.GetString(2);
                DOBDatePicker.SelectedDate = Reader.GetDateTime(3);
                PhoneTextBox.Text = Reader.GetString(4);
                MailTextBox.Text = Reader.GetString(5);
                Reg_DateDatePicker.SelectedDate = Reader.GetDateTime(6);
                PositionComboBox.SelectedValue = Reader.GetInt32(7);
            }
        }
        private bool CheckInfo()
        {
            bool Result = false;
            if (SurnameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Surname not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                SurnameTextBox.Focus();
                return Result;
            }
            if (NameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Name not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                NameTextBox.Focus();
                return Result;
            }
            if (PatronymicTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Patronymic not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                PatronymicTextBox.Focus();
                return Result;
            }
            if (DOBDatePicker.Text.Trim() == "")
            {
                MessageBox.Show("Date of birth not specified", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                DOBDatePicker.Focus();
                return Result;
            }
            if (PhoneTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Phone not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                PhoneTextBox.Focus();
                return Result;
            }
            if (MailTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Mail not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                MailTextBox.Focus();
                return Result;
            }
            if (Reg_DateDatePicker.Text.Trim() == "")
            {
                MessageBox.Show("Registration date not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                Reg_DateDatePicker.Focus();
                return Result;
            }
            if (PositionComboBox.SelectedValue.Equals(-1))
            {
                MessageBox.Show("Position not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                PositionComboBox.Focus();
                return Result;
            }
            Result = true;
            return Result;
        }
        private bool SaveInfo()
        {
            string s;
            try
            {
                // surname, name, patronymic, dob, phone, mail, reg_date, pos_id
                SqlCommand Command;
                if (Mode == 0)
                {
                    s = "insert into doctor(surname, name, patronymic, dob, phone, mail, reg_date, pos_id) " +
                        "values ('" + SurnameTextBox.Text + "', '" +
                        NameTextBox.Text + "', '" +
                        PatronymicTextBox.Text + "', '" +
                        DOBDatePicker.Text + "', '" +
                        PhoneTextBox.Text + "', '" +
                        MailTextBox.Text + "', '" +
                        Reg_DateDatePicker.Text + "', '" +
                        PositionComboBox.SelectedValue.ToString() + "'); " +
                        "select SCOPE_IDENTITY() ";
                    Command = new SqlCommand(s, DatabaseSqlConnection);
                    DocId = Convert.ToInt32(Command.ExecuteScalar());
                }
                else
                {
                    s = "update doctor " +
                        "set surname = '" + SurnameTextBox.Text + "', " +
                        "name = '" + NameTextBox.Text + "', " +
                        "patronymic = '" + PatronymicTextBox.Text + "', " +
                        "dob = '" + DOBDatePicker.Text + "', " +
                        "phone = '" + PhoneTextBox.Text + "', " +
                        "mail = '" + MailTextBox.Text + "', " +
                        "reg_date = '" + Reg_DateDatePicker.Text + "', " +
                        "pos_id = " + PositionComboBox.SelectedValue.ToString() + " " +
                        "where (doc_id = " + DocId.ToString() + "); ";
                    Command = new SqlCommand(s, DatabaseSqlConnection);
                    Command.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Failed to save information to database", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                return false;
            }
        }

        private void LoadPositions()
        {
            string s = "select pos_id, title " +
                "from position ";
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(s, DatabaseSqlConnection);
            DataSet DataSet = new DataSet();
            DataSet.Clear();
            SqlDataAdapter.Fill(DataSet);
            PositionComboBox.ItemsSource = DataSet.Tables[0].DefaultView;
            PositionComboBox.SelectedValuePath = "pos_id";
            PositionComboBox.DisplayMemberPath = "title";
        }
        private void CloseDialog(bool NeedUpdate)
        {
            if (Page is Pages.DoctorsPage)
            {
                (Page as Pages.DoctorsPage).HideDialog();
                if (NeedUpdate)
                {
                    (Page as Pages.DoctorsPage).UpdateDataGrid(DocId);
                }
            } else if (Page is Pages.TimeTablePage)
            {
                (Page as Pages.TimeTablePage).HideDialog();
                if (NeedUpdate)
                {
                    (Page as Pages.TimeTablePage).UpdateDataGrid(DocId);
                }
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CloseDialog(false);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfo() && SaveInfo())
            {
                CloseDialog(true);
            }
        }
    }
}

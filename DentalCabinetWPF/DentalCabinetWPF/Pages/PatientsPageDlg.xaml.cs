using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for PatientsPageDlg.xaml
    /// </summary>
    public partial class PatientsPageDlg : Page
    {
        private Page Page;
        private SqlConnection DatabaseSqlConnection;
        int Mode;
        int Role;
        int PatId;
        private OpenFileDialog OpenFileDialog;
        public PatientsPageDlg(Page Page, SqlConnection DatabaseSqlConnection, int Mode, int Role, int PatId)
        {
            InitializeComponent();
            this.Page = Page;
            this.DatabaseSqlConnection = DatabaseSqlConnection;
            this.Mode = Mode;
            this.Role = Role;
            this.PatId = PatId;
            LoadInfo();
            OpenFileDialog = new OpenFileDialog();
        }
        private void LoadInfo()
        {
            if (Mode == 0)
            {
                CaptionLabel.Content = "Add a new patient";
                SurnameTextBox.Text = "";
                NameTextBox.Text = "";
                PatronymicTextBox.Text = "";
                SnillsTextBox.Text = "";
                OMSTextBox.Text = "";
                PassportTextBox.Text = "";
            }
            else
            {
                CaptionLabel.Content = "Edit current patient";
                string s = "select surname, name, patronymic, dob, snills, oms, passport " +
                    "from patient " +
                    "where (pat_id = " + PatId.ToString() + ") ";
                SqlCommand Command = new SqlCommand(s, DatabaseSqlConnection);
                SqlDataReader Reader = Command.ExecuteReader();
                Reader.Read();
                SurnameTextBox.Text = Reader.GetString(0);
                NameTextBox.Text = Reader.GetString(1);
                PatronymicTextBox.Text = Reader.GetString(2);
                DOBDatePicker.SelectedDate = Reader.GetDateTime(3);
                SnillsTextBox.Text = Reader.GetString(4);
                OMSTextBox.Text = Reader.GetString(5);
                PassportTextBox.Text = Reader.GetString(6);
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
            if (SnillsTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Snills not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                SnillsTextBox.Focus();
                return Result;
            }
            if (OMSTextBox.Text.Trim() == "")
            {
                MessageBox.Show("OMS not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                OMSTextBox.Focus();
                return Result;
            }
            if (PassportTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Passport not specified.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);
                PassportTextBox.Focus();
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
                // surname, name, patronymic, dob, snills, oms, passport
                SqlCommand Command;
                if (Mode == 0)
                {
                    s = "insert into patient(surname, name, patronymic, dob, snills, oms, passport) " +
                        "values ('" + SurnameTextBox.Text + "', '" +
                        NameTextBox.Text + "', '" +
                        PatronymicTextBox.Text + "', '" +
                        DOBDatePicker.Text + "', '" +
                        SnillsTextBox.Text + "', '" +
                        OMSTextBox.Text + "', '" +
                        PassportTextBox.Text + "'); " +
                        "select SCOPE_IDENTITY() ";
                    Command = new SqlCommand(s, DatabaseSqlConnection);
                    PatId = Convert.ToInt32(Command.ExecuteScalar());
                }
                else
                {
                    s = "update patient " +
                        "set surname = '" + SurnameTextBox.Text + "', " +
                        "name = '" + NameTextBox.Text + "', " +
                        "patronymic = '" + PatronymicTextBox.Text + "', " +
                        "dob = '" + DOBDatePicker.Text + "', " +
                        "snills = '" + SnillsTextBox.Text + "', " +
                        "oms = '" + OMSTextBox.Text + "', " +
                        "passport = '" + PassportTextBox.Text + "' " +
                        "where (pat_id = " + PatId.ToString() + "); ";
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
        private void CloseDialog(bool NeedUpdate)
        {
            if (Page is Pages.PatientsPage)
            {
                (Page as Pages.PatientsPage).HideDialog();
                if (NeedUpdate)
                {
                    (Page as Pages.PatientsPage).UpdateDataGrid(PatId);
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

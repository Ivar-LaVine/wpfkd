using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        private SqlConnection DatabaseSqlConnection;
        private DataSet PatientsDataSet;
        private int Role;
        public PatientsPage(SqlConnection DatabaseSqlConnection, int Role)
        {
            InitializeComponent();
            this.DatabaseSqlConnection = DatabaseSqlConnection;
            this.Role = Role;
            PatientsDataSet = new DataSet();
            UpdateDataGrid(-1);
            SetControlsEnabled();
        }
        private void SetControlsEnabled()
        {
            AddPatientButton.IsEnabled = (DialogFrame.Visibility == Visibility.Hidden);
            EditPatientButton.IsEnabled = (DialogFrame.Visibility == Visibility.Hidden);
            DeletePatientButton.IsEnabled = (DialogFrame.Visibility == Visibility.Hidden);
        }
        public void UpdateDataGrid(int PatId)
        {
            if ((PatId < 0) && (PatientsDataGrid.Items.Count > 0))
                PatId = (int)PatientsDataGrid.SelectedValue;
            string s = "select p.pat_id, p.surname, p.name, p.patronymic, p.dob, p.snills, p.oms, p.passport " +
                "from patient p ";
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(s, DatabaseSqlConnection);
            PatientsDataSet.Clear();
            SqlDataAdapter.Fill(PatientsDataSet);
            PatientsDataGrid.DataContext = PatientsDataSet.Tables[0];
            PatientsDataGrid.SelectedValuePath = "pat_id";
            if (PatientsDataSet.Tables[0].Rows.Count > 0)
            {
                PatientsDataGrid.SelectedValue = PatId;
                if (PatientsDataGrid.SelectedIndex < 0)
                {
                    PatientsDataGrid.SelectedIndex = 0;
                }
            }
            SetControlsEnabled();
        }
        private void ShowDialog(Page Page)
        {
            Grid.SetColumnSpan(DataStackPanel, 1);
            DialogGridSplitter.Visibility = Visibility.Visible;
            DialogFrame.Visibility = Visibility.Visible;
            DialogFrame.Navigate(Page);
            SetControlsEnabled();
        }
        public void HideDialog()
        {
            DialogFrame.Visibility = Visibility.Hidden;
            DialogGridSplitter.Visibility = Visibility.Hidden;
            Grid.SetColumnSpan(DataStackPanel, 3);
            DialogFrame.Navigate(null);
            while (DialogFrame.CanGoBack)
            {
                DialogFrame.RemoveBackEntry();
            }
            SetControlsEnabled();
        }
        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            ShowDialog(new Pages.PatientsPageDlg(this, DatabaseSqlConnection, 0, 0, -1));
        }
        private void EditPatientButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (EditPatientButton.IsEnabled)
            {
                int PatId = (int)PatientsDataGrid.SelectedValue;
                ShowDialog(new Pages.PatientsPageDlg(this, DatabaseSqlConnection, 1, 0, PatId));
            }
        }
        private void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the selected row?",
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question,
                MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                try
                {
                    int PatId = (int)PatientsDataGrid.SelectedValue;

                    string s = "delete from patient " +
                               "where (pat_id = " + PatId.ToString() + ") ";
                    SqlCommand Command = new SqlCommand(s, DatabaseSqlConnection);
                    Command.ExecuteNonQuery();
                    UpdateDataGrid(-1);
                }
                catch
                {
                    MessageBox.Show("Unable to delete row because it is used in other database directories",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.None);
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchAttribute = "surname";
            if (SearchComboBox.SelectedIndex == 0) searchAttribute = "surname";
            if (SearchComboBox.SelectedIndex == 1) searchAttribute = "name";
            if (SearchComboBox.SelectedIndex == 2) searchAttribute = "patronymic";
            string s = "select p.pat_id, p.surname, p.name, p.patronymic, p.dob, p.snills, p.oms, p.passport " +
               "from patient p " +
               "where p." + searchAttribute + " like '%" + SearchTextBox.Text + "%'";
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(s, DatabaseSqlConnection);
            PatientsDataSet.Clear();
            SqlDataAdapter.Fill(PatientsDataSet);
            PatientsDataGrid.DataContext = PatientsDataSet.Tables[0];
            PatientsDataGrid.SelectedValuePath = "pat_id";
        }
    }
}

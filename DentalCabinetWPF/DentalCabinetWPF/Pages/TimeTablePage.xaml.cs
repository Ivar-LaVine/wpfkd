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
    /// Логика взаимодействия для TimeTablePage.xaml
    /// </summary>
    public partial class TimeTablePage : Page
    {
        private SqlConnection DatabaseSqlConnection;
        private DataSet DoctorsDataSet;
        private DataSet TimeTableDataSet;
        private int Role;
        public TimeTablePage(SqlConnection DatabaseSqlConnection, int Role)
        {
            InitializeComponent();
            this.DatabaseSqlConnection = DatabaseSqlConnection;
            this.Role = Role;
            DoctorsDataSet = new DataSet();
            TimeTableDataSet = new DataSet();
            DoctorsDataGrid.SelectionChanged += DoctorsDataGrid_SelectionChanged;
            UpdateDataGrid(-1);
            SetControlsEnabled();
        }

        private void DoctorsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DoctorsDataGrid.SelectedIndex > 0)
            {
                int DocId = (int)DoctorsDataGrid.SelectedIndex;
                UpdateDataGrid(DocId);
            }
        }

        private void SetControlsEnabled()
        {
            AddDoctorButton.IsEnabled = (DialogFrame.Visibility == Visibility.Hidden);
            EditDoctorButton.IsEnabled = (DialogFrame.Visibility == Visibility.Hidden);
            DeleteDoctorButton.IsEnabled = (DialogFrame.Visibility == Visibility.Hidden);
        }
        public void UpdateDataGrid(int DocId)
        {
            if ((DocId < 0) && (DoctorsDataGrid.Items.Count > 0))
                DocId = (int)DoctorsDataGrid.SelectedValue;
            string s = "select d.doc_id, d.surname, d.name, d.patronymic, d.dob, d.phone, d.mail, d.reg_date, p.title as position " +
                "from doctor d " +
                "inner join position p on (d.pos_id = p.pos_id) ";
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(s, DatabaseSqlConnection);
            DoctorsDataSet.Clear();
            SqlDataAdapter.Fill(DoctorsDataSet);
            DoctorsDataGrid.DataContext = DoctorsDataSet.Tables[0];
            DoctorsDataGrid.SelectedValuePath = "doc_id";
            if (DoctorsDataSet.Tables[0].Rows.Count > 0)
            {
                DoctorsDataGrid.SelectedValue = DocId;
                if (DoctorsDataGrid.SelectedIndex < 0)
                {
                    DoctorsDataGrid.SelectedIndex = 0;
                }
            }
            SetControlsEnabled();
            UpdateTimeTableDataGrid(-1);
        }
        public void UpdateTimeTableDataGrid(int TimId)
        {
            if ((TimId < 0) && (TimeTableDataGrid.Items.Count > 0))
                TimId = (int)TimeTableDataGrid.SelectedValue;
            string s = "select d.title as day, t.beg_time, t.end_time " +
                "from timetable t " +
                "inner join day d on (d.day_id = t.day_id) " +
                "inner join doctor doc on (doc.doc_id = t.doc_id) " +
                "where t.doc_id = (" + DoctorsDataGrid.SelectedValue + ")";
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(s, DatabaseSqlConnection);
            TimeTableDataSet.Clear();
            SqlDataAdapter.Fill(TimeTableDataSet);
            TimeTableDataGrid.DataContext = TimeTableDataSet.Tables[0];
            TimeTableDataGrid.SelectedValuePath = "tim_id";
            if (TimeTableDataSet.Tables[0].Rows.Count > 0)
            {
                TimeTableDataGrid.SelectedValue = TimId;
                if (TimeTableDataGrid.SelectedIndex < 0)
                {
                    TimeTableDataGrid.SelectedIndex = 0;
                }
            }
            SetControlsEnabled();
        }
        private void ShowDialog(Page Page)
        {
            DialogGridSplitter.Visibility = Visibility.Visible;
            DialogFrame.Visibility = Visibility.Visible;
            DialogFrame.Navigate(Page);
            SetControlsEnabled();
        }
        public void HideDialog()
        {
            DialogFrame.Visibility = Visibility.Hidden;
            DialogGridSplitter.Visibility = Visibility.Hidden;
            DialogFrame.Navigate(null);
            while (DialogFrame.CanGoBack)
            {
                DialogFrame.RemoveBackEntry();
            }
            SetControlsEnabled();
        }
        private void AddDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            ShowDialog(new Pages.DoctorsPageDlg(this, DatabaseSqlConnection, 0, 0, -1));
        }

        private void EditDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditDoctorButton.IsEnabled)
            {
                int DocId = (int)DoctorsDataGrid.SelectedValue;
                ShowDialog(new Pages.DoctorsPageDlg(this, DatabaseSqlConnection, 1, 0, DocId));
            }
        }

        private void DeleteDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the selected row?",
                "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question,
                MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                try
                {
                    int DocId = (int)DoctorsDataGrid.SelectedValue;

                    string s = "delete from doctor " +
                               "where (doc_id = " + DocId.ToString() + ") ";
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
            string s = "select d.doc_id, d.surname, d.name, d.patronymic, d.dob, d.phone, d.mail, d.reg_date, p.title as position " +
               "from doctor d " +
               "inner join position p on (d.pos_id = p.pos_id) where d." + searchAttribute + " like '%" + SearchTextBox.Text + "%'";
            SqlDataAdapter SqlDataAdapter = new SqlDataAdapter(s, DatabaseSqlConnection);
            DoctorsDataSet.Clear();
            SqlDataAdapter.Fill(DoctorsDataSet);
            DoctorsDataGrid.DataContext = DoctorsDataSet.Tables[0];
            DoctorsDataGrid.SelectedValuePath = "doc_id";
        }

        private void AddTimeTableButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTimeTableButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditTimeTableButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

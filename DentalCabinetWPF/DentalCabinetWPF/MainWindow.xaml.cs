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

namespace DentalCabinetWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection DatabaseSqlConnection;
        private int Role;
        private List<Page> ActivePages = new List<Page>();
        private int CurrentPageIndex = -1;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Properties.Settings properties = new Properties.Settings();
                DatabaseSqlConnection = new SqlConnection("Data Source=DEFENDER;Initial Catalog=dental_db;Integrated Security=True;MultipleActiveResultSets=True");
                DatabaseSqlConnection.Open();
                Role = 0;
                SetControlsEnabled();
            }
            catch
            {
                MessageBox.Show("Невозможно подключиться к базе данных", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                Close();
            }
        }
        private int GetActivePageIndexByType(Type PageType)
        {
            int Index = ActivePages.Count - 1;
            while ((Index >= 0) && (ActivePages[Index].GetType() != PageType))
            {
                Index--;
            }
            return Index;
        }
        private void ShowPage(Type PageType)
        {
            Page Page;
            if (PageType != null)
            {
                int Index = GetActivePageIndexByType(PageType);
                if (Index < 0)
                {
                    Page = (Page)Activator.CreateInstance(PageType, DatabaseSqlConnection, Role);
                    ActivePages.Add(Page);
                    CurrentPageIndex = ActivePages.Count - 1;
                }
                else
                {
                    Page = ActivePages[Index];
                    CurrentPageIndex = Index;
                }
            }
            else
            {
                Page = null;
            }
            PageFrame.Navigate(Page);


        }
        private void SetControlsEnabled()
        {
            PreviousPageButton.IsEnabled = (CurrentPageIndex > 0);
            NextPageButton.IsEnabled = (CurrentPageIndex < ActivePages.Count - 1);
            ClosePageButton.IsEnabled = (ActivePages.Count > 0);
        }
        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPageIndex--;
            PageFrame.Navigate(ActivePages[CurrentPageIndex]);
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPageIndex++;
            PageFrame.Navigate(ActivePages[CurrentPageIndex]);
        }

        private void ClosePageButton_Click(object sender, RoutedEventArgs e)
        {
            Page Page;

            ActivePages.RemoveAt(CurrentPageIndex);
            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex--;
                Page = ActivePages[CurrentPageIndex];
            }
            else
            {
                if (CurrentPageIndex < ActivePages.Count)
                {
                    Page = ActivePages[CurrentPageIndex];
                }
                else
                {
                    Page = null;
                }
            }
            PageFrame.Navigate(Page);
        }

        private void DoctorsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(Pages.DoctorsPage));
        }

        private void PageFrame_LoadCompleted(object sender, NavigationEventArgs e)
        {
            while (PageFrame.CanGoBack) { PageFrame.RemoveBackEntry(); };
            SetControlsEnabled();
        }

        private void PatientsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(Pages.PatientsPage));
        }

        private void PositionsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TalonsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TimeTableButton_Click(object sender, RoutedEventArgs e)
        {
            ShowPage(typeof(Pages.TimeTablePage));
        }
    }
}

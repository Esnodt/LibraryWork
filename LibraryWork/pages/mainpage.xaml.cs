using LibraryWork.context;
using LibraryWork.sql;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryWork.pages
{
    /// <summary>
    /// Логика взаимодействия для mainpage.xaml
    /// </summary>
    public partial class mainpage : Page
    {
        public mainpage()
        {
            InitializeComponent();
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            Readers deleterow = (Readers)MainGrid.SelectedItem;
            if (MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (deleterow != null)
                {
                    dbcontext.db.Readers.Remove(deleterow);
                    dbcontext.db.SaveChanges();
                    Page_Loaded(null, null);
                    MessageBox.Show("Вы удалили данные", "Увдомление");
                }

                else
                {
                    MessageBox.Show("Вы не выбрали элемент для удаления", "Увдомление");

                }
            }

            }

            private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            Readers editrow = (Readers)MainGrid.SelectedItem;
            if (editrow != null)
            {
                NavigationService.Navigate(new editpage(editrow));
            }
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new addpage());
        }

        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MainGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainGrid.ItemsSource = dbcontext.db.Readers.ToList();


        }

        private void tbsearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainGrid.ItemsSource = dbcontext.db.Readers.Where(item => item.Name.Contains(tbsearch.Text) || item.Surname.Contains(tbsearch.Text) || item.Books.Author.Contains(tbsearch.Text) || item.Books.Title.Contains(tbsearch.Text)).ToList();
        }
    }
}

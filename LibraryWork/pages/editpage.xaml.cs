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
    /// Логика взаимодействия для editpage.xaml
    /// </summary>
    public partial class editpage : Page
    {
        private Readers editmain;
        public editpage()
        {
            InitializeComponent();
        }

        public editpage(Readers editmain)
        {
            InitializeComponent();

            this.editmain = editmain;

            tbName.Text = editmain.Name;
            tbSurname.Text = editmain.Surname;

            tbReturnDate.SelectedDate = (DateTime)editmain.Return.ReturnDate;

            tbDateOfIssue.SelectedDate = (DateTime)editmain.Extradition.DateOfIssue;

            tbTitle.Text = editmain.Books.Title;
            tbAuthor.Text = editmain.Books.Author;

            tbHomeAddress.Text = editmain.InfoReader.HomeAddress;
            tbTelephone.Text = editmain.InfoReader.Telephone;


        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void editbutton_Click(object sender, RoutedEventArgs e)
        {


            Readers Save = dbcontext.db.Readers.FirstOrDefault(item => item.ID == editmain.ID);

            Save.Name = tbName.Text;
            Save.Surname = tbSurname.Text;

            Save.Return.ReturnDate = tbReturnDate.SelectedDate;
            Save.Extradition.DateOfIssue = tbDateOfIssue.SelectedDate;

            Save.InfoReader.HomeAddress = tbHomeAddress.Text;
            Save.InfoReader.Telephone = tbTelephone.Text;

            Save.Books.Author = tbAuthor.Text;
            Save.Books.Title = tbTitle.Text;

            dbcontext.db.SaveChanges();

            MessageBox.Show("Вы изменили данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            NavigationService.GoBack();

        }

        private void deletebutton_Click(object sender, RoutedEventArgs e)
        {
            tbName.Text = null;
            tbSurname.Text = null;
            tbReturnDate.Text = null;
            tbDateOfIssue.Text = null;
            tbTitle.Text = null;
            tbAuthor.Text = null;
            tbHomeAddress.Text = null;
            tbTelephone.Text = null;
        }
    }
}

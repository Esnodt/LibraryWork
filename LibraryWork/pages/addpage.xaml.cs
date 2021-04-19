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
    /// Логика взаимодействия для addpage.xaml
    /// </summary>
    public partial class addpage : Page
    {
        public addpage()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void addbuton_Click(object sender, RoutedEventArgs e)
        {
            Readers addReaders = new Readers();
            Books addBooks = new Books();
            InfoReader addInfoReader = new InfoReader();
            Return addReturn = new Return();
            Extradition addExtradition = new Extradition();

            addReaders.Name = tbName.Text;
            addReaders.Surname = tbSurname.Text;

            addReturn.ReturnDate = tbReturnDate.SelectedDate;

            addExtradition.DateOfIssue = tbDateOfIssue.SelectedDate;

            addBooks.Title = tbTitle.Text;
            addBooks.Author = tbAuthor.Text;

            addInfoReader.HomeAddress = tbHomeAddress.Text;
            addInfoReader.Telephone = tbTelephone.Text;

            addReaders.ID = addBooks.ID;
            addReaders.ID = addInfoReader.ID;
            addReaders.ID = addReturn.ID;
            addReaders.ID = addExtradition.ID;

            dbcontext.db.Readers.Add(addReaders);
            dbcontext.db.Books.Add(addBooks);
            dbcontext.db.InfoReader.Add(addInfoReader);
            dbcontext.db.Return.Add(addReturn);
            dbcontext.db.Extradition.Add(addExtradition);

            dbcontext.db.SaveChanges();

            MessageBox.Show("Вы добавили данные", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);


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

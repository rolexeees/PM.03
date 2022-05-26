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

namespace WorkWithSubscribers
{
    public partial class MainWindow : Window
    {
        List<User> userList = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            using (var conect = new TeleconNevaEntities())
            {
                userList = conect.Users.ToList();
                foreach (var user in userList)
                {
                    UsersComboBox.Items.Add(user.Фамилия);
                }

            }
            SubsTextBox.Visibility = Visibility.Collapsed;
            EquipTextBox.Visibility = Visibility.Collapsed;
            AssetsTextBox.Visibility = Visibility.Collapsed;
            BillingTextBox.Visibility = Visibility.Collapsed;
            SupprtTextBox.Visibility = Visibility.Collapsed;
            crmTextBox.Visibility = Visibility.Collapsed;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }

        private void SubsTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HeaderTextBlock.Text = "Абоненты ТНС";
            MainFrame.Navigate(new SubscribersPage());
        }

        private void EquipTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HeaderTextBlock.Text = "Управление оборудованием ТНС";
            MainFrame.Navigate(new NetworkOpinionManagement());
        }

        private void AssetsTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HeaderTextBlock.Text = "Активы ТНС";
            MainFrame.Navigate(new clrPage());
        }

        private void BillingTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HeaderTextBlock.Text = "Биллинг ТНС";
            MainFrame.Navigate(new Billing());
        }

        private void SupprtTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HeaderTextBlock.Text = "Поддержка пользователей ТНС";
            MainFrame.Navigate(new UserSupport());
        }

        private void crmTextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HeaderTextBlock.Text = "CRM ТНС";
            MainFrame.Navigate(new clrPage());
        }

        private void UsersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainFrame.Navigate(new SubscribersPage());
            switch (userList[UsersComboBox.SelectedIndex].Роль)
            {
                case "Руководитель отдела по работе с клиентами":
                    SubsTextBox.Visibility = Visibility.Visible;
                    EquipTextBox.Visibility = Visibility.Collapsed;
                    AssetsTextBox.Visibility = Visibility.Collapsed;
                    BillingTextBox.Visibility = Visibility.Visible;
                    SupprtTextBox.Visibility = Visibility.Collapsed;
                    crmTextBox.Visibility = Visibility.Visible;

                    break;

                case "Менеджер по работе с клиентами\r\n":
                    SubsTextBox.Visibility = Visibility.Visible;
                    EquipTextBox.Visibility = Visibility.Collapsed;
                    AssetsTextBox.Visibility = Visibility.Collapsed;
                    BillingTextBox.Visibility = Visibility.Collapsed;
                    SupprtTextBox.Visibility = Visibility.Collapsed;
                    crmTextBox.Visibility = Visibility.Visible;

                    break;

                case "Руководитель отдела технической поддержки\r\n":
                    SubsTextBox.Visibility = Visibility.Visible;
                    EquipTextBox.Visibility = Visibility.Visible;
                    AssetsTextBox.Visibility = Visibility.Collapsed;
                    BillingTextBox.Visibility = Visibility.Collapsed;
                    SupprtTextBox.Visibility = Visibility.Visible;
                    crmTextBox.Visibility = Visibility.Visible;

                    break;

                case "Специалист ТП (выездной инженер)\r\n":
                    SubsTextBox.Visibility = Visibility.Visible;
                    EquipTextBox.Visibility = Visibility.Visible;
                    AssetsTextBox.Visibility = Visibility.Collapsed;
                    BillingTextBox.Visibility = Visibility.Collapsed;
                    SupprtTextBox.Visibility = Visibility.Visible;
                    crmTextBox.Visibility = Visibility.Visible;

                    break;

                case "Бухгалтер\r\n":
                    SubsTextBox.Visibility = Visibility.Visible;
                    EquipTextBox.Visibility = Visibility.Collapsed;
                    AssetsTextBox.Visibility = Visibility.Visible;
                    BillingTextBox.Visibility = Visibility.Visible;
                    SupprtTextBox.Visibility = Visibility.Collapsed;
                    crmTextBox.Visibility = Visibility.Collapsed;

                    break;

                case "Директор по развитию\r\n":
                    SubsTextBox.Visibility = Visibility.Visible;
                    EquipTextBox.Visibility = Visibility.Visible;
                    AssetsTextBox.Visibility = Visibility.Visible;
                    BillingTextBox.Visibility = Visibility.Visible;
                    SupprtTextBox.Visibility = Visibility.Visible;
                    crmTextBox.Visibility = Visibility.Visible;

                    break;

                case "Технический департамент\r\n":
                    SubsTextBox.Visibility = Visibility.Visible;
                    EquipTextBox.Visibility = Visibility.Visible;
                    AssetsTextBox.Visibility = Visibility.Visible;
                    BillingTextBox.Visibility = Visibility.Collapsed;
                    SupprtTextBox.Visibility = Visibility.Visible;
                    crmTextBox.Visibility = Visibility.Visible;

                    break;
            }
        }
    }
}

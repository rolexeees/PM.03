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
using System.Diagnostics;

namespace TeleconNevaCommunication
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        User polzovatel_exsist;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void NamTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            using (var conect = new TeleconNevaEntities())
            {
                int namberOfPerson = int.Parse(NamTextBox.Text);
                polzovatel_exsist = conect.Users.FirstOrDefault(polzovatel => polzovatel.Номер == namberOfPerson);
                if (polzovatel_exsist != null)
                {
                    PasTextBox.IsReadOnly = false;
                }
                else
                {
                    //ButtonVihod.Focus();
                    MessageBox.Show("Не верный номер пользователя");
                }
            }
            e.Handled = true;
        }

        private void PasTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            if (polzovatel_exsist != null)
            {
                if (polzovatel_exsist.Пароль == PasTextBox.Text)
                {
                    CodTextBox.IsReadOnly = false;
                    NewCodImage.IsEnabled = true;
                    ButtonVhod.IsEnabled = true;
                        
                    CodDostupa();
                }
                else
                {
                    MessageBox.Show("Не верный пароль");
                }
            }
            else
            {
                MessageBox.Show("Не верный номер пользователя");
            }

            e.Handled = true;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CodDostupa();
        }

        private void CodDostupa()
        {
            MessageBox.Show("Код доступа = " + Convert.ToString(Manager.CodVhoda) + " введите его в течение 10 секунд. " +
                            "\nВ случае неудачи нажмите на кнопку рядом с полем ввода кода");
            ShutdownTimer _timer = new ShutdownTimer(10);
            _timer.Run();
        }

        private void CheckingTheAccessCode()
        {
            if (CodTextBox.Text == Convert.ToString(Manager.CodVhoda))
            {
                MessageBox.Show(polzovatel_exsist.Роль);
            }
            else
            {
                MessageBox.Show("Не верный код доступа");
            }
        }

        private void ButtonVhod_Click(object sender, RoutedEventArgs e)
        {
            CheckingTheAccessCode();
        }

        private void ButtonVihod_Click(object sender, RoutedEventArgs e)
        {
            CodTextBox.IsReadOnly = true;
            NewCodImage.IsEnabled = false;
            ButtonVhod.IsEnabled = false;
            PasTextBox.IsReadOnly = true;
            NamTextBox.Clear();
            PasTextBox.Clear();
            CodTextBox.Clear();
            //ProcessStartInfo Info = new ProcessStartInfo();
            //Info.Arguments = "/C choice /C Y /N /D Y /T 1 & START \"\" \"" + System.Reflection.Assembly.GetEntryAssembly().Location + "\"";
            //Info.WindowStyle = ProcessWindowStyle.Hidden;
            //Info.CreateNoWindow = true;
            //Info.FileName = "cmd.exe";
            //Process.Start(Info);
            //Process.GetCurrentProcess().Kill();
        }

        private void CodTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;
            CheckingTheAccessCode();
            e.Handled = true;
        }
    }
}

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

namespace WorkWithSubscribers
{
    /// <summary>
    /// Логика взаимодействия для NetworkOpinionManagement.xaml
    /// </summary>
    public partial class NetworkOpinionManagement : Page
    {
        public NetworkOpinionManagement()
        {
            InitializeComponent();
        }

        private void Control_ButtonClick(object sender, RoutedEventArgs e)
        {
            Process.Start(@"..\..\..\StatusControl\bin\Debug\StatusControl.exe");
        }

        private void Equipment_ButtonClick(object sender, RoutedEventArgs e)
        {
            Process.Start(@"..\..\..\EquipmentSetup\bin\Debug\EquipmentSetup.exe");
        }

        private void BaseStation_ButtonClick(object sender, RoutedEventArgs e)
        {
            Process.Start(@"..\..\..\CalculationNumberBaseStation\bin\Debug\CalculationNumberBaseStation.exe");
        }
    }
}

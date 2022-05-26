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

namespace StatusControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Highway> backboneNetworks = new List<Highway>();
        List<Access_Networks> accessNetworks = new List<Access_Networks>();
        List<Suds_Equipment> subseQuipments = new List<Suds_Equipment>();

        public MainWindow()
        {
            InitializeComponent();
            using (var conect = new TeleconNevaEntities())
            {
                backboneNetworks = conect.Highways.ToList();
                foreach (var highway in backboneNetworks)
                {
                    BackboneNetworksComboBox.Items.Add(highway.Название);
                }

                accessNetworks = conect.Access_Networks.ToList();
                foreach (var accessNetwork in accessNetworks)
                {
                    AccessNetworksComboBox.Items.Add(accessNetwork.Наименование);
                }

                subseQuipments = conect.Suds_Equipment.ToList();
                foreach (var subseQuipment in subseQuipments)
                {
                    SubseQuipmentComboBox.Items.Add(subseQuipment.Наименование);
                }

            }
        }

        private void BackboneNetworksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AccessNetworksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SubseQuipmentComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

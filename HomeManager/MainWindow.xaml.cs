using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using HomeManager.Exceptions;
using HomeManager.HouseholdItems;
using HomeManager.HouseholdItems.Actions;

namespace HomeManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static CancellationTokenSource cts;
        static CancellationToken token;

        public static ObservableCollection<IHouseholdItem> viewCollection { get; set; }
        public ObservableCollection<string> viewActCollection { get; set; }
        private EquipmentControlPanel equipmentControlPanel;
        private Home home;

        public MainWindow()
        {
            cts = new CancellationTokenSource();
            token = cts.Token;

            viewCollection = new ObservableCollection<IHouseholdItem>();
            viewActCollection = new ObservableCollection<string>();
            equipmentControlPanel = new EquipmentControlPanel();
            home = new Home();

            GenerateHouseholdItems();

            InitializeComponent();
        }
        private void GenerateHouseholdItems()
        {
            home.AddNewHomeItem(new Curtain("Curtain 1"));
            home.AddNewHomeItem(new CoffeeMaker("CoffeeMaker 1"));
            home.AddNewHomeItem(new CoffeeMaker("CoffeeMaker 2"));
            home.AddNewHomeItem(new LightBulb("LightBulb 1"));
            home.AddNewHomeItem(new LightBulb("LightBulb 2"));
            home.AddNewHomeItem(new LightBulb("LightBulb 3"));
            home.AddNewHomeItem(new LightBulb("LightBulb 4"));
            home.AddNewHomeItem(new Curtain("Curtain 2"));

            equipmentControlPanel.ConnectionEstablishment(home.GetHomeItems[0]);
            equipmentControlPanel.ConnectionEstablishment(home.GetHomeItems[1]);
            equipmentControlPanel.ConnectionEstablishment(home.GetHomeItems[3]);
            equipmentControlPanel.ConnectionEstablishment(home.GetHomeItems[4]);

            UpdateItems();
            UpdateActions();
        }

        private void ElectricityTurnOn(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            cts = new CancellationTokenSource();
            token = cts.Token;

            TurnOnElectricityAsync(); 
        }
        private void ElectricityTurnOff(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            cts = new CancellationTokenSource();
            token = cts.Token;

            TurnOffElectricityAsync();
        }
        private async void TurnOnElectricityAsync()
        {
            await Task.Run(() => home.SwitchOnElectricity(token), token);
            UpdateItems();
        }
        private async void TurnOffElectricityAsync()
        {
            await Task.Run(() => home.SwitchOffElectricity(token), token);
            UpdateItems();
        }

        private void UpdateItems()
        {
            viewCollection.Clear();

            foreach (var item in home.GetHomeItems)
            {
                viewCollection.Add(item);
            }
        }
        private void UpdateActions()
        {
            viewActCollection.Clear();

            foreach (var item in equipmentControlPanel.GetHouseholdActions)
            {
                viewActCollection.Add(item.GetString());
            }
        }

        private int GetIndexSelectedItem()
        {
            return listAction.SelectedIndex;
        }

        private void Do(object sender, RoutedEventArgs e)
        {
            try
            {

                equipmentControlPanel.PushButton(GetIndexSelectedItem());

                UpdateItems();
            }
            catch (HouseholdItemException householdItemException)
            {
                MessageBox.Show(householdItemException.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Programming error", ex.Message));
            }
        }


    }
}

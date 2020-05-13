using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<string> viewCollection;
        private EquipmentControlPanel equipmentControlPanel;
        private Home home;

        public MainWindow()
        {
           
            viewCollection = new ObservableCollection<string>();
            equipmentControlPanel = new EquipmentControlPanel();
            home = new Home();

            GenerateHouseholdItems();

            InitializeComponent();
            listHousholdItems.ItemsSource = viewCollection;

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

        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(listHousholdItems.SelectedItem is null))
            {
                int index = GetIndexSelectedItem();
                IHouseholdItem item;

                if (IsHousList.IsChecked.Value)
                {
                    item = home.GetHomeItems[index];
                }
            }
        }

        private void ElectricityTurnOn(object sender, RoutedEventArgs e)
        {
            home.SwitchOnElectricity();
        }
        private void ElectricityTurnOff(object sender, RoutedEventArgs e)
        {
            home.SwitchOffElectricity();
        }

        private void RadioButtonCheckedHousList(object sender, RoutedEventArgs e)
        {
            ViewItems(home.GetHomeItems);
        }
        private void RadioButtonCheckedEquipmentControl(object sender, RoutedEventArgs e)
        {
            ViewActions(equipmentControlPanel.GetHouseholdActions);
        }
        private void ViewItems(List<IHouseholdItem> items)
        {
            viewCollection.Clear();

            foreach (var item in items)
            {
                viewCollection.Add(item.GetString());
            }
        }
        private void ViewActions(List<IAction> actions)
        {
            viewCollection.Clear();

            foreach (var item in actions)
            {
                viewCollection.Add(item.GetString());
            }
        }

        private int GetIndexSelectedItem()
        {
            return listHousholdItems.SelectedIndex;
        }

        private void Do(object sender, RoutedEventArgs e)
        {
            try
            {
                if (! IsHousList.IsChecked.Value)
                {
                    equipmentControlPanel.PushButton(GetIndexSelectedItem());
                }
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

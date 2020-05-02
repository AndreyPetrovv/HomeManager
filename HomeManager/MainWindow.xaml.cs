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
        private ObservableCollection<string> obsListHousholdItems;
        private EquipmentControlPanel equipmentControlPanel;
        private Home home;

        public MainWindow()
        {
           
            obsListHousholdItems = new ObservableCollection<string>();
            equipmentControlPanel = new EquipmentControlPanel();
            home = new Home();

            GenerateHouseholdItems();

            InitializeComponent();
            listHousholdItems.ItemsSource = obsListHousholdItems;

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

            equipmentControlPanel.AddControlledItem(home.GetHomeItems[0]);
            equipmentControlPanel.AddControlledItem(home.GetHomeItems[1]);
            equipmentControlPanel.AddControlledItem(home.GetHomeItems[3]);
            equipmentControlPanel.AddControlledItem(home.GetHomeItems[4]);

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
                else
                {
                    item = equipmentControlPanel.GetControlledHomeItems[index];
                }
                
                if(item is Curtain)
                {
                    listActionsCoffeMaker.Visibility = Visibility.Collapsed;
                    listActionsCurtain.Visibility = Visibility.Visible;
                    listActionsLightBulb.Visibility = Visibility.Collapsed;
                }
                else if (item is CoffeeMaker)
                {
                    listActionsCoffeMaker.Visibility = Visibility.Visible;
                    listActionsCurtain.Visibility = Visibility.Collapsed;
                    listActionsLightBulb.Visibility = Visibility.Collapsed;
                }
                else
                {
                    listActionsCoffeMaker.Visibility = Visibility.Collapsed;
                    listActionsCurtain.Visibility = Visibility.Collapsed;
                    listActionsLightBulb.Visibility = Visibility.Visible;
                }
                SetInfoFromItem(item);
            }
        }
        private void ViewItems(List<IHouseholdItem> items)
        {
            obsListHousholdItems.Clear();

            foreach (var item in items)
            {
                obsListHousholdItems.Add(item.GetName);
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
            ViewItems(equipmentControlPanel.GetControlledHomeItems);
        }

        private void SetInfoFromItem(IHouseholdItem item)
        {
            itemInfo.Text = item.GetString();
        }
        private int GetIndexSelectedItem()
        {
            return listHousholdItems.SelectedIndex;
        }

        private void ProcessingCustomExeptions(Exception ex)
        {
            if(ex is DeviceOwnerIsNullException)
            {
                MessageBox.Show(ex.Message);
            }
            else if(ex is ControllerIsNotEqualDeviceOwnerException)
            {
                MessageBox.Show(ex.Message);
            }
            else if(ex is InvalidIncomingValueException)
            {
                MessageBox.Show(ex.Message);
            }
            else if (ex is IndexOutOfRangeException)
            {
                MessageBox.Show(ex.Message);
            }
            else if (ex is ItemOfHouseIsTurnOffException)
            {
                MessageBox.Show(ex.Message);
            }
            else if (ex is DeviceBusyException)
            {
                MessageBox.Show(ex.Message);
            }
            else
            {
                throw ex;
            }
        }

        private void MakeCoffe(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionMakeCoffe());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }
        private void ReplenishCoffee(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionReplenishCoffee());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }
        private void ReplenishWater(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionReplenishdWater());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }
        private void SetHalfPowerOfLight(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionSetHalfPowerOfLight());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }
        private void SetMaxPowerOfLight(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionSetMaxPowerOfLight());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }
        private void SetMinPowerOfLight(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionSetMinPowerOfLight());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }
        private void SetZeroPowerOfLight(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionSetZeroPowerOfLight());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }
        private void ToCloseCurtain(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionToCloseCurtain());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }
        private void ToOpenCurtain(object sender, RoutedEventArgs e)
        {
            try
            {
                equipmentControlPanel.PushButton(GetIndexSelectedItem(), new ActionToOpenCurtain());
                itemInfo.Text = equipmentControlPanel.GetControlledHomeItems[GetIndexSelectedItem()].GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }


    }
}

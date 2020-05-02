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
        ObservableCollection<string> obsListHousholdItems;
        EquipmentControlPanel equipmentControlPanel;
        Home home;

        public MainWindow()
        {
           
            obsListHousholdItems = new ObservableCollection<string>();
            equipmentControlPanel = new EquipmentControlPanel();
            home = new Home();

            GenerateHouseholdItems();

            InitializeComponent();
            listHousholdItems.ItemsSource = obsListHousholdItems;

        }
        private void listBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(listHousholdItems.SelectedItem is null))
            {
                int index = GetIndexSelectedItem();
                IHouseholdItem item;

                if (IsHousList.IsChecked.Value)
                {
                    item = home.GetItem(index);
                }
                else
                {
                    item = equipmentControlPanel.GetItem(index);
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
        public void GenerateHouseholdItems()
        {
            home.CreateNewHomeItem(new Curtain("Curtain 1"));
            home.CreateNewHomeItem(new CoffeeMaker("CoffeeMaker 1"));
            home.CreateNewHomeItem(new LightBulb("LightBulb 1"));
            home.CreateNewHomeItem(new LightBulb("LightBulb 2"));
            home.CreateNewHomeItem(new LightBulb("LightBulb 3"));
            home.CreateNewHomeItem(new LightBulb("LightBulb 4"));
            home.CreateNewHomeItem(new Curtain("Curtain 2"));

            equipmentControlPanel.AddHomeItem(home.GetItem(0));
            equipmentControlPanel.AddHomeItem(home.GetItem(1));
            equipmentControlPanel.AddHomeItem(home.GetItem(2));
            equipmentControlPanel.AddHomeItem(home.GetItem(3));

        }

        private void ViewItems(List<IHouseholdItem> items)
        {
            obsListHousholdItems.Clear();

            foreach (var item in items)
            {
                obsListHousholdItems.Add(item.GetName);
            }
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
            else if (ex is InvalidIndexOfItemException)
            {
                MessageBox.Show(ex.Message);
            }
            else if (ex is ItemOfHouseIsTurnOffException)
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
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
                itemInfo.Text = equipmentControlPanel.GetItem(GetIndexSelectedItem()).GetString();
            }
            catch (Exception ex)
            {
                ProcessingCustomExeptions(ex);
            }
        }

        private void CreateNewCoffeMaker(object sender, RoutedEventArgs e)
        {

        }

        private void CreateNewCurtain(object sender, RoutedEventArgs e)
        {

        }

        private void CreateNewLightBuld(object sender, RoutedEventArgs e)
        {
        }

        private void ElectricityTurnOn(object sender, RoutedEventArgs e)
        {
            home.SwitchOnElectricity();   
        }

        private void ElectricityTurnOff(object sender, RoutedEventArgs e)
        {
            home.SwitchOffElectricity();
        }
    }
}

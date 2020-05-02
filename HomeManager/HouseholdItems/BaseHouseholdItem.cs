using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;

namespace HomeManager.HouseholdItems
{
    public abstract class BaseHouseholdItem : IHouseholdItem
    {
        protected object deviceOwner;
        private bool isActive = true;

        public abstract string GetName { get; }

        private void CheckDeviceIsNull()
        {
            if (this.deviceOwner is null)
            {
                throw new DeviceOwnerIsNullException();
            }
        }
        private void CheckDeviceOwnerEquals(EquipmentControlPanel controller)
        {
            if (!controller.Equals(this.deviceOwner))
            {
                throw new ControllerIsNotEqualDeviceOwnerException();
            }
        }

        public void SetConnect(EquipmentControlPanel deviceOwner)
        {
            if (this.deviceOwner is null)
            {
                this.deviceOwner = deviceOwner;
            }
            else
            {
                throw new Exception();
            }
        }

        protected bool CheckDeviceOwner(EquipmentControlPanel controller)
        {
            CheckDeviceIsNull();
            CheckDeviceOwnerEquals(controller);

            return true;
        }

        public void DropConnect(EquipmentControlPanel controller)
        {
            CheckDeviceIsNull();
            CheckDeviceOwnerEquals(controller);

            this.deviceOwner = null;
        }

        public bool ToRespond()
        {
            return isActive;
        }
        public void TurnOn()
        {
            isActive = true;
        }
        public void TurnOff()
        {
            isActive = false;
        }

        public abstract string GetString();

    }
}

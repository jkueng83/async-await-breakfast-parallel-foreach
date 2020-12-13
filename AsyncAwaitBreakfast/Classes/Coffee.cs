using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Timers;

namespace AsyncAwaitBreakfest.Classes
{
    public class Coffee
    {
        enum temperatureEnum { HOT, QUITEHOT, NOTSOHOT, COLD };
        temperatureEnum temperature;
        private string _temperatuer;

        private static System.Timers.Timer aTimer;

        public string Temperature
        {
            get
            {              
                return this._temperatuer;
            }
            set { this._temperatuer = value; }
        }

        public Coffee()
        {
            this._temperatuer = "";
            this.temperature = temperatureEnum.HOT;
            SetTimer();
            UpateTemperatureString();
        }

        private void SetTimer()
        {
            aTimer = new System.Timers.Timer(490);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Elapsed += new ElapsedEventHandler(UpdateTemperature);
        }

        private void UpateTemperatureString()
        {
            switch (this.temperature)
            {
                case temperatureEnum.HOT:
                    this._temperatuer = "Hot";
                    break;
                case temperatureEnum.QUITEHOT:
                    this._temperatuer = "Quite hot";
                    break;
                case temperatureEnum.NOTSOHOT:
                    this._temperatuer = "Not so hot";
                    break;
                case temperatureEnum.COLD:
                    this._temperatuer = "Cold";
                    break;
            }
        }

        private void UpdateTemperature(object source, ElapsedEventArgs e)
        {      
            switch (this.temperature)
            {
                case temperatureEnum.HOT:
                    this.temperature = temperatureEnum.QUITEHOT;
                    break;
                case temperatureEnum.QUITEHOT:
                    this.temperature = temperatureEnum.NOTSOHOT;
                    break;
                case temperatureEnum.NOTSOHOT:
                    this.temperature = temperatureEnum.COLD;
                    break;
                case temperatureEnum.COLD:
                    break;
                default:
                    this.temperature = temperatureEnum.HOT;
                    break;
            }

            UpateTemperatureString();
        }

    }
}

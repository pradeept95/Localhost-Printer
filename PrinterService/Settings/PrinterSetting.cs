using System;
using System.Collections.Generic;
using System.Text;

namespace HotBag.AspNetCore.WebPrintService.Settings
{
    public sealed class ApplicationConfig
    {
        /*
        * Private property initilized with null
        * ensures that only one instance of the object is created
        * based on the null condition
        */
        private static ApplicationConfig instance = null;

        /*
       * public property is used to return only one instance of the class
       * leveraging on the private property
       */
        public static ApplicationConfig Instance
        {
            get
            {
                if (instance == null)
                    instance = new ApplicationConfig();
                return instance;
            }
        }

        /*
        * Private constructor ensures that object is not
        * instantiated other than with in the class itself
        */
        private ApplicationConfig()
        {
            _printerName = "";
            _tcpIPAddress = "";
        }

        private string _printerName;
        private string _tcpIPAddress;
        private string _tcpPort; 
       
        public string TcpIpAddress
        {
            get { return this._tcpIPAddress; } 
        }

        public int TcpPort
        {
            get 
            {
                int result;
                Int32.TryParse(_tcpPort, out result);
                return result;
            }
        }

        /*
       * Public method which can be invoked through the singleton instance to print current config value
       */
        public string GetPrinterName()
        {
            return this._printerName;
        }

        /*
      * Public method which can be invoked through the singleton instance to set new value to config property
      */
        public void SetPrinterName(string newValue)
        {
            this._printerName = newValue;
        }
        public void SetTCPIpAddress(string newValue)
        {
            this._tcpIPAddress = newValue;
        }
        public void SetTCPPort(string newValue)
        {
            this._tcpPort = newValue;
        }
    }
}

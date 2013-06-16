﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Gadgeteer Designer.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Gadgeteer;
using GTM = Gadgeteer.Modules;

namespace SecurityApp
{
    public partial class Program : Gadgeteer.Program
    {
        // GTM.Module definitions
        Gadgeteer.Modules.GHIElectronics.UsbClientDP usbClientDP;
        Gadgeteer.Modules.GHIElectronics.Motion_Sensor motion_Sensor;
        Gadgeteer.Modules.GHIElectronics.MulticolorLed multicolorLed;
        Gadgeteer.Modules.GHIElectronics.RFID rfid;
        Gadgeteer.Modules.GHIElectronics.Display_HD44780 char_Display;

        public static void Main()
        {
            //Important to initialize the Mainboard first
            Mainboard = new GHIElectronics.Gadgeteer.FEZSpider();			

            Program program = new Program();
            program.InitializeModules();
            program.ProgramStarted();
            program.Run(); // Starts Dispatcher
        }

        private void InitializeModules()
        {   
            // Initialize GTM.Modules and event handlers here.		
            usbClientDP = new GTM.GHIElectronics.UsbClientDP(1);
		
            motion_Sensor = new GTM.GHIElectronics.Motion_Sensor(4);
		
            multicolorLed = new GTM.GHIElectronics.MulticolorLed(8);
		
            rfid = new GTM.GHIElectronics.RFID(9);
		
            char_Display = new GTM.GHIElectronics.Display_HD44780(12);

        }
    }
}

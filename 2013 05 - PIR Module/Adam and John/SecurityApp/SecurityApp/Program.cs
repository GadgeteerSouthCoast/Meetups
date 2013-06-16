using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace SecurityApp
{
    public partial class Program
    {
        GT.Timer _timer = null;
        bool _rfidEnabled = false;

        void ProgramStarted()
        {
            Debug.Print("Program Started");

            motion_Sensor.Motion_Sensed += new Motion_Sensor.Motion_SensorEventHandler(motion_Sensor_Motion_Sensed);
            rfid.CardIDReceived += new RFID.CardIDReceivedEventHandler(rfid_CardIDReceived);
        }

        void rfid_CardIDReceived(RFID sender, string ID)
        {
            if (_rfidEnabled)
            {
                char_Display.Clear();

                if (string.Compare(ID, "4D0055D104") == 0)
                {
                    char_Display.PrintString("Welcome back sir :)");
                    multicolorLed.TurnGreen();

                    ClearTimer();
                }
                else
                {
                    char_Display.PrintString("Who are you?!");
                    multicolorLed.TurnWhite();
                }
            }
        }

        void timer_Tick(GT.Timer timer)
        {
            char_Display.Clear();

            char_Display.PrintString("Security Alerted...");

            multicolorLed.TurnOff();

            _rfidEnabled = false;
        }

        void motion_Sensor_Motion_Sensed(Motion_Sensor sender, Motion_Sensor.Motion_SensorState state)
        {
            multicolorLed.BlinkRepeatedly(GT.Color.Red);

            char_Display.Clear();
            char_Display.PrintString("ID yourself!");

            _rfidEnabled = true;

            ClearTimer();

            _timer = new GT.Timer(10000);
            _timer.Tick += new GT.Timer.TickEventHandler(timer_Tick);
            _timer.Start();
        }

        private void ClearTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Tick -= timer_Tick;
            }
        }
    }
}

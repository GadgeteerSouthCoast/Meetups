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

using tunes = Gadgeteer.Modules.GHIElectronics.Tunes;

namespace GadgeteerApp1
{
    public partial class Program
    {
        private double _speedFactor = 8.0;
        private GT.Timer _timer;

        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            Debug.Print("Program Started");

            _timer = new GT.Timer(1000);
            _timer.Tick += new GT.Timer.TickEventHandler(_timer_Tick);
            _timer.Start();

            //button.ButtonPressed += new GTM.GHIElectronics.Button.ButtonEventHandler(button_ButtonPressed);
        }

        void _timer_Tick(GT.Timer timer)
        {
            _speedFactor = distance_US3.GetDistanceInCentimeters(7);
            int bastard = int.Parse( _speedFactor.ToString().Substring(0, 1));
            if (_speedFactor < 10) bastard = 1;
            Debug.Print(_speedFactor + " " + bastard);
            tunes.Tone tone;

            switch (bastard)
            {
                case 1:
                    tone = tunes.Tone.C5;
                    break;
                case 2:
                    tone = tunes.Tone.B4;
                    break;
                case 3:
                    tone = tunes.Tone.A4;
                    break;
                case 4:
                    tone = tunes.Tone.G4;
                    break;
                case 5:
                    tone = tunes.Tone.F4;
                    break;
                case 6:
                    tone = tunes.Tone.E4;
                    break;
                case 7:
                    tone = tunes.Tone.D4;
                    break;
                default:
                    tone = tunes.Tone.C4;
                    break;
            }
            tunes.AddNote(new tunes.MusicNote(tone, 1000));
            tunes.Play();
        }

        void button_ButtonPressed(GTM.GHIElectronics.Button sender, GTM.GHIElectronics.Button.ButtonState state)
        {
            _speedFactor = distance_US3.GetDistanceInCentimeters(1);

            for (int i = 0; i < _speedFactor; i++)
            {
                tunes.AddNote(new tunes.MusicNote(tunes.Tone.C4, 100));
                tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, 50));
            }

            //if (_speedFactor > 10) _speedFactor = 10;
            //QueueHappyBirthdayTones();
            tunes.Play();
        }



        private void QueueHappyBirthdayTones()
        {

            tunes.AddNote(new tunes.MusicNote(tunes.Tone.C4, SpeedShizzle(25)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(5)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.C4, SpeedShizzle(40)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.D4, SpeedShizzle(60)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(5)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.C4, SpeedShizzle(60)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(5)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.F4, SpeedShizzle(60)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(5)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.E4, SpeedShizzle(100)));

            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(20)));

            tunes.AddNote(new tunes.MusicNote(tunes.Tone.C4, SpeedShizzle(25)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(5)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.C4, SpeedShizzle(40)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.D4, SpeedShizzle(60)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(5)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.C4, SpeedShizzle(60)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(5)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.G4, SpeedShizzle(60)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.Rest, SpeedShizzle(5)));
            tunes.AddNote(new tunes.MusicNote(tunes.Tone.F4, SpeedShizzle(100)));
        }

        private int SpeedShizzle(int duration)
        {
            return (int)(duration * _speedFactor);
        }
    }
}

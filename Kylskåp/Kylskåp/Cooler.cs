using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
    public class Cooler
    {
        private decimal _insideTemperature;
        private decimal _targetTemperature;

        private const decimal OutsideTemperature = 23.7m;
     
        // Egenskaper
        public bool DoorIsOpen { get; set; }
        
        public decimal InsideTemperature
        {
            get {return _insideTemperature;}
            set
            {
                if (value < 0 || value > 45)
	            {
                    throw new ArgumentException();
	            }
                _insideTemperature = value;
            }
        }

        public bool IsOn { get; set; }

        public decimal TargetTemperature 
        {
            get { return _targetTemperature; }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException();
                }
                _targetTemperature = value;
            }
        }

        // Konstruktorer
        public Cooler()
            : this(0.0m, 0.0m)
        { }
        
        public Cooler(decimal temperature, decimal targetTemperature)
            : this(temperature, targetTemperature, false, false) 
        { }

        public Cooler(decimal temperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
        {
            InsideTemperature = temperature;
            TargetTemperature = targetTemperature;
            IsOn = isOn;
            DoorIsOpen = doorIsOpen;
        }
        
        // symbolisera att status visas en gång i minuten (Metod)
        public void Tick() 
        {
            decimal heatchange = 0.0m;

            if (IsOn)
            {
                if (DoorIsOpen)
                {
                    heatchange = +0.2m;
                }
                else
                {
                    heatchange -= 0.2m;
                }
            }

            else
            {
                if (DoorIsOpen)
                {
                    heatchange += 0.5m;
                }
                else
                {
                    heatchange += 0.1m;
                }
            }

            // Sätter gränser för temperaturen
            if (InsideTemperature + heatchange < TargetTemperature)
            {
                InsideTemperature = TargetTemperature;
            }
            else if (InsideTemperature + heatchange > OutsideTemperature)
            {
                InsideTemperature = OutsideTemperature;
            }
            else
            {
                InsideTemperature += heatchange;
            }
        } 

        public override string ToString()
        {
            
            string onOff = IsOn ? "PÅ" : "AV";
            string doorIsOpen = DoorIsOpen ? "Öppet" : "Stängt";
            
            return String.Format("[{0}] : {1:F1}°C : ({2:F1}°C) - {3}", onOff, InsideTemperature, TargetTemperature, doorIsOpen);
        }
    }
}

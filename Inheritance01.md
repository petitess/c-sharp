### Program.cs
```cs
Radio myRadio = new Radio(false, "Sony");
myRadio.SwitchOn();
myRadio.ListenRadio();

Tv myTv = new Tv(false, "Samsung");
myTv.SwitchOn();
myTv.WatchTv();
```
### ElectricalDevice.cs
```cs
namespace exercise01
{
    internal class ElectricalDevice
    {
        //Parent - Base
        public bool IsOn { get; set; }
        public string Brand { get; set; }
        public ElectricalDevice(bool isOn, string brand) 
        {
            IsOn = isOn;
            Brand = brand;
        }
        public void SwitchOn()
        {
            IsOn = true;
        }
        public void SwitchOff()
        {
            IsOn = false;
        }
    }
}
```
### Radio.cs
```cs
namespace exercise01
{
    internal class Radio : ElectricalDevice
    {
        public Radio(bool isOn, string brand):base(isOn, brand)
        {
        }
        public void ListenRadio()
        {
            if (IsOn)
            {
                Console.WriteLine("Listening to the radio.");
            }
            else
            {
                Console.WriteLine("Radio is switched off.");
            }
        }
    }
}
```
### Tv.cs
```cs
namespace exercise01
{
    internal class Tv : ElectricalDevice
    {
        public Tv(bool isOn, string brand):base(isOn, brand)
        {
        }
        public void WatchTv()
        {
            if (IsOn)
            {
                Console.WriteLine("Watching Tv.");
            }
            else
            {
                Console.WriteLine("Tv is switched off.");
            }
        }
    }
}
```

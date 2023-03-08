using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace ColourPicker.ViewModel
{
    public partial class ColourPickerViewModel : ObservableObject
    {
        public ColourPickerViewModel()
        {
            red = 0;
            green = 0;
            blue = 0;
            CalculateHex();
        }
        [ObservableProperty]
        byte red;
        [ObservableProperty]
        byte green;
        [ObservableProperty]
        byte blue;
        [ObservableProperty]
        string hex;
        [ObservableProperty]
        string inputValue;



        partial void OnBlueChanged(byte value)
        {
            CalculateHex();
        }
        partial void OnGreenChanged(byte value)
        {
            CalculateHex();
        }
        partial void OnRedChanged(byte value)
        {
            CalculateHex();
        }
        partial void OnInputValueChanged(string value)
        {
            if (!Regex.IsMatch(value, @"^#[\dA-F]{6}$", RegexOptions.IgnoreCase))
                return;
            Hex = InputValue;
            CalculateRGB();
        }

        public void CalculateHex()
        {
            Hex = "#" + Red.ToString("X2") + Green.ToString("X2") + Blue.ToString("X2");
            InputValue = Hex;

        }
        public void CalculateRGB()
        {
           Red = byte.Parse(Hex.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
           Green = byte.Parse(Hex.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
           Blue = byte.Parse(Hex.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
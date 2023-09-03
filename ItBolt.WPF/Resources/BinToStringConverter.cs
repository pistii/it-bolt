using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ItBolt.WPF.Resources
{
    public class BinToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value.ToString();
            if (parameter.ToString() == "garancialis")
            {
                string garancialis = "";
                switch (str)
                {
                    case "1":
                        garancialis = "Garanciális";
                        break;
                    case "0":
                        garancialis = "Nem garanciális";
                        break;
                }
                return garancialis;
            } else
            {
                string kedvezmenyes = "";
                switch (str)
                {
                    case "1":
                        kedvezmenyes = "Kedvezményes";
                        break;
                    case "0":
                        kedvezmenyes = "Nem kedvezményes";
                        break;
                }
                return kedvezmenyes;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        
        
        {
            if (value.ToString().ToLower() == "kedvezményes" || value.ToString().ToLower() == "igen")
            {
                return 1;
            }
            if (value.ToString().ToLower() == "nem kedvezményes" || value.ToString().ToLower() == "nem")
            {
                return 0;
            }
            if (value.ToString().ToLower() == "garanciális" || value.ToString().ToLower() == "igen")
            {
                return 1;
            }
            if (value.ToString().ToLower() == "nem garanciális" || value.ToString().ToLower() == "nem")
            {
                return 0;
            }


            return null;
        }

    }
}

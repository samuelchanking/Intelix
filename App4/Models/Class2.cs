using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App4.Models
{
    public class GroupConverter : IValueConverter
    {
        public GroupConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var scoreboard = value as Scoreboard;
            if (scoreboard.Score > 0 && scoreboard.Score <= 50)
                return "Bronze";
            else if (scoreboard.Score > 75 && scoreboard.Score <= 100)
                return "Gold";
            else if (scoreboard.Score > 50 && scoreboard.Score <= 75)
                return "Silver";
            else
                return "None";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}

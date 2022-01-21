using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DZWpfApp6
{
    class WeatherControl: DependencyObject//наследуем класс и добавляем пространство имен Window
    {
        private string direction;
        private int speed;
        public static readonly DependencyProperty TemperatureProperty;//создаем свойство зависимости 
        public string Direction
        {
            get => direction;
            set => direction = value;
        }
        public int Speed
        {
            get => speed;
            set => speed = value;
        }
        public enum Precipitation
        {
            Sunny = 0,
            Cloudy = 1,
            Rainy = 2,
            Snowy = 3
        }
        public int Temperature
        {
            get =>(int) GetValue(TemperatureProperty);//делаем преобразование
            set => SetValue(TemperatureProperty, value);
        }
        static WeatherControl() //создаем статический конструктор
=> TemperatureProperty = DependencyProperty.Register(//перечисляем свойства
                nameof(Temperature),//Имя
                typeof(int),
                typeof(WeatherControl),//имя влядельца
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));               

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
            {
                return v;
            }
            else
            {
                return 0;
            }
        }
    }
}

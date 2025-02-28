using ArturGabdrakhmanov422_DogAndCat.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ArturGabdrakhmanov422_DogAndCat
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DogsPhotoDB222104Entities db = new DogsPhotoDB222104Entities();
    }
}

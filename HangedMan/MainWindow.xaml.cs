using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangedMan
{
    public partial class MainWindow : Window
    {
        
        Logic logic;
        public MainWindow()
        {
            InitializeComponent();

            //initializing the game
            logic = new Logic();
            Windy.Height = 800;
            Windy.Width = 1500;

            Windy.Content = logic.gridy;
            Windy.Show();

        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;

namespace HangedMan
{
    internal class Pictures
    {
        //an array of the pictures of the stages of the game
        protected BitmapImage[] hangStage = new BitmapImage[] {hangman1, hangman2, hangman3, hangman4, hangman5, hangman6,
                                                               hangman7, hangman8, hangman9, hangman10, hangman11};

        public Pictures(){}

        protected static BitmapImage hangman1 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman1.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman2 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman2.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman3 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman3.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman4 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman4.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman5 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman5.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman6 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman6.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman7 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman7.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman8 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman8.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman9 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman9.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman10 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman10.jpg"), UriKind.Absolute));
        protected static BitmapImage hangman11 = new BitmapImage(new Uri(Path.GetFullPath(@"Images/hangman/hangman11.jpg"), UriKind.Absolute));


        //returning the image for advancing in the game
        public Image Advance(int stage)
        {
            Image temp = new Image();
            temp.Source = hangStage[stage];
            return temp;
        }
   }
}
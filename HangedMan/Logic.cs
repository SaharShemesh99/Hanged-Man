using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;

namespace HangedMan
{

    internal class Logic
    {

        public Grid gridy = new Grid();//grid to organize the board
        protected int stage = 0;// the stage toward loss
        protected readonly Words words;//the array of the words
        protected Image image;// the image that will cycle upon mistake
        protected string word = "";//the chosen word
        protected string userWord;//the user's word
        protected TextBlock text = new TextBlock();//textblock to display
        protected Pictures pictures;//the pictures array
        protected bool choice = false;// the difficulty choice
        protected Button[] buttons = new Button[26];// buttons array
        protected WrapPanel panel = new WrapPanel();//wrap panel to wrap the words

        public Logic()
        {
            GetChoice();

            //initialzing the variables
            pictures = new Pictures();
            words = new Words();

            gridy.Height = 800;
            gridy.Width = 1500;
            gridy.Background = new SolidColorBrush(Colors.BlueViolet);
        }

        //getting the players choice of difficulty
        public void GetChoice()
        {
            gridy.RowDefinitions.Add(new RowDefinition());
            gridy.RowDefinitions.Add(new RowDefinition());
            gridy.RowDefinitions.Add(new RowDefinition());

            //the text
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Choose Difficulty";
            textBlock.FontSize = 30;
            textBlock.Background = new SolidColorBrush(Colors.BlueViolet);
            Grid.SetRow(textBlock, 0);

            //easy button
            Button easyButt = new Button();
            easyButt.FontSize = 30;
            easyButt.Content = "Easy";
            easyButt.Background = new SolidColorBrush(Colors.BlueViolet);
            easyButt.Click += EasyButt_Click;
            Grid.SetRow(easyButt, 1);

            //hard button
            Button hardButt = new Button();
            hardButt.FontSize = 30;
            hardButt.Content = "Hard";
            hardButt.Background = new SolidColorBrush(Colors.BlueViolet);
            hardButt.Click += HardButt_Click;
            Grid.SetRow(hardButt, 2);

            gridy.Children.Add(textBlock);
            gridy.Children.Add(easyButt);
            gridy.Children.Add(hardButt);


        }

        private void HardButt_Click(object sender, RoutedEventArgs e)
        {
            //if hard is chosen start with hard word
            choice = false;
            gridy.Children.Clear();
            
            
            word = words.GetWord(choice);
            Start();
        }

        private void EasyButt_Click(object sender, RoutedEventArgs e)
        {
            //if easy is chosen start with word
            choice = true;
            gridy.Children.Clear();

            word = words.GetWord(choice);
            Start();
        }

        //the check function to see if the word is legit or mistake
        public void Check(char userClick)
        {
            string temp = "";
            int count = 0;//count the remaining words to guess
            //flags to help monitoring the game
            bool flag = true;
            bool mistake = true;
            //checking each word and if the players guessed it change it on the textblock
            for (int i = 0; i < word.Length; i++)
            {
                //if the player was right do not advance
                if (word[i] == userClick)
                {
                    temp += userClick;
                    mistake = false;
                }
                //if the user was mistaken add the same char to display
                else temp += userWord[i];
                //if the player is about to win count '-' until he has won/lost
                if (userWord[i] == '-')
                {
                    //if there are atleast 2 more '-' it will not be victory
                    count++;
                    if (count > 1) flag = false;
                }
            }
            userWord = temp;
            text.Text = userWord;
            //if he was mistaken do not advance
            if (mistake) WrongMove();
            //if he was not mistaken and there are no more '-' he has won
            if (flag && !mistake) Winner();
        }

        public void WrongMove()
        {
            //advance
            stage++;
        

            gridy.Children.Remove(image);
            image = pictures.Advance(stage);
            Grid.SetColumn(image, 1);
            Grid.SetRowSpan(image, 2);
            Grid.SetRow(image, 0);

            //if he lost
            if (stage == 10)
            {
                Loser();
                return;
            }

            gridy.Children.Add(image);
        }

        public void Loser()
        {
            MessageBox.Show("You Lost!");
            System.Windows.Application.Current.Shutdown();
        }

        public void Winner()
        {
            MessageBox.Show("You Won!");
            System.Windows.Application.Current.Shutdown();
        }

        //initializing the board
        public void Start()
        {
            gridy.Width = 1500;
            gridy.Height = 800;

            gridy.RowDefinitions.RemoveAt(2);
            gridy.ColumnDefinitions.Add(new ColumnDefinition());
            gridy.ColumnDefinitions.Add(new ColumnDefinition());

            //reseting a word long as the chosen word
            for (int i = 0; i < word.Length; i++) userWord += "-";
            text.Text = userWord; 
            text.VerticalAlignment = VerticalAlignment.Center;
            text.FontSize = 120;
            Grid.SetColumn(text, 0);
            Grid.SetRow(text, 0);

            //calling the first image
            image = pictures.Advance(0);
            Grid.SetColumn(image, 1);
            Grid.SetColumnSpan(image, 2);  
            Grid.SetRow(image, 0);
            
            InitiateKeyBoard();

            gridy.Children.Add(image);
            gridy.Children.Add(text);
        }

        //initiating a keyboard
        public void InitiateKeyBoard()
        {
            Grid.SetColumn(panel, 0);
            Grid.SetRow(panel, 1);
            panel.Width = 700;
            panel.HorizontalAlignment = HorizontalAlignment.Left;
            panel.Orientation = Orientation.Horizontal;

            gridy.Children.Add(panel);


            //creating an array of 26 buttons as the abc
            for (int i = 0; i < 26; i++)
            {
                buttons[i] = new Button();
                buttons[i].Background = new SolidColorBrush(Colors.Blue);
                buttons[i].FontSize = 40;
                buttons[i].Height = 100;
                buttons[i].Width = 100;
                buttons[i].Content = Convert.ToChar(i + 97);
                buttons[i].Click += Keyboard_Click;
                
                panel.Children.Add(buttons[i]);
            }


        }

        //calling the check function with the pressed letter
        private void Keyboard_Click(object sender, RoutedEventArgs e)
        {
            Button temp = sender as Button; 
            Check(Convert.ToChar(temp.Content));
        }

    }
    
}

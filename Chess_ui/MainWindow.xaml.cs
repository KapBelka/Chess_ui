using chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess_ui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board GameBoard;
        Button tempbtn;
        Button tempbtn2;
        Popup mypopup;
        public MainWindow()
        {
            GameBoard = Board.CreateChessBoard();
            InitializeComponent();
            string[,] boarddata = new string[8, 8];
            GameBoard.GetFieldData(ref boarddata);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button btn = new Button();
                    btn.Click += Button_Click;
                    Grid.SetColumn(btn, j);
                    Grid.SetRow(btn, i);
                    if (((7 * i + j) % 2) == 1) btn.Background = new SolidColorBrush(Color.FromRgb(95, 158, 160));
                    else btn.Background = new SolidColorBrush(Color.FromRgb(224, 255, 255));
                    grid.Children.Add(btn);
                }
            }
            update_data();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content != null && tempbtn == null)
            {
                tempbtn = (Button)sender;
                ((Button)sender).BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else if (((Button)sender).Equals(tempbtn))
            {
                ((Button)sender).BorderBrush = ((Button)sender).Background;
                tempbtn = null;
            }
            else if (tempbtn != null)
            {
                int step_result = GameBoard.MoveFig(GameBoard.GetFigure(Grid.GetRow(tempbtn), Grid.GetColumn(tempbtn)), Grid.GetRow((Button)sender), Grid.GetColumn((Button)sender));
                if (step_result == 1)
                {
                    update_data();
                    tempbtn.BorderBrush = tempbtn.Background;
                    tempbtn = null;
                }
                else if (step_result == -1)
                {
                    mypopup = new Popup();
                    mypopup.StaysOpen = false;
                    mypopup.Placement = PlacementMode.Center;
                    StackPanel panel = new StackPanel();
                    panel.Orientation = Orientation.Horizontal;
                    Button btn1 = new Button();
                    Button btn2 = new Button();
                    Button btn3 = new Button();
                    Button btn4 = new Button();
                    Image img1 = new Image();
                    Image img2 = new Image();
                    Image img3 = new Image();
                    Image img4 = new Image();
                    if (GameBoard.GetColor() == chess.Colors.BLACK)
                    {
                        img1.Source = new BitmapImage(new Uri(string.Format("Images/bB.png"), UriKind.Relative));
                        img2.Source = new BitmapImage(new Uri(string.Format("Images/bN.png"), UriKind.Relative));
                        img3.Source = new BitmapImage(new Uri(string.Format("Images/bQ.png"), UriKind.Relative));
                        img4.Source = new BitmapImage(new Uri(string.Format("Images/bR.png"), UriKind.Relative));
                    }
                    else
                    {
                        img1.Source = new BitmapImage(new Uri(string.Format("Images/wB.png"), UriKind.Relative));
                        img2.Source = new BitmapImage(new Uri(string.Format("Images/wN.png"), UriKind.Relative));
                        img3.Source = new BitmapImage(new Uri(string.Format("Images/wQ.png"), UriKind.Relative));
                        img4.Source = new BitmapImage(new Uri(string.Format("Images/wR.png"), UriKind.Relative));
                    }
                    btn1.Content = img1;
                    btn2.Content = img2;
                    btn3.Content = img3;
                    btn4.Content = img4;
                    btn1.Background = new SolidColorBrush(Color.FromRgb(224, 255, 255));
                    btn2.Background = new SolidColorBrush(Color.FromRgb(224, 255, 255));
                    btn3.Background = new SolidColorBrush(Color.FromRgb(224, 255, 255));
                    btn4.Background = new SolidColorBrush(Color.FromRgb(224, 255, 255));
                    tempbtn2 = (Button)sender;
                    btn1.Click += transform_to_bishop;
                    btn2.Click += transform_to_knight;
                    btn3.Click += transform_to_queen;
                    btn4.Click += transform_to_rook;
                    panel.Children.Add(btn1);
                    panel.Children.Add(btn2);
                    panel.Children.Add(btn3);
                    panel.Children.Add(btn4);
                    mypopup.Child = panel;
                    mypopup.Closed += popup_closed;
                    grid.Children.Add(mypopup);
                    mypopup.IsOpen = true;
                }
            }
        }
        private void popup_closed(object sender, System.EventArgs e)
        {
            tempbtn.BorderBrush = tempbtn.Background;
            tempbtn = null;
            tempbtn2 = null;
        }
        private void transform_to_queen(object sender, RoutedEventArgs e)
        {
            int step_result = GameBoard.MoveFig(GameBoard.GetFigure(Grid.GetRow(tempbtn), Grid.GetColumn(tempbtn)), Grid.GetRow(tempbtn2), Grid.GetColumn(tempbtn2), Figures.QUEEN);
            if (step_result == 1)
            {
                mypopup.IsOpen = false;
                update_data();
            }
        }
        private void transform_to_knight(object sender, RoutedEventArgs e)
        {
            int step_result = GameBoard.MoveFig(GameBoard.GetFigure(Grid.GetRow(tempbtn), Grid.GetColumn(tempbtn)), Grid.GetRow(tempbtn2), Grid.GetColumn(tempbtn2), Figures.KNIGHT);
            if (step_result == 1)
            {
                mypopup.IsOpen = false;
                update_data();
            }
        }
        private void transform_to_bishop(object sender, RoutedEventArgs e)
        {
            int step_result = GameBoard.MoveFig(GameBoard.GetFigure(Grid.GetRow(tempbtn), Grid.GetColumn(tempbtn)), Grid.GetRow(tempbtn2), Grid.GetColumn(tempbtn2), Figures.BISHOP);
            if (step_result == 1)
            {
                mypopup.IsOpen = false;
                update_data();
            }
        }
        private void transform_to_rook(object sender, RoutedEventArgs e)
        {
            int step_result = GameBoard.MoveFig(GameBoard.GetFigure(Grid.GetRow(tempbtn), Grid.GetColumn(tempbtn)), Grid.GetRow(tempbtn2), Grid.GetColumn(tempbtn2), Figures.ROOK);
            if (step_result == 1)
            {
                mypopup.IsOpen = false;
                update_data();
            }
        }
        private void update_data()
        {
            string[,] boarddata = new string[8, 8];
            GameBoard.GetFieldData(ref boarddata);
            foreach(Object btn in grid.Children)
            {
                if (btn.GetType() == typeof(Button))
                {
                    if (boarddata[Grid.GetRow(btn as Button), Grid.GetColumn(btn as Button)] == null)
                    {
                        (btn as Button).Content = null;
                    }
                    else
                    {
                        Image img = new Image();
                        img.Source = new BitmapImage(new Uri(string.Format("Images/{0}.png", boarddata[Grid.GetRow(btn as Button), Grid.GetColumn(btn as Button)]), UriKind.Relative));
                        (btn as Button).Content = img;
                    }
                }
            }
        }
    }
}

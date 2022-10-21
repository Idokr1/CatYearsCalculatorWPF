using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Cat_Years_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TextBlock resultTextBlock;
        public TextBox inputCatAge;

        public MainWindow()
        {
            InitializeComponent();
            Image backgroundImage = new Image()
            {
                Source = new BitmapImage(
                    new Uri(Environment.CurrentDirectory + @"\..\..\Images\cat.jpg", UriKind.RelativeOrAbsolute)),
                Width = 400
            };
            resultTextBlock = new TextBlock() { Text = "Your cat is ", FontSize = 20 };

            inputCatAge = new TextBox() { Width = 120, TextAlignment = TextAlignment.Center, FontSize = 16, Margin = new Thickness(5, 0, 0, 0) };
            inputCatAge.KeyDown += inputCatAge_KeyDown;

            TextBlock userQuestion = new TextBlock() { Text = "How old is your cat?", FontSize = 18};
            StackPanel HorizontalSP = new StackPanel() { Orientation = Orientation.Horizontal, Margin = new Thickness(1,5,0,0)};

            HorizontalSP.Children.Add(userQuestion);
            HorizontalSP.Children.Add(inputCatAge);


            StackPanel MainVerticalStackPanel = new StackPanel();

            MainVerticalStackPanel.Children.Add(HorizontalSP);
            MainVerticalStackPanel.Children.Add(resultTextBlock);
            MainVerticalStackPanel.Children.Add(backgroundImage);
            myMainWindow.Content = MainVerticalStackPanel;

        }
        private void inputCatAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    int catAge = Int32.Parse(inputCatAge.Text);
                    string resultHumanAge = "";

                    if (catAge > 0 && catAge <= 1)
                    {
                        resultHumanAge = "0-15";
                        resultTextBlock.Text = $"Your cat is {resultHumanAge} years old";
                    }
                    else if (catAge >= 2 && catAge < 25)
                    {
                        resultHumanAge = (((catAge - 2) * 4) + 24).ToString();
                        resultTextBlock.Text = $"Your cat is {resultHumanAge} years old";
                    }
                    else
                    {
                        resultTextBlock.Text = "You enter a value that isn't between 0-25";
                    }
                }
                catch (Exception myException)
                {
                    MessageBox.Show($"Not a valid number, please enter a numeric value: {myException.Message}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;//Подключение стартовых библиотек
namespace ArraySorter
{
    public partial class MainWindow : Window//Основной класс окна
    {
        public MainWindow()
        {
            InitializeComponent();//Инициализация элементов стартового окна
        }
        private void TbArray_PreviewTextInput(object sender, TextCompositionEventArgs e)//Ограничения ввода
         {
            e.Handled = "0123456789- ".IndexOf(e.Text) < 0;
        }
        private void BtnStart_Click(object sender, RoutedEventArgs e)//Рандом массива
        {
            string[] values = tbArray.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var item in values)
            {
                if (item.Length > 4 || values.Length > 20)
                {
                    if (item.Length > 4)
                    {
                        MessageBox.Show("Числа слишком большие", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);//Сообщение об ошибке "Числа слишком большие"
                        tbArray.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Массив слишком длинный", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);//Сообщение об ошибке "Массив слишком длинный"
                        tbArray.Focus();
                        return;
                    }
                }
            }
            if (tbArray.Text.Trim() == "")
            {
                MessageBox.Show("Пожалуйста, введите массив", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);//Сообщение об ошибке "Пожалуйста, введите массив"
                tbArray.Focus();
                return;
            }
            if(cbAlgorithm.Text=="")
            {
                MessageBox.Show("Пожалуйста, выберите алгоритм", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);//Сообщение об ошибке "Пожалуйста, выберите алгоритм"
                cbAlgorithm.Focus();
                return;
            }
            if(cbState.Text=="")
            {
                MessageBox.Show("Пожалуйста, выберите настройки", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);//Сообщение об ошибке "Пожалуйста, выберите настройки"
                cbState.Focus();
                return;
            }
            else
            {
                Demonstration window = new Demonstration();//Создание окна демонстрации
                window.Owner = this;
                window.Alg = new string[2];//Стартовый массив
                window.Alg[0] = cbAlgorithm.Text;
                window.Alg[1] = cbState.Text;
                try
                {
                    int[] arr = values.Select(x => int.Parse(x)).ToArray();
                    int coordinate1 = 0;
                    window.Elements = new Label[arr.Length];
                    for (int i = 0; i < arr.Length; i++)//Создание элементов в окне демонстрации
                    {
                        Label element = new Label();
                        element.Width = 50;
                        element.Height = 50;
                        element.Content = arr[i].ToString();
                        element.BorderBrush = Brushes.Black;
                        element.BorderThickness = new Thickness(2.0);
                        element.Foreground = Brushes.Black;
                        element.HorizontalAlignment = HorizontalAlignment.Center;
                        element.VerticalAlignment = VerticalAlignment.Center;
                        element.Tag = coordinate1;
                        window.cnvArray.Children.Add(element);
                        window.Elements[i] = element;
                        Canvas.SetLeft(element, coordinate1);
                        coordinate1 += 50;
                    }
                    window.Width = coordinate1 + 50;
                    window.ShowDialog();//Вывод окна
                }
                catch(Exception)
                {
                    MessageBox.Show("Введите корректный массив!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);//Сообщение об ошибке "Введите корректный массив!"
                }                
            }
        }

        private void WMain_Loaded(object sender, RoutedEventArgs e)//Фокус окна
        {
            tbArray.Focus();
        }

        private void BtnRand_Click(object sender, RoutedEventArgs e)//Генерация массива
        {
            tbArray.Clear();
            Random random = new Random();
            int[] arr = new int[random.Next(3, 12)];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-9, 10);
                tbArray.Text += arr[i] + " ";
            }
        }
        //
        private void btnHelp_Click(object sender, RoutedEventArgs e)//Окно помощи
        {
            Window helpWindow = new Window();
            helpWindow.Width = 900;
            helpWindow.Height = 615;
            helpWindow.Focus();
            helpWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            helpWindow.Title = "Помощь";
            helpWindow.ResizeMode = ResizeMode.NoResize;
            StreamReader sr = new StreamReader("help.txt");//Чтение содержимого вспомогательного файла
            string text = sr.ReadToEnd();
            Grid grid = new Grid();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            StackPanel testPanel = new StackPanel();
            testPanel.Orientation = Orientation.Horizontal;
            testPanel.Children.Add(textBlock);
            grid.Children.Add(testPanel);
            helpWindow.Content = grid;
            helpWindow.ShowDialog();//Вывод окна помощи
        }
    }
}

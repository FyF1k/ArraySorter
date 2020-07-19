using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;//Подключение стартовых библиотек

namespace ArraySorter
{
    //Interaction logic for Demonstration.xaml
    class State//Класс стартовых переменных
    {
        public int CurrentIndex { get; set; }
        public int ChangebleIndex { get; set; }
        public bool IsSwap { get; set; }
    }
    public partial class Demonstration : Window//Главный класс демонстрации
    {
        readonly string NonInc = "Невозрастающий";//Определение настроек
        readonly string NonDec = "Неубывающий";//Определение настроек
        string BubbleSort = "Пузырьковая сортировка";//Определение названий алгоритмов
        string SelectionSort = "Сортировка выбором";//Определение названий алгоритмов
        string CombSort = "Сортировка расчёской";//Определение названий алгоритмов
        public string[] Alg { get; set; }//Массив алгоритма
        int counter = 0;
        List<State> states = new List<State>();//Лист значений
        public Label[] Elements { get; set; }//Лейбл элементов 
        #region BubbleSort
        public void BubbleSortAscending()//Возрастающая пузырьковая сортировка
        {
            int[] arr = new int[cnvArray.Children.Count];
            for (int i=0;i<arr.Length;i++)
            {
                arr[i] = int.Parse((cnvArray.Children[i] as Label).Content.ToString());//Парсинг значений в массив
            }
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)//Цикл сортировки
                {
                    State st = new State();
                    st.CurrentIndex = j;//Обработка индексов
                    st.ChangebleIndex = j + 1;
                    st.IsSwap = false;
                    if (arr[j + 1] < arr[j])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        st.IsSwap = true;
                    }
                    states.Add(st);
                }
            }
        }
        public void BubbleSortDescending()//Убывающая пузырьковая сортировка
        {
            int[] arr = new int[cnvArray.Children.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse((cnvArray.Children[i] as Label).Content.ToString());//Парсинг значений в массив
            }
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)//Цикл сортировки
                {
                    State st = new State();
                    st.CurrentIndex = j;
                    st.ChangebleIndex = j + 1;
                    st.IsSwap = false;
                    if (arr[j + 1] > arr[j])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                        st.IsSwap = true;
                    }
                    states.Add(st);
                }
            }
        }
        #endregion
        #region SelectionSort
        public void SelectionSortAscending()//Возрастающая SelectionSort
        {
            int[] arr = new int[cnvArray.Children.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse((cnvArray.Children[i] as Label).Content.ToString());//Парсинг значений в массив
            }
            int min, temp;
            int length = arr.Length;
            for (int i = 0; i < length - 1; i++)//Цикл сортировки
            {        
                min = i;
                for (int j = i + 1; j < length; j++)//Цикл сортировки
                {
                    State st1 = new State();//Обработка индексов            
                    st1.CurrentIndex = min;
                    st1.ChangebleIndex = j;
                    st1.IsSwap = false;
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                    states.Add(st1);
                }
                State st2 = new State();//Цикл сортировки
                st2.CurrentIndex = i;
                st2.ChangebleIndex = min;
                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                    st2.IsSwap = true;
                }
                states.Add(st2);
            }
        }
        public void SelectionSortDescending()//Убывающая SelectionSort
        {
            int[] arr = new int[cnvArray.Children.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse((cnvArray.Children[i] as Label).Content.ToString());//Парсинг значений в массив
            }
            int min, temp;
            int length = arr.Length;

            for (int i = 0; i < length - 1; i++)//Цикл сортировки
            {
                min = i;
                for (int j = i + 1; j < length; j++)//Цикл сортировки
                {
                    State st1 = new State();//Обработка индексов
                    st1.CurrentIndex = min;
                    st1.ChangebleIndex = j;
                    st1.IsSwap = false;
                    if (arr[j] > arr[min])
                    {
                        min = j;
                    }
                    states.Add(st1);
                }
                State st2 = new State();//Цикл сортировки
                st2.CurrentIndex = i;
                st2.ChangebleIndex = min;
                if (min != i)
                {
                    temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                    st2.IsSwap = true;
                }
                states.Add(st2);
            }
        }
        #endregion
        #region ComboSort
        public void combSortAscending()//Возрастающая Сombо Sort
        {
            int[] arr = new int[cnvArray.Children.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse((cnvArray.Children[i] as Label).Content.ToString());//Парсинг значений в массив
            }
            double gap = arr.Length;
            bool swaps = true;
            while (gap > 1 || swaps)//Цикл сортировки
            {
                gap =(int)gap/ 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < arr.Length)
                {
                    int igap = i + (int)gap;
                    State st = new State();//Обработка индексов
                    st.CurrentIndex = i;
                    st.ChangebleIndex = igap;
                    st.IsSwap = false;
                    if (arr[i] > arr[igap])//Цикл сортировки
                    {
                        int swap = arr[i];
                        arr[i] = arr[igap];
                        arr[igap] = swap;
                        swaps = true;
                        st.IsSwap = true;
                    }
                    states.Add(st);
                    i++;
                }
            }
        }
        public void combSortDescending()//Убывающая Сombо Sort
        {
            int[] arr = new int[cnvArray.Children.Count];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse((cnvArray.Children[i] as Label).Content.ToString());//Парсинг значений в массив
            }
            double gap = arr.Length;
            bool swaps = true;
            while (gap > 1 || swaps)
            {
                gap = (int)gap / 1.247330950103979; ;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < arr.Length)//Цикл сортировки
                {
                    int igap = i + (int)gap;
                    State st = new State();
                    st.CurrentIndex = i;
                    st.ChangebleIndex = igap;
                    st.IsSwap = false;
                    if (arr[i] < arr[igap])//Цикл сортировки
                    {
                        int swap = arr[i];
                        arr[i] = arr[igap];
                        arr[igap] = swap;
                        swaps = true;
                        st.IsSwap = true;
                    }
                    states.Add(st);
                    i++;
                }
            }
        }
        #endregion
        public void Animation(int temp)//Обработка анимаций
        {
            SolidColorBrush brush1 = new SolidColorBrush();//Создание элементов анимаций
            SolidColorBrush brush2 = new SolidColorBrush();
            Elements[states[temp].CurrentIndex].Background = brush1;
            Elements[states[temp].ChangebleIndex].Background = brush2;
            ColorAnimation da = new ColorAnimation();
            ColorAnimation da1 = new ColorAnimation();
            da.To = Colors.Red;
            da.SpeedRatio = 4;
            da1.To = Colors.Blue;
            da1.SpeedRatio = 4;
            brush1.BeginAnimation(SolidColorBrush.ColorProperty, da1);
            brush2.BeginAnimation(SolidColorBrush.ColorProperty, da);

            if (states[temp].IsSwap)//Смена элементов
            {
                DoubleAnimation animation1 = new DoubleAnimation();
                animation1.By = Math.Abs(states[temp].ChangebleIndex - states[temp].CurrentIndex) * 50;
                Storyboard.SetTarget(animation1, Elements[states[temp].CurrentIndex]);
                Storyboard.SetTargetProperty(animation1, new PropertyPath(Canvas.LeftProperty));
                DoubleAnimation animation2 = new DoubleAnimation();
                animation2.By = Math.Abs(states[temp].ChangebleIndex - states[temp].CurrentIndex) * -50;
                Storyboard.SetTarget(animation2, Elements[states[temp].ChangebleIndex]);
                Storyboard.SetTargetProperty(animation2, new PropertyPath(Canvas.LeftProperty));
                Storyboard animation = new Storyboard();
                animation.Children = new TimelineCollection { animation1, animation2 };
                animation.SpeedRatio = 2;
                animation.BeginTime =TimeSpan.FromSeconds(0.7);
                animation.CurrentStateInvalidated += CurrentStateInvalidated;
                animation.Completed += Completed;
                animation.Begin();
                Label tmp = Elements[states[temp].CurrentIndex];
                Elements[states[temp].CurrentIndex] = Elements[states[temp].ChangebleIndex];//Свап элементов
                Elements[states[temp].ChangebleIndex] = tmp;
            }
        }
        private void Completed(object sender, EventArgs e)//Статус законченной работы
        {
            btnNext.IsEnabled = true;
            btnPrev.IsEnabled = true;
        }
        private void CurrentStateInvalidated(object sender, EventArgs e)//Текущий статус
        {
            btnNext.IsEnabled = false;
            btnPrev.IsEnabled = false;
        }
        public Demonstration()//Инициализация компонентовт окна
        {
            InitializeComponent();
        }
        private void BtnNext_Click(object sender, RoutedEventArgs e)//Обработка кнопки "Далее"
        {
            int step = int.Parse(lbNStep.Content.ToString());
            lbNStep.Content = (++step).ToString();
            if (Alg[0] == BubbleSort)//Обработка BubbleSort
            {
                if (Alg[1] == NonDec)//Обработка BubbleSort возврастающей
                {
                    btnPrev.IsEnabled = true;
                    if (counter == 0)
                    {
                        states.Clear();
                        BubbleSortAscending();
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnNext.IsEnabled = false;
                        btnPrev.IsEnabled = false;
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == states.Count)
                    {
                        btnNext.IsEnabled = false;
                        tbStep.Text = "Сортировка закончена!";
                        return;
                    }
                    if(states[counter].IsSwap==true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    Animation(counter++);
                }
                else//Обработка BubbleSort убывающей
                {
                    btnPrev.IsEnabled = true;
                    if (counter == 0)
                    {
                        states.Clear();
                        BubbleSortDescending();                    
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnNext.IsEnabled = false;
                        btnPrev.IsEnabled = false;
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == states.Count)
                    {
                        btnNext.IsEnabled = false;
                        tbStep.Text = "Сортировка закончена!";
                        return;
                    }
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    Animation(counter++);
                }
            }
            if(Alg[0]== SelectionSort)//Обработка SelectionSort
            {
                if (Alg[1] == NonDec)//Обработка SelectionSort возрастающей
                {
                    btnPrev.IsEnabled = true;
                    if (counter == 0)
                    {
                        states.Clear();
                        SelectionSortAscending();
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnNext.IsEnabled = false;
                        btnPrev.IsEnabled = false;
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == states.Count)
                    {
                        btnNext.IsEnabled = false;
                        tbStep.Text = "Сортировка закончена!";

                        return;
                    }
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    Animation(counter++);
                }
                else//Обработка SelectionSort убывающей
                {
                    btnPrev.IsEnabled = true;
                    if (counter == 0)
                    {
                        states.Clear();
                        SelectionSortDescending();
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnNext.IsEnabled = false;
                        btnPrev.IsEnabled = false;
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == states.Count)
                    {
                        tbStep.Text = "Сортировка закончена!";
                        btnNext.IsEnabled = false;
                        return;
                    }
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    Animation(counter++);
                }
            }
            if (Alg[0] == CombSort)//Обработка CombSort
            {
                if (Alg[1] == NonDec)//Обработка CombSort возврастающей
                {
                    btnPrev.IsEnabled = true;
                    if (counter == 0)
                    {
                        states.Clear();
                        combSortAscending();
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnNext.IsEnabled = false;
                        btnPrev.IsEnabled = false;
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == states.Count)
                    {
                        btnNext.IsEnabled = false;
                        btnPrev.IsEnabled = false;
                        tbStep.Text = "Сортировка закончена!";
                        return;
                    }
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    Animation(counter++);
                }
                else//Обработка CombSort возврастающей
                {
                    btnPrev.IsEnabled = true;
                    if (counter == 0)
                    {
                        states.Clear();
                        combSortDescending();
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnNext.IsEnabled = false;
                        btnPrev.IsEnabled = false;
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == states.Count)
                    {
                        tbStep.Text = "Сортировка закончена!";
                        btnNext.IsEnabled = false;
                        return;
                    }
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    Animation(counter++);
                }
            }
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)//Обработка кнопки ""Назад"
        {
            int step = int.Parse(lbNStep.Content.ToString());//Вывод числа шагов
            if (step != 0)
                lbNStep.Content = (--step).ToString();
            else
                tbStep.Clear();
            if (Alg[0] == BubbleSort)//Обработка BubbleSort
            {
                if (Alg[1] == NonDec)//Обработка BubbleSort возврастающей
                {
                    if (counter == 0)
                    {
                        states.Clear();
                        BubbleSortAscending();
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == 0)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = true;
                        return;
                    }
                    Animation(--counter);
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = false;
                    }
                }
                else//Обработка BubbleSort убывающей
                {
                    if (counter == 0)
                    {
                        states.Clear();
                        BubbleSortDescending();
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;

                    }
                    if (counter == states.Count)
                    {
                        btnNext.IsEnabled = false;
                        return;
                    }
                    if (counter == 0)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = true;
                        return;
                    }
                    Animation(--counter);
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = false;
                    }
                }
            }
            if (Alg[0]== SelectionSort)//Обработка SelectionSort
            {
                if (Alg[1] == NonDec)//Обработка SelectionSort возврастающей
                {
                    if (counter == 0)
                    {
                        states.Clear();
                        SelectionSortAscending();
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == 0)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = true;
                        return;
                    }
                    Animation(--counter);
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = false;
                    }
                }
                else//Обработка SelectionSort убывающей
                {
                    if (counter == 0)
                    {
                        states.Clear();
                        SelectionSortAscending();
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;

                    }
                    if (counter == states.Count)
                    {
                        btnNext.IsEnabled = false;
                        return;
                    }
                    if (counter == 0)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = true;
                        return;
                    }
                    Animation(--counter);
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = false;
                    }
                }
            }
            if (Alg[0] == CombSort)//Обработка CombSort
            {
                if (Alg[1] == NonDec)//Обработка CombSort возврастающей
                {
                    if (counter == 0)
                    {
                        states.Clear();
                        combSortAscending();
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;
                    }
                    if (counter == 0)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = true;
                        return;
                    }
                    Animation(--counter);
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = false;
                    }
                }
                else//Обработка CombSort убывающей
                {
                    if (counter == 0)
                    {
                        states.Clear();
                        combSortDescending();
                    }
                    foreach (Label item in cnvArray.Children)
                    {
                        item.Background = Brushes.White;

                    }
                    if (counter == states.Count)
                    {
                        btnNext.IsEnabled = false;
                        return;
                    }
                    if (counter == 0)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = true;
                        return;
                    }
                    Animation(--counter);
                    if (states[counter].IsSwap == true)
                    {
                        tbStep.Text = $"Обмен [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    else
                    {
                        tbStep.Text = $"Сравнение [{states[counter].CurrentIndex}] и [{states[counter].ChangebleIndex}]";
                    }
                    if (counter < states.Count && states[counter].IsSwap)
                    {
                        btnPrev.IsEnabled = false;
                        btnNext.IsEnabled = false;
                    }
                }
            }
        }
        private void WDemonstration_Loaded(object sender, RoutedEventArgs e)//Загрузка кнопок
        {
            btnPrev.IsEnabled = false;
        }
    }
}
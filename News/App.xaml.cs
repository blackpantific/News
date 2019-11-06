using News.Helpers;
using News.Models;
using News.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace News
{
    /// <summary>
    /// Обеспечивает зависящее от конкретного приложения поведение, дополняющее класс Application по умолчанию.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Инициализирует одноэлементный объект приложения. Это первая выполняемая строка разрабатываемого
        /// кода, поэтому она является логическим эквивалентом main() или WinMain().
        /// </summary>
        /// 

        public Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            //полноэкранный режим

           

        }

        /// <summary>
        /// Вызывается при обычном запуске приложения пользователем. Будут использоваться другие точки входа,
        /// например, если приложение запускается для открытия конкретного файла.
        /// </summary>
        /// <param name="e">Сведения о запросе и обработке запуска.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            await ReadUserCheckedListElementsAsync();
            


            Frame rootFrame = Window.Current.Content as Frame;

            // Не повторяйте инициализацию приложения, если в окне уже имеется содержимое,
            // только обеспечьте активность окна
            if (rootFrame == null)
            {
                // Создание фрейма, который станет контекстом навигации, и переход к первой странице
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Загрузить состояние из ранее приостановленного приложения
                }

                // Размещение фрейма в текущем окне
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // Если стек навигации не восстанавливается для перехода к первой странице,
                    // настройка новой страницы путем передачи необходимой информации в качестве параметра
                    // навигации
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Обеспечение активности текущего окна
                Window.Current.Activate();
            }


        }

        /// <summary>
        /// Вызывается в случае сбоя навигации на определенную страницу
        /// </summary>
        /// <param name="sender">Фрейм, для которого произошел сбой навигации</param>
        /// <param name="e">Сведения о сбое навигации</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Вызывается при приостановке выполнения приложения.  Состояние приложения сохраняется
        /// без учета информации о том, будет ли оно завершено или возобновлено с неизменным
        /// содержимым памяти.
        /// </summary>
        /// <param name="sender">Источник запроса приостановки.</param>
        /// <param name="e">Сведения о запросе приостановки.</param>
        private  void OnSuspending(object sender, SuspendingEventArgs e)
        {
            WriteUserCheckedListElementsAsync();//json user data to file
            //await

            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Сохранить состояние приложения и остановить все фоновые операции
            deferral.Complete();
        }


        public async void WriteUserCheckedListElementsAsync()
        {
            var json = JsonConvert.SerializeObject(InterestsService.SaveSelectedListBoxItems);

            var storageUserCheckedListFile = await localFolder.CreateFileAsync("userDataCheckedList.txt", 
                CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageUserCheckedListFile, json);
        }

        public async Task ReadUserCheckedListElementsAsync()
        {
            try
            {
                var storageUserCheckedListFile = await localFolder.GetFileAsync("userDataCheckedList.txt");
                var json = await FileIO.ReadTextAsync(storageUserCheckedListFile);

                ConstantHelper.DeserializedJsonFromTxtFile = JsonConvert.DeserializeObject<List<NewsTopics>>(json)
                    .OrderByDescending(item => item.TopicId)
                    .ToList();

                ConstantHelper.SetCheckedListsValues();
            }
            catch(FileNotFoundException e)
            {
                var messageDialog = new MessageDialog(e.Message);
                await messageDialog.ShowAsync();
            }
            catch(IOException e)
            {
                var messageDialog = new MessageDialog(e.Message);
                await messageDialog.ShowAsync();
            }
            catch(Exception e)
            {
                var messageDialog = new MessageDialog(e.Message);
                await messageDialog.ShowAsync();
            }
        }

    }
}

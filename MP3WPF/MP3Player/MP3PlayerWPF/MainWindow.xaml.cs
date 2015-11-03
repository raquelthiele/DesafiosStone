using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace MP3PlayerWPF
{
    /// <summary>
    /// Class of the Main Window that is called when 
    /// the applicantions starts
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The mediaPlayer property
        /// </summary>
        private MediaPlayer mediaPlayer = new MediaPlayer();

        /// <summary>
        /// The entry point for the application.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method responsible for a response action when clicking the button Open
        /// </summary>
        /// It opens a File Dialog and allows to open a mp3 file
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerLabel_Tick;
            timer.Start();
        }

        /// <summary>
        ///Method responsible for setting the name of the file and the durration time
        /// </summary>
        /// <param name="validateMe"></param>
        /// <returns></returns>
        void timerLabel_Tick(object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null){
                if (mediaPlayer.NaturalDuration.HasTimeSpan)
                {
                    timerLabel.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                }
                else
                {
                    timerLabel.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.ToString());
                }
                runningLabel.Content = System.IO.Path.GetFileNameWithoutExtension(mediaPlayer.Source.ToString());
              }           
        }

        /// <summary>
        ///Method responsible for a response action when clicking the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        /// <summary>
        ///Method responsible for a response action when clicking the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        /// <summary>
        ///Method responsible for a response action when clicking the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
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

namespace MegamanUI_WPF.NetCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region properties
        private bool _IsInjected;
        public bool IsInjected
        {
            get => _IsInjected;
            set
            {
                _IsInjected = value;
                OnPropertyChanged();
            }
        }


        private Visibility _IsExitShow;
        public Visibility IsExitShow
        {
            get => _IsExitShow;
            set
            {
                _IsExitShow = value;
                OnPropertyChanged();
            }
        }

        private bool _IsOneHitCreep;
        public bool IsOneHitCreep
        {
            get => _IsOneHitCreep;
            set
            {
                _IsOneHitCreep = value;
                OnPropertyChanged();
            }
        }

        private bool _IsOneHitBoss;
        public bool IsOneHitBoss
        {
            get => _IsOneHitBoss;
            set
            {
                _IsOneHitBoss = value;
                OnPropertyChanged();
            }
        }

        private bool _IsFullLife;
        public bool IsFullLife
        {
            get => _IsFullLife;
            set
            {
                _IsFullLife = value;
                OnPropertyChanged();
            }
        }

        private bool _IsImotal;
        public bool IsImotal
        {
            get => _IsImotal;
            set
            {
                _IsImotal = value;
                OnPropertyChanged();
            }
        }

        SoundPlayer sp_active;
        SoundPlayer sp_hover;
        SoundPlayer sp_active_all;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            FirstLoad();
        }



        #region methods
        void FirstLoad()
        {
            IsInjected = false;
            IsExitShow = Visibility.Hidden;
            LoadSound();
        }

        void LoadSound()
        {
            sp_active = new SoundPlayer(Properties.Resources.hover_2);
            sp_hover = new SoundPlayer(Properties.Resources.hover);
            sp_active_all = new SoundPlayer(Properties.Resources.megaman);

        }
        void PlaySoundActive()
        {
            sp_active.Play();
        }
        void PlaySoundActiveAll()
        {
            sp_active_all.Play();
        }
        void PlaySoundHover()
        {
            sp_hover.Play();
        }
        #endregion


        #region event
        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Image_PreviewMouseDown_Close(object sender, MouseButtonEventArgs e)
        {
            IsExitShow = Visibility.Visible;
        }

        private void Image_PreviewMouseDown_Minimize(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Image_MouseLeftButtonDown_Megaman_Center(object sender, MouseButtonEventArgs e)
        {
            IsInjected = !IsInjected;
            PlaySoundActive();
        }

        private void Image_MouseLeftButtonDown_OneHitCreep(object sender, MouseButtonEventArgs e)
        {
            IsOneHitCreep = !IsOneHitCreep;
            PlaySoundActive();
        }

        private void Image_MouseLeftButtonDown_OneHitBoss(object sender, MouseButtonEventArgs e)
        {
            IsOneHitBoss = !IsOneHitBoss;
            PlaySoundActive();
        }

        private void Image_MouseLeftButtonDown_FullLife(object sender, MouseButtonEventArgs e)
        {
            IsFullLife = !IsFullLife;
            PlaySoundActive();
        }

        private void Image_MouseLeftButtonDown_Imotal(object sender, MouseButtonEventArgs e)
        {
            IsImotal = !IsImotal;
            PlaySoundActive();
        }

        private void Image_MouseEnter_Megaman_Center(object sender, MouseEventArgs e)
        {
            if (!IsInjected) PlaySoundHover();
        }
        private void Image_MouseEnter_OneHitCreep(object sender, MouseEventArgs e)
        {
            if (!IsOneHitCreep) PlaySoundHover();
        }
        private void Image_MouseEnter_OneHitBoss(object sender, MouseEventArgs e)
        {
            if (!IsOneHitBoss) PlaySoundHover();
        }
        private void Image_MouseEnter_FullLife(object sender, MouseEventArgs e)
        {
            if (!IsFullLife) PlaySoundHover();
        }
        private void Image_MouseEnter_Imotal(object sender, MouseEventArgs e)
        {
            if (!IsImotal) PlaySoundHover();
        }

        private void Image_MouseLeftButtonDown_Logo(object sender, MouseButtonEventArgs e)
        {
            PlaySoundActiveAll();
            if (IsInjected
                && IsOneHitCreep
                && IsOneHitBoss
                && IsFullLife
                && IsImotal)
            {
                IsInjected = false;
                IsOneHitCreep = false;
                IsOneHitBoss = false;
                IsFullLife = false;
                IsImotal = false;
            }
            else
            {
                IsInjected = true;
                IsOneHitCreep = true;
                IsOneHitBoss = true;
                IsFullLife = true;
                IsImotal = true;
            }

        }
        private void TextBlock_MouseLeftButtonDown_Author(object sender, MouseButtonEventArgs e)
        {
            var ps = new ProcessStartInfo("https://nguyenlean.com/index.php")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }
        private void Image_MouseLeftButtonDown_Kteam(object sender, MouseButtonEventArgs e)
        {
            var ps = new ProcessStartInfo("https://www.howkteam.vn/")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                PlaySoundActiveAll();
                IsInjected = true;
                IsOneHitCreep = true;
                IsOneHitBoss = true;
                IsFullLife = true;
                IsImotal = true;
                MessageBox.Show("Active All...!");

            }
            else if (e.Key == Key.F2)
            {
                PlaySoundActive();
                IsInjected = false;
                IsOneHitCreep = false;
                IsOneHitBoss = false;
                IsFullLife = false;
                IsImotal = false;
                MessageBox.Show("Deactivate All...!");
            }
        }






        #endregion

        private void TextBlock_MouseLeftButtonDown_YesExit(object sender, MouseButtonEventArgs e)
        {
            PlaySoundActive();
            this.Close();
        }

        private void TextBlock_MouseLeftButtonDown_NoExit(object sender, MouseButtonEventArgs e)
        {
            PlaySoundActive();
            IsExitShow = Visibility.Hidden;
        }

        private void TextBlock_MouseEnter_YesExit(object sender, MouseEventArgs e)
        {
            PlaySoundHover();
        }

        private void TextBlock_MouseEnter_NoExit(object sender, MouseEventArgs e)
        {
            PlaySoundHover();
        }
    }
}

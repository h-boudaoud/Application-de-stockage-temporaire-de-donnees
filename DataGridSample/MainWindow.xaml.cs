using DataGridSample.ViewModel;
using System.Windows;
using System.Windows.Media;

namespace DataGridSample
{
    public partial class DataGridDetailsSample : Window
    {
        private readonly double heightWindows = SystemParameters.VirtualScreenHeight;
        private readonly double widthWindows = SystemParameters.VirtualScreenWidth;
        private readonly FicheClientsViewModel ficheClientsViewModel = new FicheClientsViewModel();

        public DataGridDetailsSample()
        {

            InitializeComponent();
            windows.Width = widthWindows * .8;
            windows.Height = heightWindows * .8;
            myStackPanelItems.Width = windows.Width * 2.5 / 4;
            myStackPanelUser.MinWidth = windows.Width * 1.5 / 4 - 80;
            myStackPanelUser.MaxWidth = windows.Width * 2.5 / 4 - 80;
            myStackPanelUser.Height = myStackPanelItems.Height;
            infosUser.Height = myStackPanelUser.Height - 20;
            adressUser.Height = 0;
            DataContext = ficheClientsViewModel;

        }

        private void BarreVertical_Click(object sender, RoutedEventArgs e)
        {
            if (barreVertical.Content.ToString() == "<")
            {
                barreVertical.Content = ">";
                myStackPanelItems.Width = windows.Width / 4;
                myStackPanelUser.Width = windows.Width *3/4;
            }
            else
            {
                barreVertical.Content = "<";
                myStackPanelItems.Width = windows.Width*3/4;
                myStackPanelUser.Width = windows.Width / 4;
            }

        }

        private void BarreHorizontale_Click(object sender, RoutedEventArgs e)
        {
            //RotateTransform rotate = new RotateTransform();
            if (infosUser.Height == 0)
            {
                infosUser.Height = myStackPanelUser.Height - 20;
                adressUser.Height = 0;
                //rotate.Angle = 180;
                barreHorizontale.Content = "˄";

            }
            else
            {
                barreHorizontale.Content = "˅";
                infosUser.Height = 0;
                adressUser.Height = myStackPanelItems.Height - 20; 
                //rotate.Angle = 0;
            }

            //barreHorizontale.RenderTransform = rotate;

        }

    }

}
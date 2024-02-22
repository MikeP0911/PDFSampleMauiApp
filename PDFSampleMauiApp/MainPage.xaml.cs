
using PDFSampleMauiApp.Views;

namespace PDFSampleMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method to navigate to Viewer page- On click of ViewPDF button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Viewer());
        }
    }

}

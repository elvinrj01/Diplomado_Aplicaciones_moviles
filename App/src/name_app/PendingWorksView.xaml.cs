using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PendingWorksView : ContentPage
    {

        List<Works> Works = Enumerable.Empty<Works>().ToList();
        public PendingWorksView()
        {
            InitializeComponent();

            Works.Add(new Works()
            {
                Title = "Work 1",
                Description = "Do work 1",
                Date = DateTime.Now,
                MissingDates = 1
            });

            Works.Add(new Works()
            {
                Title = "Work 2",
                Description = "Do work 2",
                Date = DateTime.Now,
                MissingDates = 2
            });

            Works.Add(new Works()
            {
                Title = "Work 3",
                Description = "Do work 3",
                Date = DateTime.Now,
                MissingDates = 3
            });

            worksListView.ItemsSource = Works;
        }

        #region Properties

        private Works _worksListSelected;
        public Works WorksListSelected
        {
            get
            {
                return _worksListSelected;
            }
            set
            {
                _worksListSelected = value;
                WorkSelected(_worksListSelected);
            }
        }

        #endregion Properties

        async void WorkSelected(Works workselected)
        {
            if (workselected == null) { return; }

            await Navigation.PushAsync(new NavigationPage(new PendingWorkDetails(workselected)));
            WorksListSelected = null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Proyectofinal
{
    public partial class AlbumDetailPage : ContentPage
    {
        private const string URL = @"https://jsonplaceholder.typicode.com/photos?albumId={0}";
        private int AlbumId;
        private HttpClient httpClient = new HttpClient();

        #region Properties

        public ObservableCollection<Photo> Photos { get; set; }

        #endregion Properties

        public AlbumDetailPage(int albumId)
        {
            InitializeComponent();

            AlbumId = albumId;
            Photos = new ObservableCollection<Photo>();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //TODO: Implementar el codigo para descargar la lista de fotos de un album
            // Usar la constante URL declarada al inicio de la clase y reemplazar {0}
            // Por la variable albumId

            IsBusy = true;

            var url = string.Format(URL, AlbumId);
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                try
                {
                    var items = JsonConvert.DeserializeObject<List<Photo>>(jsonResponse);

                    if (items != null && items.Any())
                    {
                        Photos.Clear();
                        foreach(var item in items)
                        {
                            Photos.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", "No se pudo obtener el Album seleccionado", "Ok");
                }

            }
            else
            {
                await DisplayAlert("Error", "No se pudo obtener el Album seleccionado", "Ok");
            }

            photoCollection.ItemsSource = Photos;
            IsBusy = false;
        }
    }
}

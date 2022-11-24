using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using S7Cchachalo.Modelo;
using System.Collections.ObjectModel;

namespace S7Cchachalo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {

        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Datos();
        }
        public async void Datos()
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListadoEstudiante.ItemsSource = tablaEstudiante;



        }
        private void ListadoEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            var IdSeleccionado = Convert.ToInt32(item);


            try
            {
                Navigation.PushAsync(new Elemento(IdSeleccionado));

            }
            catch (Exception)
            {

                throw;
            }               
        }

        private void ListadoEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7Cchachalo.Modelo;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S7Cchachalo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSel;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> borrar;
        IEnumerable<Estudiante> actualizar;

        public Elemento(int id)
        {
            InitializeComponent();
            idSel = id;
            con = DependencyService.Get<Database>().GetConnection();

        }
        public static IEnumerable<Estudiante> borrar1(SQLiteConnection db, int id)
        {

            return db.Query<Estudiante>("Delete from estudiante where id = ?", id);
        }
        public static IEnumerable<Estudiante> actualizar1(SQLiteConnection db, int id, string nombre,string usuario, string contrasena)
        {
            return db.Query<Estudiante>("Update Estudiante set Nombre=?, contrasena=? where id = ?", nombre, usuario, contrasena, id);
        }
        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteAsyncConnection(databasePath);
                actualizar = actualizar1(db, idSel, txtNombre.Text, txtUsuario.Text, txtContrasena.Text);
                DisplayAlert("Mensaje", "Actualizar", "OK");

                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception)
            {

                throw;
            }

        }

        private IEnumerable<Estudiante> actualizar1(SQLiteAsyncConnection db, int idSel, string text1, string text2, string text3)
        {
            throw new NotImplementedException();
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);
            borrar = borrar1(db, idSel);
            DisplayAlert("MENSAJE", "Eliminar", "OK");

            Navigation.PushAsync(new ConsultaRegistro());
        }
    }
}
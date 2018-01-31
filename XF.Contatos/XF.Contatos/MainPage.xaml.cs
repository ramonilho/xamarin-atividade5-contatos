using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Contatos.API;

namespace XF.Contatos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        //ObservableCollection<GrupoDeItensCollection> lista;
        List<Contato> lista = new List<Contato>();
        public MainPage()
        {
            InitializeComponent();

            lista = PrepararLista();
            lstContatos.ItemsSource = lista;

          
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itemDaLista = (Contato)e.Item;
            await Navigation.PushAsync(new InfoPage(itemDaLista.Telefone, itemDaLista.Nome));
        }

        public List<Contato> PrepararLista()
        {
            var depContato = DependencyService.Get<IContatos>();
            var lstContatos = depContato.GetAllContacts();

            List<Contato> contato = new List<Contato>();

            foreach (var item in lstContatos)
            {
                contato.Add(new Contato { Nome = item.FirstName, Telefone = item.PhoneNumber, Titulo = "OIIIII", CorDeFundo = "Transparent", Etiqueta = item.FirstName.Substring(0, 1) });
            }

            return contato;
        }
    }

    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Titulo { get; set; }
        public string CorDeFundo { get; set; }
        public string Etiqueta { get; set; }
    }
}

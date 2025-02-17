using MauiAppMinhasCompras.Helpers;
using SQLite;


namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        // Instância única do banco de dados SQLite
        static SQLiteDataBaseHelper _db;

        // Propriedade para acessar o banco de dados de forma centralizada
        public static SQLiteDataBaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    // Define o caminho do banco de dados local
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_sqlite_compras.db3");

                    _db = new SQLiteDataBaseHelper(path);

                }
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

           
            // Define a página principal da aplicação
            // Substitui a inicialização padrão (AppShell) por uma NavigationPage contendo ListaProduto
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}

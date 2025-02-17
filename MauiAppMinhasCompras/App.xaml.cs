using MauiAppMinhasCompras.Helpers;
using SQLite;


namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        // Inst�ncia �nica do banco de dados SQLite
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

           
            // Define a p�gina principal da aplica��o
            // Substitui a inicializa��o padr�o (AppShell) por uma NavigationPage contendo ListaProduto
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}

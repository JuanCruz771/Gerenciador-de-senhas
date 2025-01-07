using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GeradordeSenha
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnKeyentrar_Click(object sender, RoutedEventArgs e)
        {
            // Redireciona para a próxima página
            apresentação.Tela_Principal telaPrincipal = new apresentação.Tela_Principal();
            telaPrincipal.Show();
            this.Close(); // Fecha a página atual, se necessário
        }

    }
}

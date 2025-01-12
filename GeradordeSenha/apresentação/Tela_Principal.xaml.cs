using System.Windows;
using System.Windows.Controls;

namespace GeradordeSenha.apresentação
{
    public partial class Tela_Principal : Window
    {
        public Tela_Principal()
        {
            InitializeComponent();
        }

        private void AbrirTelaSenhas(object sender, RoutedEventArgs e)
        {
            ConteudoFrame.Content = new TelaSenhas();
        }

        private void AbrirTelaCadastro(object sender, RoutedEventArgs e)
        {
            ConteudoFrame.Content = new TelaCadastro();
        }

        private void AbrirTelaConfiguracoes(object sender, RoutedEventArgs e)
        {
            ConteudoFrame.Content = new TelaConfiguracoes();
        }
    }
}

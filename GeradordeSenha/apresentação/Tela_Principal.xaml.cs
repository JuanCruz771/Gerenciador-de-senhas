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
using System.Windows.Shapes;
using System.IO;

namespace GeradordeSenha.apresentação
{
    /// <summary>
    /// Lógica interna para Tela_Principal.xaml
    /// </summary>
    public partial class Tela_Principal : Window
    {
        public Tela_Principal()
        {
            InitializeComponent();
            CarregarSenhas();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Verifica se o TabItem ativo é o de "Senhas"
            if (TabControl.SelectedIndex == 0) // Índice 1 corresponde ao Tab de "Senhas"
            {
                // Recarrega as senhas sempre que o Tab de Senhas for ativado
                CarregarSenhas();
            }
        }


        // Método para carregar os dados do arquivo 'dados.txt'
        private void CarregarSenhas()
        {
            try
            {
                string caminhoArquivo = @"..\..\dados.txt";

                if (File.Exists(caminhoArquivo))
                {
                    var linhas = File.ReadAllLines(caminhoArquivo);

                    // Limpar os cartões antigos antes de recarregar os novos
                    wrapPanelSenhas.Children.Clear();

                    if (linhas.Length == 0)
                    {
                        MessageBox.Show("O arquivo está vazio.");
                        return;
                    }

                    string titulo = "", login = "", senha = "", url = "", observacoes = "";

                    foreach (var linha in linhas)
                    {
                        string linhaTrimmed = linha.Trim();

                        if (linhaTrimmed.StartsWith("Título:"))
                            titulo = linhaTrimmed.Substring("Título:".Length).Trim();
                        else if (linhaTrimmed.StartsWith("Login:"))
                            login = linhaTrimmed.Substring("Login:".Length).Trim();
                        else if (linhaTrimmed.StartsWith("Senha:"))
                            senha = linhaTrimmed.Substring("Senha:".Length).Trim();
                        else if (linhaTrimmed.StartsWith("URL:"))
                            url = linhaTrimmed.Substring("URL:".Length).Trim();
                        else if (linhaTrimmed.StartsWith("Observações:"))
                            observacoes = linhaTrimmed.Substring("Observações:".Length).Trim();

                        if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(login) &&
    !string.IsNullOrEmpty(senha) && !string.IsNullOrEmpty(url) &&
    !string.IsNullOrEmpty(observacoes))
                        {
                            var border = new Border
                            {
                                BorderThickness = new Thickness(1),
                                BorderBrush = Brushes.Gray,
                                CornerRadius = new CornerRadius(10),
                                Padding = new Thickness(10),
                                Margin = new Thickness(10),
                                Background = Brushes.White,
                                Width = 250 // Mantém uma largura fixa para consistência
                            };

                            var stackPanel = new StackPanel();

                            // Alinhamento das labels
                            stackPanel.Children.Add(new Label { Content = $"Título: {titulo}", FontWeight = FontWeights.Bold, FontSize = 16, HorizontalAlignment = HorizontalAlignment.Left });
                            stackPanel.Children.Add(new Label { Content = $"Login: {login}", HorizontalAlignment = HorizontalAlignment.Left });
                            stackPanel.Children.Add(new Label { Content = $"Senha: {senha}", HorizontalAlignment = HorizontalAlignment.Left });
                            stackPanel.Children.Add(new Label { Content = $"URL: {url}", Foreground = Brushes.Blue, HorizontalAlignment = HorizontalAlignment.Left });

                            // Utilizando TextBlock para que o texto das observações quebre e ajuste o tamanho do card
                            var textBlockObservacoes = new TextBlock
                            {
                                Text = $"Observações: {observacoes}",
                                TextWrapping = TextWrapping.Wrap, // Quebra de linha automática
                                MaxWidth = 300, // Limita a largura para não expandir demais
                                HorizontalAlignment = HorizontalAlignment.Left // Alinha o texto à esquerda
                            };
                            stackPanel.Children.Add(textBlockObservacoes);

                            border.Child = stackPanel;
                            wrapPanelSenhas.Children.Add(border);

                            // Limpar os dados após adicionar à interface
                            titulo = login = senha = url = observacoes = "";
                        }


                    }
                }
                else
                {
                    MessageBox.Show("Arquivo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar senhas: {ex.Message}");
            }
        }



        // Evento de clique no botão "Salvar Cadastro"
        private void BtnSalvarCadastro_Click(object sender, RoutedEventArgs e)
        {
            string titulo = txtTitulo.Text;
            string login = txtLogin.Text;
            string senha = txtSenha.Password;
            string url = txtURL.Text;
            string observacoes = txtObservacoes.Text;

            string dadosCadastro = $"Título: {titulo};\nLogin: {login};\nSenha: {senha};\nURL: {url};\nObservações: {observacoes};\n\n";

            try
            {
                string caminhoArquivo = @"C:\Users\stell\Desktop\Gerenciador-de-senhas\GeradordeSenha\dados.txt"; // Caminho absoluto para o arquivo

                MessageBox.Show($"Gravando dados no arquivo: {caminhoArquivo}", "Debug", MessageBoxButton.OK, MessageBoxImage.Information);
                MessageBox.Show($"Dados: {dadosCadastro}", "Debug", MessageBoxButton.OK, MessageBoxImage.Information); // Verifique os dados que serão gravados

                File.AppendAllText(caminhoArquivo, dadosCadastro); // Escreve no arquivo
                MessageBox.Show("Cadastro salvo com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cadastro: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChkMostrarSenha_Checked(object sender, RoutedEventArgs e)
        {
            txtSenhaVisivel.Text = txtSenha.Password;
            txtSenha.Visibility = Visibility.Collapsed;
            txtSenhaVisivel.Visibility = Visibility.Visible;
        }

        private void ChkMostrarSenha_Unchecked(object sender, RoutedEventArgs e)
        {
            txtSenha.Password = txtSenhaVisivel.Text;
            txtSenha.Visibility = Visibility.Visible;
            txtSenhaVisivel.Visibility = Visibility.Collapsed;
        }


        // Função para limpar os campos após salvar
        private void LimparCampos()
        {
            txtTitulo.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtURL.Clear();
            txtObservacoes.Clear();
        }
    }
}

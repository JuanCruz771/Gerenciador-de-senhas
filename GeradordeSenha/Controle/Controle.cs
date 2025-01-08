using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradordeSenha.Controle
{
    public class Controle
    {
        string caminhoArquivo = @"..\..\dados.txt";
        List<String> listarSalvar;

        public Controle()
        {
            
        }

        public void Entrar(string KeyUsuario) {

            Validacao validacao = new Validacao(KeyUsuario);

        }

        public void SalvarDados(List<String> listaSalvar) { 
             
        }
    }
}

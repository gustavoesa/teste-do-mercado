using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatos
{
    public class TransicaoAFD : Transicao
    {
        private string estadoAtual;
        private string simbolo;
        private string estradoFuturo;

        public string EstadoFuturo { get { return estradoFuturo; } set { estradoFuturo = value; } }
        public string Simbolo { get { return simbolo; } set { simbolo = value; } }
        public string EstadoAtual { get { return estadoAtual; } set { estadoAtual = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatos
{
    public class TransicaoAFN : Transicao
    {
        List<string> estadosAtuais;
        string simbolo;
        List<string> estadosFuturos;

        public List<string> EstadosFuturos { get { return estadosFuturos; } set { estadosFuturos = value; } }
        public string Simbolo { get { return simbolo; } set { simbolo = value; } }
        public List<string> EstadosAtuais { get { return estadosAtuais; } set { estadosAtuais = value; } }
    }
}

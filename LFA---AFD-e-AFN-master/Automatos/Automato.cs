using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatos
{
    public class Automato
    {

        public string formato;
        public List<string> estados; //= new List<string>();
        public List<string> alfabeto; //= new List<string>();
        public string estadoInicial;
        public List<string> estadosFinais; //= new List<string>();
        public List<Transicao> funcoesTransicao;// = new List<string>();
    }
}

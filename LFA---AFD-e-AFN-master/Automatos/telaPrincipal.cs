using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Automatos
{
    public partial class telaPrincipal : Form
    {
        public telaPrincipal()
        {
            InitializeComponent();
        }


        Automato automato;

        private bool ValidaAutomato(string caminho)
        {
            try
            {               
                string[] arquivoTexto;
                try
                {     
                    arquivoTexto = File.ReadAllLines(caminho);
                    rTxtAutomatoCarregado.Text = "";                    
                    foreach (string a in arquivoTexto)
                    {
                        rTxtAutomatoCarregado.Text += a + Environment.NewLine;
                    }
                }
                catch
                {
                    throw new Exception("Impossível ler arquivo Texto!");
                }

                if (arquivoTexto[0] != "AFD" && arquivoTexto[0] != "AFN")
                {
                    throw new Exception("Tipo de automato não encontrado!");
                }
                automato.formato = arquivoTexto[0];
                
                string[] todosEstados = arquivoTexto[1].Split(',');
                for (int i = 0; i < todosEstados.Length; i++)
                {
                    todosEstados[i] = todosEstados[i].Trim();
                }
                automato.estados = new List<string>();
                foreach (string estado in todosEstados)
                {
                    automato.estados.Add(estado);
                }
                
                string[] alfabeto = arquivoTexto[2].Split(',');
                for (int i = 0; i < alfabeto.Length; i++)
                {
                    alfabeto[i] = alfabeto[i].Trim();
                }
                automato.alfabeto = new List<string>();
                foreach (string letra in alfabeto)
                {
                    automato.alfabeto.Add(letra);
                }
                
                string estadoInicial = arquivoTexto[3].Trim();
                if (estadoInicial.Split(',').Length > 1 || !automato.estados.Contains(estadoInicial))
                {
                    throw new Exception("Estado inicial não encontrado!");
                }
                else
                {
                    automato.estadoInicial = estadoInicial;
                }
                
                string[] estadosFinais = arquivoTexto[4].Split(',');
                automato.estadosFinais = new List<string>();
                for (int i = 0; i < estadosFinais.Length; i++)
                {
                    estadosFinais[i] = estadosFinais[i].Trim();
                    if (!automato.estados.Contains(estadosFinais[i]))
                    {
                        throw new Exception("Não foram encontrados Estados Finais!");
                    }
                    else
                    {
                        automato.estadosFinais.Add(estadosFinais[i]);
                    }
                }
                
                if (automato.formato == "AFD")
                {
                    btnConverteAFD.Visible = false;
                    rTxtAutomatoConvertido.Visible = false;
                    lblAutomatoConvertido.Visible = false;
                    automato.funcoesTransicao = new List<Transicao>();
                    string aux;
                    for (int i = 5; i < arquivoTexto.Length; i++)
                    {
                        TransicaoAFD fT = new TransicaoAFD();
                        if (!String.IsNullOrEmpty(arquivoTexto[i]))
                        {
                            aux = arquivoTexto[i].Replace("(", "");
                            aux = aux.Replace(")", "");
                            fT.EstadoAtual = aux.Substring(0, aux.IndexOf(','));
                            aux = aux.Substring(aux.IndexOf(',') + 1);
                            fT.Simbolo = aux.Substring(0, aux.IndexOf(','));
                            aux = aux.Substring(aux.IndexOf(',') + 1);
                            fT.EstadoFuturo = aux;
                            automato.funcoesTransicao.Add(fT);

                            if (!automato.estados.Contains(fT.EstadoAtual) ||
                                !automato.estados.Contains(fT.EstadoFuturo) ||
                                !automato.alfabeto.Contains(fT.Simbolo))
                            {
                                throw new Exception("Existe alguma função de transição incorreta!");
                            }
                        }
                    }
                }
                else
                {
                    automato.funcoesTransicao = new List<Transicao>();
                    string aux, eA, simb, eF;
                    for (int i = 5; i < arquivoTexto.Length; i++)
                    {
                        if (!String.IsNullOrEmpty(arquivoTexto[i]))
                        {
                            aux = arquivoTexto[i].Replace("(", "");
                            aux = aux.Replace(")", "");
                            eA = aux.Substring(0, aux.IndexOf(','));

                            aux = aux.Substring(aux.IndexOf(',') + 1);
                            simb = aux.Substring(0, aux.IndexOf(','));

                            aux = aux.Substring(aux.IndexOf(',') + 1);
                            eF = aux;
                            
                            if (!automato.estados.Contains(eA) ||
                                !automato.estados.Contains(eF) ||
                                !automato.alfabeto.Contains(simb))
                            {
                                throw new Exception("Existe alguma função de transição incorreta!");
                            }


                            bool existe = false;
                            foreach (TransicaoAFN fT in automato.funcoesTransicao)
                            {
                                if (fT.EstadosAtuais.Contains(eA) && fT.Simbolo == simb)
                                {
                                    fT.EstadosFuturos.Add(eF);
                                    existe = true;
                                }
                            }
                            if (!existe)
                            {
                                TransicaoAFN fTAFN = new TransicaoAFN();
                                fTAFN.EstadosAtuais = new List<string>();
                                fTAFN.EstadosFuturos = new List<string>();
                                fTAFN.EstadosAtuais.Add(eA);
                                fTAFN.Simbolo = simb;
                                fTAFN.EstadosFuturos.Add(eF);
                                automato.funcoesTransicao.Add(fTAFN);
                            }

                        }
                    }
                }
                return true;
            }
            catch(Exception erro)
            {
                lblMostraErro.Text = erro.Message;
                return false;
            }
        }

        private void btnCarregaAutomato_Click(object sender, EventArgs e)
        {
            txtCaminhoAutomato.Clear();
            txtCaminhoPalavras.Clear();
            openFileDialog1.Filter = null;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCaminhoAutomato.Text = openFileDialog1.FileName;
                if(ValidaAutomato(openFileDialog1.FileName))
                {
                    btnCarregaPalavras.Enabled = true;
                    lblMostraErro.Visible = false;
                }
                else
                {
                    btnCarregaPalavras.Enabled = true;
                    lblMostraErro.Visible = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            automato = new Automato();
        }

        private void btnCarregaPalavras_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Office Files|*.IN";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] palavras = File.ReadAllLines(openFileDialog1.FileName);
                txtCaminhoPalavras.Text = openFileDialog1.FileName;
                if(automato.formato == "AFD")
                {
                    VerificaPalavrasAFD(palavras, openFileDialog1.FileName);
                }
                else
                {
                    VerificaPalavrasAFN(palavras, openFileDialog1.FileName);
                }
            }
            if(automato.formato == "AFN") btnConverteAFD.Visible = true;
        }

        private void VerificaPalavrasAFD(string[] palavras, string caminho)
        {            
            try
            {
                caminho = caminho.Substring(0, caminho.LastIndexOf(".")) + ".OUT";
                File.Delete(caminho);
            }
            catch
            {
                MessageBox.Show("Extensão de Arquivo não é Aceita!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string EAtual;
            bool teste = false;
            foreach(string palavra in palavras)
            {
                EAtual = automato.estadoInicial;                
                for (int i = 0; i < palavra.Length; i++)
                {
                    teste = false;
                    foreach(TransicaoAFD a in automato.funcoesTransicao)
                    {
                        if(a.EstadoAtual == EAtual && a.Simbolo == palavra[i].ToString())
                        {
                            EAtual = a.EstadoFuturo;
                            teste = true;
                            break;
                        }
                    }
                    if (!teste) break;
                }
                if(automato.estadosFinais.Contains(EAtual) && teste == true)
                {
                    File.AppendAllText(caminho, palavra + " ACEITO" + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(caminho, palavra + " REJEITADO" + Environment.NewLine);
                }
            }
            try
            {
                System.Diagnostics.Process.Start(caminho);
            }
            catch
            {
                MessageBox.Show("Sem permissão para abrir o arquivo");
            }
        }
        
        private void VerificaPalavrasAFN(string[] palavras, string caminho)
        {            
            try
            {
                caminho = caminho.Substring(0, caminho.LastIndexOf(".IN")) + ".OUT";
                File.Delete(caminho);
            }
            catch
            {
                MessageBox.Show("Extensão de Arquivo não é Aceita!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
            
            foreach (string palavra in palavras)
            {
                List<string> EAtuais = new List<string>();
                List<string> Efuturos = new List<string>();
                EAtuais.Clear();
                EAtuais.Add(automato.estadoInicial);
             
                for (int i = 0; i < palavra.Length; i++)
                {
                    foreach(string estado in EAtuais)
                    {
                        foreach(TransicaoAFN a in automato.funcoesTransicao)
                        {
                            if(a.EstadosAtuais.Contains(estado) && a.Simbolo == palavra[i].ToString())
                            {
                                foreach(string eFt in a.EstadosFuturos) Efuturos.Add(eFt);
                            }
                        }
                    }
                    EAtuais.Clear();
                    foreach (string es in Efuturos) EAtuais.Add(es);
                    Efuturos.Clear();
                }
                bool aceito = false;
                for (int j = 0; j < EAtuais.Count; j++)
                {
                    if (automato.estadosFinais.Contains(EAtuais[j]))
                    {
                        aceito = true;
                    }
                }
                if (aceito)
                {
                    File.AppendAllText(caminho, palavra + " ACEITO" + Environment.NewLine);
                }
                else
                {
                    File.AppendAllText(caminho, palavra + " REJEITADO" + Environment.NewLine);
                }
            }
            try
            {
                System.Diagnostics.Process.Start(caminho);
            }
            catch
            {
                MessageBox.Show("Sem permissão para abrir o arquivo");
            }
        }

        private void ConverteAutomato()
        {
            bool adicionou = false;
            bool mudou = false;

            do
            {                
                List<Transicao> listaFuncoes = new List<Transicao>();
                foreach (TransicaoAFN fTAux in automato.funcoesTransicao)
                {
                    TransicaoAFN novaFT = new TransicaoAFN();
                    novaFT.EstadosAtuais = new List<string>();
                    novaFT.EstadosFuturos = new List<string>();

                    novaFT.EstadosAtuais.Add(fTAux.EstadosAtuais[0]);
                    novaFT.Simbolo = fTAux.Simbolo;
                    foreach (string s in fTAux.EstadosFuturos) novaFT.EstadosFuturos.Add(s);
                    listaFuncoes.Add(fTAux);
                }
            
            
                do
                {                    
                    foreach (TransicaoAFN fTAux in listaFuncoes)
                    {
                        if (!existeEstadoAtual(fTAux.EstadosFuturos, automato.funcoesTransicao))
                        {
                            if (CriaNovaFuncao(fTAux.EstadosFuturos, automato.funcoesTransicao))
                            {
                                adicionou = true;
                            }
                        }
                        else adicionou = false;
                    }

                } while (adicionou);
                
                if (listaFuncoes.Count != automato.funcoesTransicao.Count) mudou = true;
                else mudou = false;
                
            } while (mudou);
        }

        private bool CriaNovaFuncao(List<string> Estados, List<Transicao> FuncoesTransicao)
        {                                    
            if (Estados.Count > 1)
            {                
                foreach (string caracter in automato.alfabeto)
                {
                    TransicaoAFN nova = new TransicaoAFN();
                    List<string> EstadosAtuais = new List<string>();
                    List<string> EstadosFuturos = new List<string>();
                    foreach (string estado in Estados)
                    {
                        EstadosAtuais.Add(estado);

                        foreach (TransicaoAFN fT in FuncoesTransicao)
                        {
                            if (fT.EstadosAtuais.Count == 1 && fT.Simbolo == caracter && 
                                estado == fT.EstadosAtuais[0])
                            {
                                foreach (string e in fT.EstadosFuturos)
                                {
                                    if(!EstadosFuturos.Contains(e)) EstadosFuturos.Add(e);
                                }
                            }
                        }

                    }
                    nova.EstadosAtuais = EstadosAtuais;
                    nova.Simbolo = caracter;
                    nova.EstadosFuturos = EstadosFuturos;
                    FuncoesTransicao.Add(nova);
                }
                return true;
            }
            return false;
        }

        private bool existeEstadoAtual(List<string> EstadosFuturos, List<Transicao> FT)
        {
            foreach(TransicaoAFN f in FT)
            {
                if (f.EstadosAtuais.Count == EstadosFuturos.Count)
                {
                    bool teste = true;                    
                    foreach (string s in f.EstadosAtuais)
                    {
                        if (!EstadosFuturos.Contains(s)) teste = false;
                    }
                    foreach(string s in EstadosFuturos)
                    {
                        if (!f.EstadosAtuais.Contains(s)) teste = false;
                    }
                   
                    if (teste) return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCaminhoAutomato.Clear();
            txtCaminhoPalavras.Clear();
            btnCarregaPalavras.Enabled = false;
            btnConverteAFD.Visible = false;


            lblAutomatoConvertido.Visible = true;
            rTxtAutomatoConvertido.Visible = true;
            ConverteAutomato();
            LimpaFuncoes();
            SalvaAutomatoConvertido();
        }

        private void LimpaFuncoes()
        {  
            bool mudou;

            do
            {
                mudou = false;
                List<Transicao> listaFuncoes = new List<Transicao>();
                foreach (TransicaoAFN fTAux in automato.funcoesTransicao)
                {
                    TransicaoAFN novaFT = new TransicaoAFN();
                    novaFT.EstadosAtuais = new List<string>();
                    novaFT.EstadosFuturos = new List<string>();

                    novaFT.EstadosAtuais.Add(fTAux.EstadosAtuais[0]);
                    novaFT.Simbolo = fTAux.Simbolo;
                    foreach (string s in fTAux.EstadosFuturos) novaFT.EstadosFuturos.Add(s);
                    listaFuncoes.Add(fTAux);
                }

                #region Cria lista de estados futuros

                List<string> EstadosFuturos = new List<string>();
                foreach (TransicaoAFN fT in automato.funcoesTransicao)
                {
                    string aux = "";
                    if (fT.EstadosFuturos.Count > 1)
                    {
                        aux += "{";
                        foreach (string estado in fT.EstadosFuturos)
                        {
                            aux += estado;
                        }
                        aux += "}";

                        if (!EstadosFuturos.Contains(aux))
                        {
                            EstadosFuturos.Add(aux);

                        }
                    }
                    else
                    {
                        if (!EstadosFuturos.Contains(fT.EstadosFuturos[0]))
                        {
                            EstadosFuturos.Add(fT.EstadosFuturos[0]);
                        }
                    }
                }
                #endregion

                foreach (TransicaoAFN fT in listaFuncoes)
                {
                    string aux = "";
                    if (fT.EstadosAtuais.Count > 1)
                    {
                        aux += "{";
                        foreach (string estado in fT.EstadosAtuais)
                        {
                            aux += estado;
                        }
                        aux += "}";
                    }
                    else
                    {
                        aux = fT.EstadosAtuais[0];
                    }

                    if (!EstadosFuturos.Contains(aux) && aux != automato.estadoInicial)
                    {
                        automato.funcoesTransicao.Remove(fT);
                        mudou = true;
                    }
                }
            } while (mudou);            
        }

        private void SalvaAutomatoConvertido()
        {
            List<string> listaAux = new List<string>();
            string arquivo = "AFD" + Environment.NewLine;
            bool criou = false;
            
            foreach(TransicaoAFN fT in automato.funcoesTransicao)
            {
                string aux = "";
                if(fT.EstadosAtuais.Count > 1)
                {
                    fT.EstadosAtuais.Sort();
                    aux += "{";
                    foreach(string estado in fT.EstadosAtuais)
                    {                        
                        aux += estado;
                    }
                    aux += "}";

                    if (!listaAux.Contains(aux))
                    {
                        listaAux.Add(aux);
                        arquivo += aux;
                        criou = true;
                    }
                    else criou = false;
                }
                else
                {
                    if (!listaAux.Contains(fT.EstadosAtuais[0]))
                    {
                        listaAux.Add(fT.EstadosAtuais[0]);
                        arquivo += fT.EstadosAtuais[0];
                        criou = true;
                    }
                    else criou = false;
                }
                if(criou) arquivo += ",";
            }
            arquivo = arquivo.Substring(0, arquivo.Length - 1);
            arquivo += Environment.NewLine;

            foreach(string letra in automato.alfabeto)
            {
                arquivo += letra + ",";
            }
            arquivo = arquivo.Substring(0, arquivo.Length - 1);
            
            arquivo += Environment.NewLine + automato.estadoInicial + Environment.NewLine;
            
            foreach(string s in listaAux)
            {
                if(s.IndexOf(automato.estadosFinais[0]) != -1)
                {
                    arquivo += s + ",";
                }
            }
            arquivo = arquivo.Substring(0, arquivo.Length - 1);
            arquivo += Environment.NewLine;
       
            foreach(TransicaoAFN fT in automato.funcoesTransicao)
            {
                arquivo += "(";
                if(fT.EstadosAtuais.Count > 1)
                {
                    fT.EstadosAtuais.Sort();
                    arquivo += "{";
                    foreach(string estado in fT.EstadosAtuais)
                    {
                        arquivo += estado;
                    }
                    arquivo += "}";
                }
                else
                {
                    arquivo += fT.EstadosAtuais[0];
                }
                arquivo += "," + fT.Simbolo + ",";
                
                if(fT.EstadosFuturos.Count > 1)
                {
                    fT.EstadosFuturos.Sort();
                    arquivo += "{";
                    foreach(string estado in fT.EstadosFuturos)
                    {
                        arquivo += estado;
                    }
                    arquivo += "}";
                }
                else
                {
                    arquivo += fT.EstadosFuturos[0];
                }
                arquivo += ")" + Environment.NewLine;
            }
            
            try
            {
                string caminhoArquivoTexto = openFileDialog1.FileName;
                caminhoArquivoTexto = caminhoArquivoTexto.Substring(0, caminhoArquivoTexto.IndexOf("."));
                caminhoArquivoTexto += "CONVERTIDO.txt";
                File.Delete(caminhoArquivoTexto);
                File.AppendAllText(caminhoArquivoTexto, arquivo);
                MessageBox.Show("Automato convertido foi salvo no diretório: " + caminhoArquivoTexto);
            }
            catch
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivoTexto = saveFileDialog1.FileName;
                    File.Delete(caminhoArquivoTexto);
                    File.AppendAllText(caminhoArquivoTexto, arquivo);
                }
                else
                {
                    MessageBox.Show("Automato convertido não foi salvo!");
                }
            }

            rTxtAutomatoConvertido.Text = arquivo;
        }

        private void lblErro_Click(object sender, EventArgs e)
        {

        }
    }        
}

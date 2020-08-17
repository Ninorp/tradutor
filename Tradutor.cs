using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tradutor
{
    class Tradutor
    {
        private Dictionary<string, string> dicionarioTraducoes = new Dictionary<string, string>();
        internal bool EstaVazio()
        {
            return dicionarioTraducoes.Count == 0;
        }

        internal void AdicionaTraducao(string palavra, string traducao)
        {
            if (dicionarioTraducoes.ContainsKey(palavra))
            {
                traducao = $"{Traduzir(palavra)}, {traducao}";
                dicionarioTraducoes.Remove(palavra);
            }                
            dicionarioTraducoes.Add(palavra, traducao);
        }

        internal string Traduzir(string palavra)
        {
            string traducao;
            if (dicionarioTraducoes.TryGetValue(palavra, out traducao) == false)
            {
                throw new PalavraNaoExistenteException();
            }
            return traducao;
        }

        internal string TraduzirFrase(string frase)
        {
            string[] palavras = frase.Split(' ');
            string fraseTraduzida = "";
            foreach (var palavra in palavras)
            {
                string traducao = PrimeiraTraducao(palavra); /* FEITO NA REFATORAÇÃO */
                fraseTraduzida += $" {traducao}";
            }

            return fraseTraduzida.Trim();
        }

        private string PrimeiraTraducao(string palavra)
        {
            string traducao = Traduzir(palavra);
            if (traducao.Contains(','))
                traducao = traducao.Substring(0, traducao.IndexOf(','));
            return traducao;
        }
    }
}

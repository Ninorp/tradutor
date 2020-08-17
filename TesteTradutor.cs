using System;
using Xunit;

namespace Tradutor
{
    public class TesteTradutor
    {
        private Tradutor tradutor;
        public TesteTradutor()
        {
            tradutor = new Tradutor();
        }

        [Fact]
        public void TradutorSemPalavras()
        {            
            Assert.True(tradutor.EstaVazio());
        }

        [Fact]
        public void UmaTraducao()
        {
            tradutor.AdicionaTraducao("oi", "hi");

            Assert.False(tradutor.EstaVazio());
            Assert.Equal("hi", tradutor.Traduzir("oi"));
        }

        [Fact]
        public void DuasTraducoes()
        {
            tradutor.AdicionaTraducao("bom", "good");
            tradutor.AdicionaTraducao("mau", "bad");
           
            Assert.Equal("good", tradutor.Traduzir("bom"));
            Assert.Equal("bad", tradutor.Traduzir("mau"));
        }

        [Fact]
        public void DuasTraducoesMesmaPalavra()
        {
            tradutor.AdicionaTraducao("bom", "good");
            tradutor.AdicionaTraducao("bom", "nice");

            Assert.Equal("good, nice", tradutor.Traduzir("bom"));            
        }

        [Fact]
        public void TentaTraduzirUmaPalavraQueNaoExiste()
        {
            Assert.Throws<PalavraNaoExistenteException>(() => tradutor.Traduzir("ol�"));
        }

        [Fact]
        public void TraduzirFrase()
        {
            tradutor.AdicionaTraducao("guerra", "war");
            tradutor.AdicionaTraducao("�", "is");
            tradutor.AdicionaTraducao("ruim", "bad");            

            Assert.Equal("war is bad", tradutor.TraduzirFrase("guerra � ruim"));
        }

        [Fact]
        public void TraduzirFraseComDuasTraducoesMesmaPalavra()
        {
            tradutor.AdicionaTraducao("paz", "peace");
            tradutor.AdicionaTraducao("�", "is");
            tradutor.AdicionaTraducao("bom", "good");
            tradutor.AdicionaTraducao("bom", "nice");

            Assert.Equal("peace is good", tradutor.TraduzirFrase("paz � bom"));
        }
    }
}

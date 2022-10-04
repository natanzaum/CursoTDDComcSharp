using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double) 50.0,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double) 985.32
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);

            //Refatorando - aula 7
            //Assert.Equal(nome, curso.Nome);
            //Assert.Equal(cargaHoraria, curso.CargaHoraria);
            //Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            //Assert.Equal(valor, curso.Valor);   
        }

        [Theory] //Permite passar vários parametros para o teste
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)50.0,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)985.32
            };

            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Nome inválido");
        }

        [Theory] //Permite passar vários parametros para o teste
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-300)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)50.0,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)985.32
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cargaHorariaInvalida, cursoEsperado.PublicoAlvo, cursoEsperado.Valor)).ComMensagem("Carga horaria inválida");
        }

        [Theory] //Permite passar vários parametros para o teste
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-300)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalido)
        {
            var cursoEsperado = new
            {
                Nome = "Informática básica",
                CargaHoraria = (double)50.0,
                PublicoAlvo = PublicoAlvo.Estudante,
                Valor = (double)985.32
            };

            Assert.Throws<ArgumentException>(() => new Curso(cursoEsperado.Nome, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, valorInvalido)).ComMensagem("Valor inválido");
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitario,
        Empregado,
        Empregador
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga horaria inválida");

            if (valor < 1)
                throw new ArgumentException("Valor inválido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;  
        }

        public string Nome { get; set; }
        public double CargaHoraria { get; set; }
        public PublicoAlvo PublicoAlvo { get; set; }
        public double Valor { get; set; }



}
}

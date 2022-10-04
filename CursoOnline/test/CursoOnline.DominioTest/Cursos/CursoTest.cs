using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using ExpectedObjects;
using Microsoft.VisualStudio.TestPlatform.Common.Telemetry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest : IDisposable
    {
        ITestOutputHelper _output;
        private string _nome;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valor;
        private string _descricao;

        public CursoTest(ITestOutputHelper output) //Aula do modulo 3 -> Construtor é sempre executado pra cada teste
        {
            _output = output;
            _output.WriteLine("Construtor iniciado!!!");

            var faker = new Faker();

            _nome = faker.Random.Word(); 
            _cargaHoraria = faker.Random.Double(20, 100);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = faker.Random.Double(200, 9999);
            _descricao = faker.Lorem.Paragraph();
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

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
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(nomeInvalido).Build()).ComMensagem("Nome inválido");
        }

        [Theory] //Permite passar vários parametros para o teste
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-300)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build()).ComMensagem("Carga horaria inválida");
        }

        [Theory] //Permite passar vários parametros para o teste
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-300)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valorInvalido).Build()).ComMensagem("Valor inválido");
            //Assert.Throws<ArgumentException>(() => new Curso(_nome, _cargaHoraria, _publicoAlvo, valorInvalido)).ComMensagem("Valor inválido"); => Antes de implementar o builder
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose iniciado!!!");
        }
    }
}

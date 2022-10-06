using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private CursoDTO _cursoDto;
        private Mock<ICursoRepository> _cursoRepositorioMock;
        private ArmazenadorDeCurso _armazenadorDeCurso;
        public ArmazenadorDeCursoTest()
        {
            var fake = new Faker();

            _cursoDto = new CursoDTO
            {
                Nome = fake.Random.Words(),
                Descricao = fake.Lorem.Paragraph(),
                CargaHoraria = fake.Random.Double(50, 250),
                PublicoAlvo = "Estudante",
                //PublicoAlco = PublicoAlvo.Empregador,
                Valor = fake.Random.Double(99, 500)
            };

            _cursoRepositorioMock = new Mock<ICursoRepository>(); //inicia o mock
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object); //Passa o objeto final do mock para o mock
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto); // Chama o repoditorio

            _cursoRepositorioMock.Verify(x => x.Adicionar(It.IsAny<Curso>())); // verifica se o metodo Adicionar foi chamado
            _cursoRepositorioMock.Verify(x => x.Adicionar(
                It.Is<Curso>(c => c.Nome == _cursoDto.Nome &&
                             c.Descricao == _cursoDto.Descricao)),
                Times.AtLeast(1) //Verifica se o metodo foi chamado pelo menos 1 vez
            ); // verifica se o metodo Adicionar foi chamado e se o nome do curso e a descrição estão corretos
        }

        [Fact]
        public void NaoDeveTerPublicoAlvoInvalido()
        {
            string publicoAlvoInvalido = "Médico";
            _cursoDto.PublicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto)).ComMensagem("Publico alvo inválido");
        }

        [Fact]
        public void NaoDeveAdicionarCursoDuplicado()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDto.Nome).Build();

            _cursoRepositorioMock.Setup(r => r.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto)).ComMensagem("Curso duplicado");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.Cursos
{
    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepository _cursoRepository;

        public ArmazenadorDeCurso(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository; //Injeta o repositorio na classe de serviço
        }

        public void Armazenar(CursoDTO cursoDto)
        {
            var cursoJaSalvo = _cursoRepository.ObterPeloNome(cursoDto.Nome);

            if (cursoJaSalvo != null)
            {
                throw new ArgumentException("Curso duplicado");
            }

            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
            {
                throw new ArgumentException("Publico alvo inválido");
            }

            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.Valor);

            _cursoRepository.Adicionar(curso); //Salva o curso
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dominio.Cursos
{
    public interface ICursoRepository
    {
        void Adicionar(Curso cursoDTO);
        Curso ObterPeloNome(string nome);
    }
}

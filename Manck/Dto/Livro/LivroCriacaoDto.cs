using Manck.Dto.Livro.Vinculo;
using Manck.Models;

namespace Manck.Dto.Livro
{
	public class LivroCriacaoDto
	{
		public string Titulo { get; set; }
		public AutorVinculoDto Autor { get; set; }
	}
}

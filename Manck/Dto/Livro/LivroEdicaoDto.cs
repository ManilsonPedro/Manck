﻿using Manck.Dto.Livro.Vinculo;
using Manck.Models;

namespace Manck.Dto.Livro
{
	public class LivroEdicaoDto
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public AutorVinculoDto Autor { get; set; }
	}
}

using Manck.Data;
using Manck.Dto.Autor;
using Manck.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Manck.Services.Autor
{
	public class AutorService : IAutorInterface
	{
		private readonly ManckDbContext _context;
		public AutorService(ManckDbContext context) 
		{ 
		
			_context = context;	
		}

		public async Task<ResponseModels<AutorModels>> BuscarAutorPorId(int IdAutor)
		{
			ResponseModels<AutorModels> resposta = new ResponseModels<AutorModels>();
			try
			{

				var autor = await _context.Autor.FirstOrDefaultAsync( autorBanco=>autorBanco.Id==IdAutor);

				if (autor == null)
				{
					resposta.Mensagem = "Nenhum Registro Encontrado!";
					return resposta;
				}
				resposta.Dados = autor;
				resposta.Mensagem = "Autor Localizado";
				return resposta;
				
			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}

		public async Task<ResponseModels<AutorModels>> BuscarAutorPorIdLivro(int IdLivro)
		{
			ResponseModels<AutorModels> resposta = new ResponseModels<AutorModels>();
			try
			{
				var livro = await _context.Livro.Include(a=>a.Autor).FirstOrDefaultAsync(livroBanco=>livroBanco.Id==IdLivro);
				if(livro == null)
				{
					resposta.Mensagem = "Nenhum Registro Encontrado!";
					return resposta;
				}

				resposta.Dados = livro.Autor;
				resposta.Mensagem = "Autor Localizado com Sucesso!";
				return resposta;
			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}

		public async Task<ResponseModels<List<AutorModels>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
		{
			ResponseModels<List<AutorModels>> resposta= new ResponseModels<List<AutorModels>>();
			try
			{
				var autor = new AutorModels()
				{
					Name = autorCriacaoDto.Nome,
					SobreNome=autorCriacaoDto.SobreNome
				};

				_context.Add(autor);
				await _context.SaveChangesAsync();

				resposta.Dados= await _context.Autor.ToListAsync();
				resposta.Mensagem = "Autor criado com Sucesso!";

				return resposta;



			}
			catch (Exception ex)
			{

				resposta.Mensagem=ex.Message;
				resposta.Status = false;
				return resposta;
			}
		}

		public async Task<ResponseModels<List<AutorModels>>> EditarAutor(AutorEditarDto autorEdicaoDto)
		{
			ResponseModels<List<AutorModels>> resposta = new ResponseModels<List<AutorModels>>();
			try
			{
				var autor= await _context.Autor.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);

				if( autor == null)
				{
					resposta.Mensagem = "Nenhum Autor Localizado!";
					return resposta;
				}

				autor.Name = autorEdicaoDto.Name;
				autor.SobreNome=autorEdicaoDto.SobreNome;

				_context.Update(autor);
				await _context.SaveChangesAsync();
				
				resposta.Dados = await _context.Autor.ToListAsync();
				resposta.Mensagem = "Autor Editado com Sucesso!";

				return resposta;


			}
			catch (Exception ex)
			{

				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;
			}
		}

		public async Task<ResponseModels<List<AutorModels>>> EliminarAutor(int idAutor)
		{
			ResponseModels < List < AutorModels >>resposta = new ResponseModels<List < AutorModels>>();
			try
			{
				var autor= await _context.Autor.FirstOrDefaultAsync(autorBanco=>autorBanco.Id==idAutor);

				if (autor == null)
				{
					resposta.Mensagem = "Nenhum Autor Localizado!";
					return resposta;
				}
				_context.Remove(autor);
				await _context.SaveChangesAsync();
				
				resposta.Dados= await _context.Autor.ToListAsync();
				return resposta;
				resposta.Mensagem = "Autor Removido com Sucesso!";


			}
			catch (Exception ex)
			{

				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;
			}
		}

		public async Task<ResponseModels<List<AutorModels>>> ListarAutores()
		{
			ResponseModels<List<AutorModels>> resposta= new ResponseModels<List<AutorModels>>();
			try
			{

				var autores= await _context.Autor.ToListAsync();
				resposta.Dados = autores;
				resposta.Mensagem = "Todos os autores foram Buscados";
				return resposta;	

			}
			catch (Exception ex)
			{
				resposta.Mensagem=ex.Message;
				resposta.Status=false;
				return resposta;
				
			}
		}
	}
}

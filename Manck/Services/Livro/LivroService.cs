using Manck.Dto.Livro;
using Manck.Models;
using Manck.Data;
using System;
using Microsoft.EntityFrameworkCore;
using Manck.Dto.Autor;

namespace Manck.Services.Livro
{
	public class LivroService : ILivroInterface
	{
		private readonly ManckDbContext _context;

		public LivroService(ManckDbContext context)
		{
			this._context = context;
		}
		public async Task<ResponseModels<LivroModels>> BuscarLivroPorId(int IdLivro)
		{
			ResponseModels<LivroModels> resposta = new ResponseModels<LivroModels>();
			try
			{

				var livro = await _context.Livro.Include(a=>a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);

				if (livro == null)
				{
					resposta.Mensagem = "Nenhum Registro Encontrado!";
					return resposta;
				}
				resposta.Dados = livro;
				resposta.Mensagem = "Livro Localizado com sucesso";
				return resposta;

			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}

		public async Task<ResponseModels<List<LivroModels>>> BuscarLivroPorIdAutor(int IdLivroAutor)
		{
			ResponseModels<List<LivroModels>> resposta = new ResponseModels<List<LivroModels>>();
			try
			{
				var livro = await _context.Livro.Include(a => a.Autor).Where(livroBanco=> livroBanco.Autor.Id==IdLivroAutor).ToListAsync();
				
				if(livro==null)
				{
					resposta.Mensagem = "Nenhum Registro Encontrado!";
					return resposta;
				}

				resposta.Dados = livro;
				resposta.Mensagem = "Livro Localizado com Sucesso!";
				return resposta;
			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}

		public async Task<ResponseModels<List<LivroModels>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
		{
			ResponseModels<List<LivroModels>> resposta = new ResponseModels<List<LivroModels>>();
			try
			{
				var autor = await _context.Autor.FirstOrDefaultAsync(autorBanco=>autorBanco.Id== livroCriacaoDto.Autor.Id);
				if (autor == null) 
				{
					resposta.Mensagem = "Nenhum Registro de autor Localizado!";
					return resposta;
				
				}

				var livro = new LivroModels()
				{
					Titulo = livroCriacaoDto.Titulo,
					Autor = autor
				};
				_context.Add(livro);
				await _context.SaveChangesAsync();


				resposta.Dados=await _context.Livro.Include(a=>a.Autor).ToListAsync();
				return resposta;

			}
			catch (Exception ex)
			{

				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;
			}
		}

		public async Task<ResponseModels<List<LivroModels>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
		{

			ResponseModels<List<LivroModels>> resposta = new ResponseModels<List<LivroModels>>();
			try
			{
				var livro= await _context.Livro.Include(a=>a.Autor).FirstOrDefaultAsync(livroBanco=>livroBanco.Id==livroEdicaoDto.Id);

				var autor= await _context.Autor.FirstOrDefaultAsync(autorBanco=>autorBanco.Id==livroEdicaoDto.Autor.Id);

				if (autor == null)
				{
					resposta.Mensagem = "Nenhum Registro de autor Localizado!";
					return resposta;

				}

				if (livro == null)
				{
					resposta.Mensagem = "Nenhum Registro de livro Localizado!";
					return resposta;

				}

				livro.Titulo = livroEdicaoDto.Titulo;
				livro.Autor= autor;

				_context.Update(livro);	
				await _context.SaveChangesAsync();

				resposta.Dados= await _context.Livro.ToListAsync();
				return resposta;

			}
			catch (Exception ex)
			{

				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;
			}
		}

		public async Task<ResponseModels<List<LivroModels>>> EliminarLivro(int idLivro)
		{
			ResponseModels<List<LivroModels>> resposta = new ResponseModels<List<LivroModels>>();
			try
			{
				var livros = await _context.Livro.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

				if (livros == null)
				{
					resposta.Mensagem = "Nenhum livro Localizado!";
					return resposta;
				}
				_context.Remove(livros);
				await _context.SaveChangesAsync();

				resposta.Dados = await _context.Livro.ToListAsync();
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

		public async Task<ResponseModels<List<LivroModels>>> ListarLivros()
		{
			ResponseModels<List<LivroModels>> resposta = new ResponseModels<List<LivroModels>>();
			try
			{

				var livros = await _context.Livro.Include(a=>a.Autor).ToListAsync();
				resposta.Dados = livros;
				resposta.Mensagem = "Todos os livros foram Buscados com sucesso";
				return resposta;

			}
			catch (Exception ex)
			{
				resposta.Mensagem = ex.Message;
				resposta.Status = false;
				return resposta;

			}
		}
	}
}

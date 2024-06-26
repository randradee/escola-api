﻿using EscolaApi.Data.Contexts;
using EscolaApi.Data.Repositories;
using EscolaApi.Domain.Entities;
using EscolaApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EscolaApi.Repositories
{
    public class AlunoRepository(AppDbContext context) : BaseRepository(context), IAlunoRepository
    {
        public async Task CreateAluno(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
        }

        public async Task<Aluno?> GetAlunoById(Guid id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<Aluno?> GetAlunoByUniqueness(string nome, string sobrenome, string email)
        {
            return await _context.Alunos.FirstOrDefaultAsync(x => x.Nome == nome && x.Sobrenome == sobrenome && x.Email == email);
        }
    }
}

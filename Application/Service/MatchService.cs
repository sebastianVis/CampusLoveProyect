using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusLove.Domain.Entities;
using CampusLove.Domain.Ports;

namespace CampusLove.Application.Service
{
    public class MatchService
    {
        private readonly IMatchRepository _repo;
        public MatchService(IMatchRepository repo)
        {
            _repo = repo;
        }
        public void CreateMatch(Usuario usuarioUno, Usuario usuarioDos)
        {
            _repo.CreateMatch(usuarioUno, usuarioDos);
        }
    }
}
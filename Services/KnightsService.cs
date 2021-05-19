using System;
using System.Collections.Generic;
using week10day3afternoon.Models;
using week10day3afternoon.Repositories;

namespace week10day3afternoon.Services
{
    public class KnightsService
    {
        private readonly KnightsRepository _repository;

        public KnightsService(KnightsRepository repository)
        {
            _repository = repository;
        }

        internal Knight Create(Knight newKnight)
        {
            Knight knight = _repository.Create(newKnight);
            return knight;
        }
    }
}
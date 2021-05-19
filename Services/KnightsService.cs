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

        internal IEnumerable<Knight> GetAll()
        {
            return _repository.GetAll();
        }

        internal Knight GetOne(int id)
        {
            Knight data = _repository.GetOne(id);
            return data;
        }

        internal Knight Create(Knight newKnight)
        {
            Knight data = _repository.Create(newKnight);
            return data;
        }

        internal Knight Edit(Knight updated)
        {
            Knight previous = GetOne(updated.Id);
            previous.Name = updated.Name.Length > 0 ? updated.Name : previous.Name;
            if (_repository.Edit(previous))
            {
                return previous;
            }
            throw new Exception("An error has occured when retrieving the data or updating it");
        }

        internal void Delete(int id)
        {
            GetOne(id);
            _repository.Delete(id);
        }
    }
}
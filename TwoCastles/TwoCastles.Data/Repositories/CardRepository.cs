using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using TwoCastles.Data.Constants;
using TwoCastles.Data.Context;
using TwoCastles.Data.Interfaces;
using TwoCastles.Entities;

namespace TwoCastles.Data.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IMongoCollection<Card> _collection;

        public CardRepository(ApplicationContext context)
        {
            _collection = context.Database.GetCollection<Card>(typeof(Card).Name.ToLower());
        }

        public IEnumerable<Card> GetAll()
        {
            return _collection.Find(c => true).ToList();
        }
    }
}

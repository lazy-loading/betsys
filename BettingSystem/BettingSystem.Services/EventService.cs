using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using BettingSystem.Database;
using BettingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace BettingSystem.Services
{
    public class EventService : IEventService
    {
        private readonly BetsysDbContext _context;

        public EventService(BetsysDbContext context)
        {
            _context = context;
        }

        public void Create(IEnumerable<SportEvent> events)
        {
            _context.SportEvents.AddRange(events);
            _context.SaveChanges();
        }

        public void Update(IEnumerable<SportEvent> events)
        {
            foreach (var e in events)
            {
                Update(e);
            }

            _context.SaveChanges();
        }

        private void Update(SportEvent sportEvent)
        {
            AddUpdateOrDeleteChildren(sportEvent, x => x.Markets);
            foreach (var market in sportEvent.Markets)
            {
                AddUpdateOrDeleteChildren(market, x => x.Selections);
            }

//            _context.Attach(sportEvent);
        }

        private void Gosho()
        {
        }

        private void AddUpdateOrDeleteChildren<TParent, TChild>(TParent parent,
            Expression<Func<TParent, ICollection<TChild>>> collectionProperty)
            where TParent : class, IEntity
            where TChild : class, IEntity
        {
            var parentDbSet = _context.Set<TParent>(); // Event
            var childDbSet = _context.Set<TChild>(); // Market
            var originalParent = parentDbSet
                .AsNoTracking()
                .Include(collectionProperty)
                .FirstOrDefault(x => x.Id == parent.Id);

            var getChildren = collectionProperty.Compile();
            var currentChildren = getChildren(parent);

            if (originalParent == null)
            {
                childDbSet.AddRange(currentChildren);
                return;
            }

            var originalChildren = getChildren(originalParent);

            var removedChildren = originalChildren.ExceptSelect(currentChildren, x => x.Id).ToList();
            var addedChildren = currentChildren.ExceptSelect(originalChildren, x => x.Id).ToList();
            var modifiedChildren = currentChildren.Except(addedChildren).ExceptSelect(originalChildren, x => x)
                .Where(x => !originalChildren.Contains(x)).ToList();

            originalChildren.AddRange(addedChildren);
            originalChildren.RemoveRange(removedChildren);
            if (_context.ChangeTracker.Entries<TParent>()
                .All(x => x.Entity.Id != parent.Id))
                _context.Entry(originalParent).State = EntityState.Modified;
            addedChildren.ForEach(x => _context.Entry(x).State = EntityState.Added);
            modifiedChildren.ForEach(x => _context.Entry(x).State = EntityState.Modified);
            removedChildren.ForEach(x => _context.Entry(x).State = EntityState.Deleted);
        }
    }
}
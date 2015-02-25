using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardShark.Data;
using CardShark.Model;
using System.Data.Entity;

namespace CardShark.Repository
{
    public class GuessRepository : IGuessRepository
    {
        private CardContext _dbContext;

        public GuessRepository()
        {
            _dbContext = new CardContext();
            _dbContext.Guesses.Load();
        }

        public CardContext Context()
        {
            return _dbContext;
        }


        public DbSet<Model.Guess> GetDbSet()
        {
            return _dbContext.Guesses;
        }

        public void Add(Model.Guess G)
        {
            _dbContext.Guesses.Add(G);
            _dbContext.SaveChanges();
        }

        public void Update(Model.Guess G)
        {
            Guess guess; 
            guess = _dbContext.Guesses.Where(g => g.guess == "New Guess").FirstOrDefault<Guess>();

            if (guess != null)
            {
                guess.guess = "New Guess";
            }
            using (var context = new CardContext())
            {
                context.Entry(guess).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Model.Guess G)
        {
            _dbContext.Guesses.Remove(G);
            _dbContext.SaveChanges();
        }

    }
}

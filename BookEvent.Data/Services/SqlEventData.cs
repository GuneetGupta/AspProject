using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEvent.Data.Model;

namespace BookEvent.Data.Services
{
    public class SqlEventData : IBookData
    {
        private readonly EventDBContext db;

        public SqlEventData(EventDBContext db)
        {
            this.db = db;
        }
        public void Add(Event eve)
        {
            db.Events.Add(eve);
            db.SaveChanges();
        }

        public void Delete(Event eve)
        {
            db.Events.Remove(db.Events.Find(eve.Id));
            db.SaveChanges();
        }

        public Event Get(int id)
        {
            return db.Events.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Event> getAll()
        {
            return from p in db.Events
                   orderby p.Date
                   select p;
        }

        public void Update(Event eve)
        {
            var entry = db.Entry(eve);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public User Login(User user)
        {
            var obj = db.Users.Where(a => a.Gmail.Equals(user.Gmail) && a.Password.Equals(user.Password)).FirstOrDefault();
            return obj;
        }

        public void Register(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void AddEventId(Inviteduser iu, int id)
        {
            iu.EventId = id;
            db.Invitedusers.Add(iu);
            db.SaveChanges();
        }

        public IEnumerable<Inviteduser> getFromInvite()
        {
            return from p in db.Invitedusers
                   select p;
        }
    }
}
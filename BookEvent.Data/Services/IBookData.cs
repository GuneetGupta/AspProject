using BookEvent.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEvent.Data.Services
{
    public interface IBookData
    {
        IEnumerable<Event> getAll();
        Event Get(int id);

        void Add(Event eve);

        void Update(Event eve);

        void Delete(Event eve);

        User Login(User user);

        void Register(User user);

        void AddEventId(Inviteduser iu, int id);

        IEnumerable<Inviteduser> getFromInvite();
    }
}

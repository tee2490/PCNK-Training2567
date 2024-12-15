using BlazorApp6.Models;

namespace BlazorApp6.Services
{
    public class TheatreService : ITheatreService
    {
        Random r;
        public List<List<Ticket>> Theatres;

        public TheatreService()
        {
            r = new Random();
            Theatres = new();
        }

        public void CreateTheatre() //หลายโรง
        {

            var number = r.Next(2, 6);

            for (int i = 1; i <= number; i++)
            {
                Theatres.Add(CreateTicket());
            }
        }

        private List<Ticket> CreateTicket() // 1 โรง
        {
            var number = r.Next(10, 21);
            var tempTickets = new List<Ticket>();

            for (int i = 1; i <= number; i++)
            {
                tempTickets.Add(new Ticket
                {
                    Id = i,
                    Age = r.Next(3, 101),
                    Gentle = (SD.Sex)r.Next(0, 2),
                    MemberType = (SD.TypeM)r.Next(0, 2),
                    Month = r.Next(1, 13)
                });
            }

            var test = tempTickets.CountBy(p => p.Month);

            return tempTickets;
        }

        public (KeyValuePair<int, int> maxMonth, KeyValuePair<int, int> minMonth) MaxMinMonth(List<Ticket> tickets)
        {
           var maxMonth = tickets.CountBy(p => p.Month).MaxBy(p=>p.Value);
           var minMonth = tickets.CountBy(p => p.Month).MinBy(p => p.Value);

            return (maxMonth, minMonth);
        }




    }
}

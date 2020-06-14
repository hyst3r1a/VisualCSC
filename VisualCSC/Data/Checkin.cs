using System;
namespace VisualCSC.Data
{
    public class Checkin
    {
        public Checkin()
        {

        }
        public int Id { get; set; }

        public string Position { get; set; }

        public Person Person { get; set; }

    }
}

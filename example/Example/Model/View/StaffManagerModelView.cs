using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.View
{
    public class StaffManagerModelView
    {
        public long? DailyId { get; set; }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public int? PositionId { get; set; }
        public string Position { get; set; }
        public string Skype { get; set; }
        public string ChiefName { get; set; }
    }
}
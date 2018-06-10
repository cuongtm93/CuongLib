using Retyped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DatePicker : KendoDatePickerEventHandler
    {
        public DatePicker() : base("datepicker")
        {

        }

        public override void onChange(object obj)
        {
            @this.SetToday();
            
        }
        public override void onClick(object obj)
        {
            
        }
        public override void onHover(object obj)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;
using Bridge;
namespace Kernel
{
    public class KendoDatePickerEventHandler : KendoDatePicker
    {
        public KendoDatePickerEventHandler(string Id) : base(Id)
        {
            var @object = dom.document.getElementById(this._kendoDatePickerId) as dom.HTMLInputElement;
            @object.onchange += onChange;
            @object.onclick += onClick;
            @object.onmouseenter += onHover;
        }

        public virtual void onChange(object obj)
        {
            
        }

        public virtual void onClick(object obj)
        {

            
        }

        public virtual void onHover(object obj)
        {

           
        }
    }
}
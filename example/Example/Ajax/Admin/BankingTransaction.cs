using System.Collections.Generic;
using Retyped;
namespace Ajax.Admin
{
    public class BankingTransaction : Library.Ajax
    {
        public BankingTransaction()
        {
            Url = "/Admin/BankingTransaction";
            Method = "GET";
        }
        
        public virtual void getValue1()
        {
            Retyped.dom.XMLHttpRequest request = new dom.XMLHttpRequest();
            request.onload += (ev) =>
            {

                request.responseText.ToString();
            };
            error = getValue1_Error;
            success = getValue1_Sucess;
            data = "abc";
            base.Request();
        }

        
        private object Abc(dom.ProgressEvent ev)
        {
            return null;
        }

        private void getValue1_Sucess(object data, jquery.JQuery.Ajax.SuccessTextStatus textStatus, jquery.JQuery.jqXHR<object> jqXHR)
        {
            
        }

        private void getValue1_Error(jquery.JQuery.jqXHR<object> jqXHR, jquery.JQuery.Ajax.ErrorTextStatus textStatus, string errorThrown)
        {
            
        }
    }
}

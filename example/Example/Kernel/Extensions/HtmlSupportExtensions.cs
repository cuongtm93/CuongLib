using Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retyped;

public static class support
{
    public static void clearInnerHtml(this dom.HTMLElement element)
    {

        element.innerHTML = string.Empty;
    }

    public static void plusText(this dom.HTMLElement element, string text)
    {
        if (!element.isConnected)
            dom.alert("Không thể thực hiện hành động này");

        var textSpan = new dom.HTMLSpanElement()
        {
            innerText = text
        };

        element.insertAdjacentElement(dom.InsertPosition.afterend, textSpan);
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;

public static class KendoButton
{
    public static AutoCompleteBuilder AutoCompleteTemplate(this HtmlHelper helper)
    {
        return helper.Kendo().AutoComplete();
    }

    public static AutoCompleteBuilder AutoComplete1(this HtmlHelper helper)
    {
        // Kế thừa autocomplete chuẩn
        var auto = AutoCompleteTemplate(helper);
        auto.Name("autocomplete1");
        auto.Template("autocomplete số 1");
        return auto;
    }
    public static AutoCompleteBuilder AutoComplete2(this HtmlHelper helper)
    {
        // Kế thừa autocomplete chuẩn
        var auto = AutoCompleteTemplate(helper);
        auto.Name("autocomplete2");
        auto.Template("autocomplete số 2");
        auto.DataSource(data => data.Read("action", "controller"));
        auto.Events(AutoComplete2_events);
        return auto;
    }

    private static void AutoComplete2_events(AutoCompleteEventBuilder evt)
    {
        evt.Change("alert('đổi')");
        evt.Close("alert('đóng')");
    }

    public static AutoCompleteBuilder AutoComplete_kethua1(this HtmlHelper helper)
    {
        // kế thừa AutoComplete2
        var auto = AutoComplete2(helper);
        auto.Template("autocomplete kế thừa autocomplete số 2");
        auto.Events(AutoComplete_kethua1_change);
        return auto;
    }

    private static void AutoComplete_kethua1_change(AutoCompleteEventBuilder evt)
    {

        // kế thừa sự kiện của AutoComplete2
        AutoComplete2_events(evt);

        // thêm sự kiện nữa
        evt.Filtering("sukienmoi");
    }
}

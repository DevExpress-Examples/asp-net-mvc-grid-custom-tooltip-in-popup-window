<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/GridViewTooltip/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/GridViewTooltip/Controllers/HomeController.vb))
* [SimpleModel.cs](./CS/GridViewTooltip/Models/SimpleModel.cs) (VB: [SimpleModel.vb](./VB/GridViewTooltip/Models/SimpleModel.vb))
* [GridViewPartial.cshtml](./CS/GridViewTooltip/Views/Home/GridViewPartial.cshtml)
* **[Index.cshtml](./CS/GridViewTooltip/Views/Home/Index.cshtml)**
<!-- default file list end -->
# GridView - How to create a custom tooltip for cells to display long text 


<p>This example demonstrates how to create a custom tooltip for data cells using the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument9006"> PopupControl</a>. The main idea is to assign a delegate method to the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_HtmlDataCellPreparedtopic">GridViewSettings.HtmlDataCellPrepared</a>  property and handle the mouseover event to display a popup window.</p>


```cs
   settings.HtmlDataCellPrepared = (s, e) => {
        e.Cell.Attributes.Add("onmouseover", String.Format("OnMouseMove(this, event, '{0}');", e.KeyValue));
   };
```




```vb
    settings.HtmlDataCellPrepared = Sub(s, e)
         e.Cell.Attributes.Add("onmouseover", String.Format("OnMouseMove(this, event, '{0}');", e.KeyValue))
    End Sub
```




```js
  var oldKey = null;
  function OnMouseMove(element, event, key) {
        if (typeof GridView.cpTooltipList[key] != "undefined" && oldKey != key) {
            oldKey = key;
            PopupControl.ShowAtPos(event.clientX, event.clientY);
            ToolTipLabel.SetText("Item " + key + "<br/>" + GridView.cpTooltipList[key]);
        }   
   }
```


<p><br>The <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_CustomJSPropertiestopic">GridViewSettings.CustomJSProperties</a>  property is used to pass data to the client side. </p>


```cs
  settings.CustomJSProperties = (s, e) => {
        MVCxGridView grid = s as MVCxGridView;
        int startIndex = grid.VisibleStartIndex;
        int endIndex = grid.VisibleStartIndex + grid.SettingsPager.PageSize;
        var clientData = new Dictionary<int, object>();
        for (int i = startIndex; i <  endIndex; i++)
        {
            var rowValues = grid.GetRowValues(i, new string[] { "ID", "Description" }) as object[];
            clientData.Add(Convert.ToInt32(rowValues[0]), rowValues[1]);
         
        }                
        e.Properties.Add("cpTooltipList", clientData);
   };
```




```vb
   settings.CustomJSProperties = Sub(s, e)
             Dim grid As MVCxGridView = TryCast(s, MVCxGridView)
             Dim startIndex As Integer = grid.VisibleStartIndex
             Dim endIndex As Integer = grid.VisibleStartIndex + grid.SettingsPager.PageSize
             Dim clientData = New Dictionary(Of Integer, Object)()
             For i As Integer = startIndex To endIndex - 1
                  Dim rowValues = TryCast(grid.GetRowValues(i, New String() {"ID", "Description"}), Object())
                  clientData.Add(Convert.ToInt32(rowValues(0)), rowValues(1))
             Next i
             e.Properties.Add("cpTooltipList", clientData)
   End Sub
```



<br/>



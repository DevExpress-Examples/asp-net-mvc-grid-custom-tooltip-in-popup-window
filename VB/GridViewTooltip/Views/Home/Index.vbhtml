@Code
    ViewBag.Title = "GridView - How to create a custom tooltip for cells to display long text"
End Code
<script type="text/javascript">
    var oldKey = null;
    function OnMouseMove(element, event, key) {
        if (typeof GridView.cpTooltipList[key] != "undefined" && oldKey != key) {
            oldKey = key;
            PopupControl.ShowAtPos(event.clientX, event.clientY);
            ToolTipLabel.SetText("Item " + key + "<br/>" + GridView.cpTooltipList[key]);
        }   
    }
</script>
<h2>GridView - How to create a custom tooltip for cells to display long text</h2>


@Html.Action("GridViewPartial")
@Html.DevExpress().PopupControl(Sub(settings)

                                    settings.Name = "PopupControl"
                                    settings.ShowHeader = False
                                    settings.AllowDragging = False
                                    settings.AllowResize = False
                                    settings.Width = 300
                                    settings.Height = 300
                                    settings.ScrollBars = ScrollBars.Auto
                                    settings.SetContent(Sub()
                                                            Html.DevExpress().Label(Sub(ls)
                                                                                        ls.Name = "ToolTipLabel"
                                                                                        ls.Properties.EnableClientSideAPI = True
                                                                                        ls.ControlStyle.Wrap = DefaultBoolean.True
                                                                                    End Sub).Render()
                                                        End Sub)
                                         
                                End Sub).GetHtml()

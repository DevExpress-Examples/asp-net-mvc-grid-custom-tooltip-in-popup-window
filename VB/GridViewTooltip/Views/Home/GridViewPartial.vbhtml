@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "GridView"
                                settings.KeyFieldName = "ID"
                                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
                                settings.Columns.Add("ID")
                                settings.Columns.Add("Name")
                                settings.SettingsPager.EnableAdaptivity = True
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
                                settings.HtmlDataCellPrepared = Sub(s, e)
    

                                                                    e.Cell.Attributes.Add("onmouseover", String.Format("OnMouseMove(this, event, '{0}');", e.KeyValue))
                                                                End Sub

                            End Sub).Bind(Model).GetHtml()
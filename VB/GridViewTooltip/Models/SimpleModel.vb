Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace GridViewTooltip.Models
	Public Class SimpleModel
		Public Property ID() As Integer
		Public Property Name() As String
		Public Property Description() As String

		Private Const descriptionString As String = "With DevExpress web controls, you can build a bridge to the future on the platform you know and love. 
          The 175+ AJAX controls and MVC extensions that make up the DevExpress ASP.NET Subscription have been engineered so you can deliver exceptional, touch-enabled, interactive experiences for the web, regardless of the target browser or computing device. 
DevExpress web UI components support all major browsers including Internet Explorer, FireFox, Chrome, Safari and Opera, and are continuously tested to ensure the best possible compatibility across platforms, operating systems and devices.    
     And to ensure you can build your best and meet the needs of your enterprise each and every time, the DevExpress ASP.NET Subscription ships with 0 built-in application themes that can be used out-of-the box or customized via our ASP.NET Theme Builder"
		Public Shared Function GetData() As List(Of SimpleModel)
			Dim l As List(Of SimpleModel) = TryCast(HttpContext.Current.Session("data"), List(Of SimpleModel))
			If l Is Nothing Then
				l = New List(Of SimpleModel)()
				For i As Integer = 0 To 99
					l.Add(New SimpleModel() With {
						.ID = i,
						.Name = "ItemName " & i,
						.Description = descriptionString
					})
				Next i
			End If
			Return l
		End Function
	End Class
End Namespace
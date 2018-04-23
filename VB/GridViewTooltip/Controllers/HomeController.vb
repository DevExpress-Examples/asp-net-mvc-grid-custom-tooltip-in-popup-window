Imports Microsoft.VisualBasic
Imports GridViewTooltip.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace GridViewTooltip.Controllers
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/

		Public Function Index() As ActionResult
			Return View()
		End Function


		Public Function GridViewPartial() As ActionResult
			Dim model As List(Of SimpleModel) = SimpleModel.GetData()
			Return PartialView(model)
		End Function
	End Class
End Namespace

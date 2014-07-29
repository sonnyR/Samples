﻿Imports SolidEdgeFramework.Extensions 'SolidEdge.Community.dll
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace ApiSamples.Part
	''' <summary>
	''' 
	''' </summary>
	Friend Class DeleteCustomProperties
		Private Shared Sub RunSample(ByVal breakOnStart As Boolean)
			If breakOnStart Then
				System.Diagnostics.Debugger.Break()
			End If

			Dim application As SolidEdgeFramework.Application = Nothing

			Try
				' Register with OLE to handle concurrency issues on the current thread.
				SolidEdgeCommunity.OleMessageFilter.Register()

				' Connect to or start Solid Edge.
				application = SolidEdgeCommunity.SolidEdgeInstall.Connect(True, True)

				' Get a reference to the active assembly document.
				Dim document = application.GetActiveDocument(Of SolidEdgePart.PartDocument)(False)

				If document IsNot Nothing Then
					Dim propertySets = DirectCast(document.Properties, SolidEdgeFramework.PropertySets)

					ApiSamples.Common.FileProperties.DeleteCustomProperties(propertySets)
				Else
					Throw New System.Exception(Resources.NoActivePartDocument)
				End If
			Catch ex As System.Exception
				Console.WriteLine(ex.Message)
			Finally
				SolidEdgeCommunity.OleMessageFilter.Unregister()
			End Try
		End Sub
	End Class
End Namespace

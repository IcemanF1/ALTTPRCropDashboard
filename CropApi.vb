﻿
Imports System.Net.Http
Imports System.Net.Http.Formatting
Imports System.Net.Http.Headers
Imports ALTTPRCropDashboard.Data
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization

Public Class CropApi
    Protected Property Client As New HttpClient
    Protected Property Formatter As New JsonMediaTypeFormatter With {
        .SerializerSettings = New JsonSerializerSettings With {.Formatting = Formatting.Indented, .ContractResolver = New CamelCasePropertyNamesContractResolver}
    }

    Public Function GetCrops() As IEnumerable(Of RunnerInfo)
        Dim response = Client.GetAsync("v1/crops").Result
        If response.IsSuccessStatusCode Then
            Return response.Content.ReadAsAsync(Of IEnumerable(Of RunnerInfo))({Formatter}).Result
        End If

        Return Nothing
    End Function

    Public Sub CreateCrop(crop As RunnerCropAdd)
        Dim response = Client.PostAsync("v1/crops", crop, Formatter).Result
        response.EnsureSuccessStatusCode()

    End Sub

    Public Sub New(apiPath As String)
        Client.BaseAddress = New Uri(apiPath)
        Client.DefaultRequestHeaders.Accept.Clear()
        Client.DefaultRequestHeaders.Accept.Add(
            New MediaTypeWithQualityHeaderValue("application/json"))
        Client.Timeout = TimeSpan.FromSeconds(10)
    End Sub

    Private Sub New()

    End Sub
End Class
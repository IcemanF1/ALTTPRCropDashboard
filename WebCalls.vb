Imports System
Imports System.Net
Imports System.Text
Imports System.IO

Public Class WebCalls
    Public Shared WebURL As String
    Public Shared Function GetCallFromServer() As String
        ' Create a request for the URL. 
        Dim request As HttpWebRequest =
          HttpWebRequest.Create(WebURL)
        ' If required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials
        request.ContentType = "application/json; charset=utf-8"
        ' Get the response.
        Dim response As HttpWebResponse = request.GetResponse
        ' Display the status.
        'Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        Dim dataStream As Stream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream, Encoding.UTF8)
        ' Read the content.

        Dim responseFromServer As String = reader.ReadToEnd()

        ' Display the content.

        ' Clean up the streams and the response.
        reader.Close()
        response.Close()

        Return responseFromServer
    End Function
    Public Shared Sub SendToServer(ByVal content As String)
        Dim status As HttpStatusCode = HttpStatusCode.ExpectationFailed
        Dim response As Byte() = PostResponse(WebURL, content, status)
        Dim responseString As String
        If response IsNot Nothing Then
            responseString = System.Text.Encoding.UTF8.GetString(response)
        Else
            responseString = "NULL"
        End If
        Console.WriteLine("Response Code: " & status)
        Console.WriteLine("Response String: " & responseString)
    End Sub
    Public Shared Function PostResponse(url As String, content As String, ByRef statusCode As HttpStatusCode) As Byte()

        Dim responseFromServer As Byte() = Nothing
        Dim dataStream As Stream = Nothing

        Try
            Dim request As WebRequest = WebRequest.Create(url)

            request.Timeout = 120000

            request.Method = "POST"


            Dim byteArray As Byte() = System.Text.Encoding.UTF8.GetBytes(content)

            request.ContentType = "application/json"

            request.ContentLength = byteArray.Length

            dataStream = request.GetRequestStream()

            dataStream.Write(byteArray, 0, byteArray.Length)

            dataStream.Close()



            Dim response As WebResponse = request.GetResponse()

            dataStream = response.GetResponseStream()

            Dim ms As New MemoryStream()

            Dim thisRead As Integer = 0

            Dim buff As Byte() = New Byte(1023) {}

            Do
                thisRead = dataStream.Read(buff, 0, buff.Length)

                If thisRead = 0 Then
                    Exit Do
                End If


                ms.Write(buff, 0, thisRead)
            Loop While True

            responseFromServer = ms.ToArray()

            dataStream.Close()

            response.Close()

            statusCode = HttpStatusCode.OK

        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                dataStream = ex.Response.GetResponseStream()
                Dim reader As New StreamReader(dataStream)
                Dim resp As String = reader.ReadToEnd()
                statusCode = DirectCast(ex.Response, HttpWebResponse).StatusCode
            Else
                Dim resp As String = ""

                statusCode = HttpStatusCode.ExpectationFailed

            End If

        Catch ex As Exception
            statusCode = HttpStatusCode.ExpectationFailed
        End Try



        Return responseFromServer

    End Function

End Class

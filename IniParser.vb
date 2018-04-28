Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices

Public NotInheritable Class IniParser
    Private Shared SectionRegex As New Regex("\[(?<section>[^\n\[\]]+)\]\n*(?<valuelist>(.(?!\[[^\n\[\]]+\]))*)", RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.Compiled)
    Private Shared ValueRegex As New Regex("(?<valuename>[^=\n]+)=(?<value>[^\n]*)", RegexOptions.CultureInvariant Or RegexOptions.Compiled)

    <DllImportAttribute("kernel32.dll", EntryPoint:="WritePrivateProfileStringW")>
    Public Shared Function WritePrivateProfileStringW(<InAttribute(), MarshalAs(UnmanagedType.LPWStr)> ByVal lpSecName As String, <InAttribute(), MarshalAs(UnmanagedType.LPWStr)> ByVal lpKeyName As String, <InAttribute(), MarshalAs(UnmanagedType.LPWStr)> ByVal lpString As String, <InAttribute(), MarshalAs(UnmanagedType.LPWStr)> ByVal lpFileName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    ''' <summary>
    ''' Parses an .ini-file.
    ''' </summary>
    ''' <param name="FileName">The path to the file to parse.</param>
    ''' <remarks></remarks>
    Public Shared Function ParseFile(ByVal FileName As String) As Dictionary(Of String, Dictionary(Of String, String))
        Return IniParser.Parse(File.ReadAllText(FileName))
    End Function

    ''' <summary>
    ''' Parses a text of .ini-format.
    ''' </summary>
    ''' <param name="Data">The text to parse.</param>
    ''' <remarks></remarks>
    Public Shared Function Parse(ByVal Data As String) As Dictionary(Of String, Dictionary(Of String, String))
        Dim Result As New Dictionary(Of String, Dictionary(Of String, String)) '(Section, (Value name, Value))
        Dim Sections As MatchCollection = SectionRegex.Matches(Data)

        'Iterate each section.
        For Each SectionMatch As Match In Sections
            Dim Section As New Dictionary(Of String, String)
            Dim SectionName As String = SectionMatch.Groups("section").Value
            Dim Values As MatchCollection = ValueRegex.Matches(SectionMatch.Groups("valuelist").Value)

            If Result.ContainsKey(SectionName) = True Then
                'A section by this name already exists.
                Dim i As Integer = 1

                'Append a number to the section name until a unique name is found.
                While Result.ContainsKey(SectionName & i)
                    i += 1
                End While

                Result.Add(SectionName & i, Section)
            Else
                'A section by this name does not exist.
                Result.Add(SectionName, Section)
            End If

            'Iterate each value of this section.
            For Each ValueMatch As Match In Values
                Dim ValueName As String = ValueMatch.Groups("valuename").Value
                Dim Value As String = ValueMatch.Groups("value").Value

                If Section.ContainsKey(ValueName) = True Then
                    'A value by this name already exists.
                    Dim i As Integer = 1

                    'Append a number to the value name until a unique name is found.
                    While Section.ContainsKey(ValueName & i)
                        i += 1
                    End While

                    Section.Add(ValueName & i, Value)
                Else
                    'A value by this name does not exist.
                    Section.Add(ValueName, Value)
                End If
            Next
        Next

        Return Result
    End Function
End Class
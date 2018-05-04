Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Runtime.InteropServices

Public NotInheritable Class IniParser
    Private Shared ReadOnly SectionRegex As New Regex("\[(?<section>[^\n\[\]]+)\]\n*(?<valuelist>(.(?!\[[^\n\[\]]+\]))*)", RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.Compiled)
    Private Shared ReadOnly ValueRegex As New Regex("(?<valuename>[^=\n]+)=(?<value>[^\n]*)", RegexOptions.CultureInvariant Or RegexOptions.Compiled)

    <DllImportAttribute("kernel32.dll", EntryPoint:="WritePrivateProfileStringW")>
    Public Shared Function WritePrivateProfileStringW(<InAttribute(), MarshalAs(UnmanagedType.LPWStr)> lpSecName As String, <InAttribute(), MarshalAs(UnmanagedType.LPWStr)> lpKeyName As String, <InAttribute(), MarshalAs(UnmanagedType.LPWStr)> lpString As String, <InAttribute(), MarshalAs(UnmanagedType.LPWStr)> lpFileName As String) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    ''' <summary>
    ''' Parses an .ini-file.
    ''' </summary>
    ''' <param name="fileName">The path to the file to parse.</param>
    ''' <remarks></remarks>
    Public Shared Function ParseFile(fileName As String) As Dictionary(Of String, Dictionary(Of String, String))
        Return Parse(File.ReadAllText(fileName))
    End Function

    ''' <summary>
    ''' Parses a text of .ini-format.
    ''' </summary>
    ''' <param name="data">The text to parse.</param>
    ''' <remarks></remarks>
    Public Shared Function Parse(data As String) As Dictionary(Of String, Dictionary(Of String, String))
        Dim result As New Dictionary(Of String, Dictionary(Of String, String)) '(Section, (Value name, Value))
        Dim sections As MatchCollection = SectionRegex.Matches(data)

        'Iterate each section.
        For Each sectionMatch As Match In sections
            Dim section As New Dictionary(Of String, String)
            Dim sectionName As String = sectionMatch.Groups("section").Value
            Dim values As MatchCollection = ValueRegex.Matches(sectionMatch.Groups("valuelist").Value)

            If result.ContainsKey(sectionName) = True Then
                'A section by this name already exists.
                Dim i = 1

                'Append a number to the section name until a unique name is found.
                While result.ContainsKey(sectionName & i)
                    i += 1
                End While

                result.Add(sectionName & i, section)
            Else
                'A section by this name does not exist.
                result.Add(sectionName, section)
            End If

            'Iterate each value of this section.
            For Each valueMatch As Match In values
                Dim valueName As String = valueMatch.Groups("valuename").Value
                Dim value As String = valueMatch.Groups("value").Value

                If section.ContainsKey(valueName) = True Then
                    'A value by this name already exists.
                    Dim i = 1

                    'Append a number to the value name until a unique name is found.
                    While section.ContainsKey(valueName & i)
                        i += 1
                    End While

                    section.Add(valueName & i, value)
                Else
                    'A value by this name does not exist.
                    section.Add(valueName, value)
                End If
            Next
        Next

        Return result
    End Function
End Class
Namespace Data
    Public Class WindowSize
        Public Property Width As Integer
        Public Property Height As Integer

        'Helper casts
        Public Shared Widening Operator CType(d As WindowSize) As Size
            Return New Size(d.Width, d.Height)
        End Operator
        Public Shared Narrowing Operator CType(d As Size) As WindowSize
            Return New WindowSize With {.Width = d.Width, .Height = d.Height}
        End Operator

    End Class
End NameSpace
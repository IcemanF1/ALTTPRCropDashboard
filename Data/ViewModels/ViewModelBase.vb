Imports System.ComponentModel
Imports System.Runtime.CompilerServices

Namespace Data.ViewModels
    ''' <summary>
    ''' Helper ViewModel class that implements INotifyPropertyChanged.
    ''' Call SetField(field, value) on property setters to make it work.
    ''' </summary>
    Public MustInherit Class ViewModelBase
        Implements INotifyPropertyChanged

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Overridable Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

        Protected Function SetField(Of T)(ByRef field As T, value As T, <CallerMemberName> Optional propertyName As String = Nothing) As Boolean
            If EqualityComparer(Of T).Default.Equals(field, value) Then
                Return False
            End If

            field = value
            OnPropertyChanged(propertyName)
            Return True
        End Function
    End Class
End Namespace
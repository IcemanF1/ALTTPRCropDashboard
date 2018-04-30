
Imports System.Data.Entity

Namespace DB
    Public Class CropDbContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("DefaultContext")

        End Sub

        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
            MyBase.OnModelCreating(modelBuilder)

        End Sub

        Public Overridable Property Crops As DbSet(Of Crop)
    End Class
End Namespace
Imports System

Public Class Rectangle
    Private length As Double
    Private width As Double

    'Public methods
    Public Sub AcceptDetails()
        length = 4.5
        width = 3.5
    End Sub

    Public Function GetArea() As Double
        GetArea = length * width

    End Function
    Public Sub Display()
        Console.WriteLine("Length:{0}", length)
        Console.WriteLine("width:{0}", width)
        Console.WriteLine("GetArea:{0}", GetArea())
    End Sub


    Shared Sub Main()
        Dim r As New Rectangle()
        r.AcceptDetails()
        r.Display()
        Console.ReadLine()
    End Sub




End Class

Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Presentation
Imports Independentsoft.Office.Presentation.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim input As New Presentation("c:\test\input.pptx")
        Dim output As New Presentation()

        Dim slide1 As Slide = input.Slides(0)
        Dim master1 As SlideMaster = Nothing

        'find master
        For Each currentMaster As SlideMaster In input.SlideMasters
            If currentMaster.Layouts.Contains(slide1.Layout) Then
                master1 = currentMaster
            End If
        Next

        output.Slides.Add(slide1)
        output.SlideMasters.Add(master1)

        output.SlideSize = New SlideSize(9144000, 6858000, SlideSizeType.Screen4x3)
        output.NotesSlideSize = New NotesSlideSize(6858000, 9144000)

        output.Save("c:\test\output.pptx", True)

    End Sub

End Module
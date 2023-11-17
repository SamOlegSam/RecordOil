Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Presentation
Imports Independentsoft.Office.Presentation.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim presentation As New Presentation("c:\\test\\input.pptx")

        For Each slide As Slide In presentation.Slides

            If slide.NotesSlide IsNot Nothing AndAlso slide.NotesSlide.CommonSlideData IsNot Nothing Then

                Dim data As CommonSlideData = slide.NotesSlide.CommonSlideData

                For Each elemente As Independentsoft.Office.Presentation.Drawing.IGroupElement In data.ShapeTree.Elements

                    If TypeOf elemente Is Independentsoft.Office.Presentation.Drawing.Shape Then

                        Dim shape As Independentsoft.Office.Presentation.Drawing.Shape = DirectCast(elemente, Independentsoft.Office.Presentation.Drawing.Shape)

                        If shape.TextBody IsNot Nothing Then

                            For Each paragraph As Independentsoft.Office.Drawing.TextParagraph In shape.TextBody.Paragraphs

                                For Each content As Independentsoft.Office.Drawing.ITextParagraphContent In paragraph.Content

                                    If TypeOf content Is Independentsoft.Office.Drawing.TextRun Then
                                        Dim run As Independentsoft.Office.Drawing.TextRun = DirectCast(content, Independentsoft.Office.Drawing.TextRun)
                                        Console.WriteLine(run.Text)
                                    End If

                                Next
                            Next
                        End If
                    End If
                Next
            End If
        Next

        Console.Read()

    End Sub

End Module
Imports System
Imports System.IO
Imports Independentsoft.Office.Presentation
Imports Independentsoft.Office.Presentation.Drawing

Module Module1
    Sub Main(ByVal args() As String)

        Dim presentation As New Presentation("c:\test\input.pptx")

        For i As Integer = 0 To presentation.Slides.Count - 1
            Dim slide As Slide = presentation.Slides(i)

            Dim slideFolder As DirectoryInfo = System.IO.Directory.CreateDirectory("c:\test\Slide" & (i + 1))
            Dim slideText As String = ""

            If slide.CommonSlideData IsNot Nothing Then
                Dim shapeTree As GroupShape = slide.CommonSlideData.ShapeTree

                If shapeTree IsNot Nothing Then
                    For Each element As IGroupElement In shapeTree.Elements
                        If TypeOf element Is Picture Then

                            Dim picture As Picture = DirectCast(element, Picture)
                            picture.Save(slideFolder.FullName & "\" & picture.FileName, True)

                        ElseIf TypeOf element Is Shape Then

                            Dim shape As Shape = DirectCast(element, Shape)

                            If shape.TextBody IsNot Nothing Then

                                Dim textBody As ShapeTextBody = shape.TextBody

                                For p As Integer = 0 To textBody.Paragraphs.Count - 1
                                    Dim paragraph As Independentsoft.Office.Drawing.TextParagraph = textBody.Paragraphs(p)

                                    For r As Integer = 0 To paragraph.Content.Count - 1

                                        If TypeOf paragraph.Content(r) Is Independentsoft.Office.Drawing.TextRun Then

                                            Dim run As Independentsoft.Office.Drawing.TextRun = DirectCast(paragraph.Content(r), Independentsoft.Office.Drawing.TextRun)
                                            slideText += run.Text

                                        End If
                                    Next

                                    slideText += vbCr & vbLf
                                Next

                            End If
                        End If
                    Next
                End If
            End If

            Dim writer As StreamWriter = File.CreateText(slideFolder.FullName & "\text.txt")
            writer.Write(slideText)
            writer.Close()

        Next
    End Sub
End Module
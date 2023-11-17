Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Drawing.Tables
Imports Independentsoft.Office.Presentation
Imports Independentsoft.Office.Presentation.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim presentation As New Presentation()

        Dim shapeTree As New GroupShape()
        shapeTree.ID = "2"
        shapeTree.Name = "ShapeTree"
        shapeTree.ShapeProperties.TransformGroup2D = New Independentsoft.Office.Drawing.TransformGroup2D()

        Dim cell1 As New Cell()
        cell1.ShapeTextBody = New Independentsoft.Office.Drawing.ShapeTextBody()
        cell1.ShapeTextBody.TextListStyle = New Independentsoft.Office.Drawing.TextListStyle()

        Dim run1 As New Independentsoft.Office.Drawing.TextRun("Text 123")

        Dim paragraph1 As New Independentsoft.Office.Drawing.TextParagraph()
        paragraph1.Content.Add(run1)

        cell1.ShapeTextBody.Paragraphs.Add(paragraph1)

        Dim row1 As New Row()
        row1.Height = New Unit(50, UnitType.Pixel)
        row1.Cells.Add(cell1)
        row1.Cells.Add(cell1)
        row1.Cells.Add(cell1)

        Dim table As New Table()
        table.FirstRow = True
        table.BandedRows = True

        table.Grid = New TableGrid()
        table.Grid.Columns.Add(New TableGridColumn(1524000))
        table.Grid.Columns.Add(New TableGridColumn(1524000))
        table.Grid.Columns.Add(New TableGridColumn(1524000))

        table.Rows.Add(row1)

        Dim graphicFrame As New Independentsoft.Office.Presentation.Drawing.GraphicFrame()
        graphicFrame.ID = "3"
        graphicFrame.Name = "table 1"
        graphicFrame.GraphicObject = table

        graphicFrame.Transform2D = New Independentsoft.Office.Presentation.Drawing.Transform2D()
        graphicFrame.Transform2D.Offset = New Independentsoft.Office.Drawing.Offset(1524000, 1397000)
        graphicFrame.Transform2D.Extents = New Independentsoft.Office.Drawing.Extents(6096000, 370840)

        shapeTree.Elements.Add(graphicFrame)

        Dim commonSlideData As New CommonSlideData()
        commonSlideData.ShapeTree = shapeTree

        Dim layout1 As New SlideLayout()
        layout1.CommonSlideData = GetLayoutCommonSlideData()

        Dim slide1 As New Slide()
        slide1.CommonSlideData = commonSlideData
        slide1.Layout = layout1

        Dim master1 As New SlideMaster()
        master1.CommonSlideData = GetLayoutCommonSlideData()
        master1.Layouts.Add(layout1)

        master1.TextStyles = New SlideMasterTextStyles()
        master1.TextStyles.TitleStyle = New SlideMasterTitleTextStyle()
        master1.TextStyles.TitleStyle.ListLevel1TextStyle.DefaultTextRunProperties.FontSize = 44

        presentation.Slides.Add(slide1)
        presentation.SlideMasters.Add(master1)

        presentation.SlideSize = New SlideSize(9144000, 6858000, SlideSizeType.Screen4x3)
        presentation.NotesSlideSize = New NotesSlideSize(6858000, 9144000)

        presentation.Save("c:\test\output.pptx", True)

    End Sub

    Function GetLayoutCommonSlideData() As CommonSlideData
        Dim shapeTree As New GroupShape()
        shapeTree.ID = "1"
        shapeTree.Name = "layout"

        shapeTree.ShapeProperties.TransformGroup2D = New Independentsoft.Office.Drawing.TransformGroup2D()

        Dim commonSlideData As New CommonSlideData()
        commonSlideData.ShapeTree = shapeTree

        Return commonSlideData
    End Function

End Module
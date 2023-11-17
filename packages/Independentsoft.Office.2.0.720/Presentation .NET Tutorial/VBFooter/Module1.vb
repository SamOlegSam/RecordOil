Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Presentation
Imports Independentsoft.Office.Presentation.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim presentation As New Presentation()

        Dim shapeTree As New GroupShape()
        shapeTree.ID = "1"
        shapeTree.Name = "ShapeTree"
        shapeTree.ShapeProperties.TransformGroup2D = New Independentsoft.Office.Drawing.TransformGroup2D()

        Dim run1 As New Independentsoft.Office.Drawing.TextRun("Footer Text")

        Dim paragraph1 As New Independentsoft.Office.Drawing.TextParagraph()
        paragraph1.Alignment = Independentsoft.Office.Drawing.TextAlignmentType.Center
        paragraph1.Content.Add(run1)

        Dim textBody As New ShapeTextBody()
        textBody.Paragraphs.Add(paragraph1)

        Dim shape1 As New Shape()
        shape1.ID = "2"
        shape1.Name = "Footer 1"
        shape1.Locking = New Independentsoft.Office.Drawing.ShapeLocking()
        shape1.Locking.DisallowGrouping = True
        shape1.Placeholder = New Placeholder(PlaceholderType.Footer)
        shape1.TextBody = textBody

        Dim offsetX As New Unit(4, UnitType.Inch)
        Dim offsetY As New Unit(7, UnitType.Inch)

        Dim width As New Unit(3, UnitType.Inch)
        Dim height As New Unit(1, UnitType.Inch)

        shape1.ShapeProperties.Transform2D = New Independentsoft.Office.Drawing.Transform2D()
        shape1.ShapeProperties.Transform2D.Offset = New Independentsoft.Office.Drawing.Offset(offsetX, offsetY)
        shape1.ShapeProperties.Transform2D.Extents = New Independentsoft.Office.Drawing.Extents(width, height)
        shape1.ShapeProperties.PresetGeometry = New Independentsoft.Office.Drawing.PresetGeometry(Independentsoft.Office.Drawing.ShapeType.Rectangle)

        shapeTree.Elements.Add(shape1)

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
        master1.TextStyles.TitleStyle.ListLevel1TextStyle.DefaultTextRunProperties.FontSize = 10

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
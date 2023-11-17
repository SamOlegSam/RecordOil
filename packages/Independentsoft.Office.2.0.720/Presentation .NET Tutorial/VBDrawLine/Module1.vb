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

        Dim run1 As New Independentsoft.Office.Drawing.TextRun("Hello World")

        Dim paragraph1 As New Independentsoft.Office.Drawing.TextParagraph()
        paragraph1.Alignment = Independentsoft.Office.Drawing.TextAlignmentType.Center
        paragraph1.Content.Add(run1)

        Dim textBody As New ShapeTextBody()
        textBody.Paragraphs.Add(paragraph1)

        Dim shape1 As New Shape()
        shape1.ID = "2"
        shape1.Name = "Title 1"
        shape1.Locking = New Independentsoft.Office.Drawing.ShapeLocking()
        shape1.Locking.DisallowGrouping = True
        shape1.Placeholder = New Placeholder(PlaceholderType.CenteredTitle)
        shape1.TextBody = textBody

        Dim offsetX As New Unit(2, UnitType.Inch)
        Dim offsetY As New Unit(1, UnitType.Inch)

        Dim width As New Unit(6, UnitType.Inch)
        Dim height As New Unit(2, UnitType.Inch)

        shape1.ShapeProperties.Transform2D = New Independentsoft.Office.Drawing.Transform2D()
        shape1.ShapeProperties.Transform2D.Offset = New Independentsoft.Office.Drawing.Offset(offsetX, offsetY)
        shape1.ShapeProperties.Transform2D.Extents = New Independentsoft.Office.Drawing.Extents(width, height)
        shape1.ShapeProperties.PresetGeometry = New Independentsoft.Office.Drawing.PresetGeometry(Independentsoft.Office.Drawing.ShapeType.Rectangle)

        shapeTree.Elements.Add(shape1)
        shapeTree.Elements.Add(GetLine())

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

    Function GetLine() As ConnectionShape
        Dim connectionShape As New ConnectionShape()
        connectionShape.ID = "5"
        connectionShape.Name = "Line1"

        connectionShape.ShapeProperties.PresetGeometry = New Independentsoft.Office.Drawing.PresetGeometry()
        connectionShape.ShapeProperties.PresetGeometry.ShapeType = Independentsoft.Office.Drawing.ShapeType.Line

        connectionShape.Style = New ShapeStyle()

        connectionShape.Style.FontReference = New Independentsoft.Office.Drawing.FontReference()
        connectionShape.Style.FontReference.ColorChoice = New Independentsoft.Office.Drawing.SchemeColor(Independentsoft.Office.Drawing.SchemeColorValue.Text1)
        connectionShape.Style.FontReference.Index = Independentsoft.Office.Drawing.FontCollectionIndex.Minor

        connectionShape.Style.LineReference = New Independentsoft.Office.Drawing.LineReference()
        connectionShape.Style.LineReference.StyleMatrixIndex = 1
        connectionShape.Style.LineReference.ColorChoice = New Independentsoft.Office.Drawing.SchemeColor(Independentsoft.Office.Drawing.SchemeColorValue.Accent1)

        connectionShape.Style.EffectReference = New Independentsoft.Office.Drawing.EffectReference()
        connectionShape.Style.EffectReference.ColorChoice = New Independentsoft.Office.Drawing.SchemeColor(Independentsoft.Office.Drawing.SchemeColorValue.Accent1)
        connectionShape.Style.EffectReference.StyleMatrixIndex = 0

        connectionShape.Style.FillReference = New Independentsoft.Office.Drawing.FillReference()
        connectionShape.Style.FillReference.ColorChoice = New Independentsoft.Office.Drawing.SchemeColor(Independentsoft.Office.Drawing.SchemeColorValue.Accent1)
        connectionShape.Style.FillReference.StyleMatrixIndex = 0


        Dim offsetX As New Unit(1670858, UnitType.EnglishMetricUnit)
        Dim offsetY As New Unit(5145578, UnitType.EnglishMetricUnit)

        Dim extentsWidth As New Unit(5245331, UnitType.EnglishMetricUnit)
        Dim extentsHeight As New Unit(91440, UnitType.EnglishMetricUnit)

        Dim offset As New Independentsoft.Office.Drawing.Offset(offsetX, offsetY)
        Dim extents As New Independentsoft.Office.Drawing.Extents(extentsWidth, extentsHeight)

        connectionShape.ShapeProperties.Transform2D = New Independentsoft.Office.Drawing.Transform2D()
        connectionShape.ShapeProperties.Transform2D.Offset = offset
        connectionShape.ShapeProperties.Transform2D.Extents = extents

        Return connectionShape
    End Function

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
Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Drawing.Tables
Imports Independentsoft.Office.Presentation
Imports Independentsoft.Office.Presentation.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim presentation As New Presentation()

        Dim shapeTree As New GroupShape()
        shapeTree.ID = "1"
        shapeTree.Name = "ShapeTree"
        shapeTree.ShapeProperties.TransformGroup2D = New Independentsoft.Office.Drawing.TransformGroup2D()

        Dim offsetX As New Unit(2, UnitType.Inch)
        Dim offsetY As New Unit(1, UnitType.Inch)

        Dim width As New Unit(6, UnitType.Inch)
        Dim height As New Unit(2, UnitType.Inch)

        Dim picture As New Picture("c:\test\image1.png")
        picture.ID = "3"
        picture.Name = "Image1"
        picture.Stretch = New Independentsoft.Office.Drawing.Stretch()
        picture.Stretch.FillRectangle = New Independentsoft.Office.Drawing.FillRectangle()
        picture.Locking = New Independentsoft.Office.Drawing.PictureLocking()
        picture.Locking.DisallowAspectRatioChange = True
        picture.ShapeProperties.PresetGeometry = New Independentsoft.Office.Drawing.PresetGeometry(Independentsoft.Office.Drawing.ShapeType.Rectangle)

        picture.Name = "rappin.wav"
        picture.ID = "4"
        picture.WavAudioFile = New Independentsoft.Office.Drawing.WavAudioFile("c:\test\audio1.wav")
        picture.ClickHyperlink = New Independentsoft.Office.Drawing.ClickHyperlink()
        picture.ClickHyperlink.Action = "ppaction://media"

        Dim pictureWidth As New Unit(640, UnitType.Pixel)
        Dim pictureHeight As New Unit(480, UnitType.Pixel)

        Dim pictureOffsetX As New Unit(2, UnitType.Inch)
        Dim pictureOffsetY As New Unit(2, UnitType.Inch)

        Dim offset As New Independentsoft.Office.Drawing.Offset(pictureOffsetX, pictureOffsetY)
        Dim extents As New Independentsoft.Office.Drawing.Extents(pictureWidth, pictureHeight)

        picture.ShapeProperties.Transform2D = New Independentsoft.Office.Drawing.Transform2D()
        picture.ShapeProperties.Transform2D.Offset = offset
        picture.ShapeProperties.Transform2D.Extents = extents

        shapeTree.Elements.Add(picture)

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
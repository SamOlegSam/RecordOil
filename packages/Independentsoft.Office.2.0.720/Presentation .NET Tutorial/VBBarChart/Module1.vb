Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Drawing
Imports Independentsoft.Office.Charts
Imports Independentsoft.Office.Drawing
Imports Independentsoft.Office.Spreadsheet
Imports Independentsoft.Office.Presentation
Imports Independentsoft.Office.Presentation.Drawing

Module Module1
    Sub Main(ByVal args As String())

        Dim book As New Workbook()
        Dim sheet1 As New Worksheet()

        'set cell values
        sheet1("A2") = New Cell("Category 1")
        sheet1("A3") = New Cell("Category 2")
        sheet1("A4") = New Cell("Category 3")
        sheet1("A5") = New Cell("Category 4")

        sheet1("B1") = New Cell("Series 1")
        sheet1("B2") = New Cell(4.3)
        sheet1("B3") = New Cell(2.5)
        sheet1("B4") = New Cell(3.5)
        sheet1("B5") = New Cell(4.5)

        sheet1("C1") = New Cell("Series 2")
        sheet1("C2") = New Cell(2.4)
        sheet1("C3") = New Cell(4.4)
        sheet1("C4") = New Cell(1.8)
        sheet1("C5") = New Cell(2.8)

        sheet1("D1") = New Cell("Series 3")
        sheet1("D2") = New Cell(2)
        sheet1("D3") = New Cell(2)
        sheet1("D4") = New Cell(3)
        sheet1("D5") = New Cell(5)

        book.Sheets.Add(sheet1)

        'create Bar Chart
        Dim barChart As New BarChart()
        barChart.Direction = BarDirection.Column
        barChart.Grouping = BarGrouping.Clustered

        Dim serie1 As New BarChartSerie()
        serie1.Index = 0
        serie1.Order = 0

        serie1.SeriesText = New SeriesText()
        serie1.SeriesText.StringReference = New StringReference()
        serie1.SeriesText.StringReference.Formula = "Sheet1!$B$1"

        serie1.SeriesText.StringReference.StringCache = New StringCache()

        Dim seriesTextPoint11 As New StringPoint(0, "Series 1")
        serie1.SeriesText.StringReference.StringCache.StringPoints.Add(seriesTextPoint11)

        serie1.CategoryAxis = New CategoryAxis()
        serie1.CategoryAxis.StringReference = New StringReference()
        serie1.CategoryAxis.StringReference.Formula = "Sheet1!$A$2:$A$5"

        serie1.CategoryAxis.StringReference.StringCache = New StringCache()

        Dim categoryAxisPoint11 As New StringPoint(0, "Category 1")
        Dim categoryAxisPoint12 As New StringPoint(1, "Category 2")
        Dim categoryAxisPoint13 As New StringPoint(2, "Category 3")
        Dim categoryAxisPoint14 As New StringPoint(3, "Category 4")

        serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint11)
        serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint12)
        serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint13)
        serie1.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint14)

        serie1.Values = New Values()
        serie1.Values.NumberReference = New NumberReference()
        serie1.Values.NumberReference.Formula = "Sheet1!$B$2:$B$5"

        serie1.Values.NumberReference.NumberCache = New NumberCache()
        serie1.Values.NumberReference.NumberCache.Format = "General"

        Dim valuesPoint11 As New NumericPoint(0, "4.3")
        Dim valuesPoint12 As New NumericPoint(1, "2.5")
        Dim valuesPoint13 As New NumericPoint(2, "3.5")
        Dim valuesPoint14 As New NumericPoint(3, "4.5")

        serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint11)
        serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint12)
        serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint13)
        serie1.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint14)

        Dim serie2 As New BarChartSerie()
        serie2.Index = 1
        serie2.Order = 1

        serie2.SeriesText = New SeriesText()
        serie2.SeriesText.StringReference = New StringReference()
        serie2.SeriesText.StringReference.Formula = "Sheet1!$C$1"

        serie2.SeriesText.StringReference.StringCache = New StringCache()

        Dim seriesTextPoint21 As New StringPoint(0, "Series 2")
        serie2.SeriesText.StringReference.StringCache.StringPoints.Add(seriesTextPoint21)

        serie2.CategoryAxis = New CategoryAxis()
        serie2.CategoryAxis.StringReference = New StringReference()
        serie2.CategoryAxis.StringReference.Formula = "Sheet1!$A$2:$A$5"

        serie2.CategoryAxis.StringReference.StringCache = New StringCache()

        Dim categoryAxisPoint21 As New StringPoint(0, "Category 1")
        Dim categoryAxisPoint22 As New StringPoint(1, "Category 2")
        Dim categoryAxisPoint23 As New StringPoint(2, "Category 3")
        Dim categoryAxisPoint24 As New StringPoint(3, "Category 4")

        serie2.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint21)
        serie2.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint22)
        serie2.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint23)
        serie2.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint24)

        serie2.Values = New Values()
        serie2.Values.NumberReference = New NumberReference()
        serie2.Values.NumberReference.Formula = "Sheet1!$C$2:$C$5"

        serie2.Values.NumberReference.NumberCache = New NumberCache()
        serie2.Values.NumberReference.NumberCache.Format = "General"

        Dim valuesPoint21 As New NumericPoint(0, "2.4")
        Dim valuesPoint22 As New NumericPoint(1, "4.4")
        Dim valuesPoint23 As New NumericPoint(2, "1.8")
        Dim valuesPoint24 As New NumericPoint(3, "2.8")

        serie2.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint21)
        serie2.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint22)
        serie2.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint23)
        serie2.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint24)

        Dim serie3 As New BarChartSerie()
        serie3.Index = 2
        serie3.Order = 2

        serie3.SeriesText = New SeriesText()
        serie3.SeriesText.StringReference = New StringReference()
        serie3.SeriesText.StringReference.Formula = "Sheet1!$D$1"

        serie3.SeriesText.StringReference.StringCache = New StringCache()

        Dim seriesTextPoint31 As New StringPoint(0, "Series 3")
        serie3.SeriesText.StringReference.StringCache.StringPoints.Add(seriesTextPoint31)

        serie3.CategoryAxis = New CategoryAxis()
        serie3.CategoryAxis.StringReference = New StringReference()
        serie3.CategoryAxis.StringReference.Formula = "Sheet1!$A$2:$A$5"

        serie3.CategoryAxis.StringReference.StringCache = New StringCache()

        Dim categoryAxisPoint31 As New StringPoint(0, "Category 1")
        Dim categoryAxisPoint32 As New StringPoint(1, "Category 2")
        Dim categoryAxisPoint33 As New StringPoint(2, "Category 3")
        Dim categoryAxisPoint34 As New StringPoint(3, "Category 4")

        serie3.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint31)
        serie3.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint32)
        serie3.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint33)
        serie3.CategoryAxis.StringReference.StringCache.StringPoints.Add(categoryAxisPoint34)

        serie3.Values = New Values()
        serie3.Values.NumberReference = New NumberReference()
        serie3.Values.NumberReference.Formula = "Sheet1!$D$2:$D$5"

        serie3.Values.NumberReference.NumberCache = New NumberCache()
        serie3.Values.NumberReference.NumberCache.Format = "General"

        Dim valuesPoint31 As New NumericPoint(0, "2")
        Dim valuesPoint32 As New NumericPoint(1, "2")
        Dim valuesPoint33 As New NumericPoint(2, "3")
        Dim valuesPoint34 As New NumericPoint(3, "5")

        serie3.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint31)
        serie3.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint32)
        serie3.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint33)
        serie3.Values.NumberReference.NumberCache.NumericPoints.Add(valuesPoint34)

        barChart.Series.Add(serie1)
        barChart.Series.Add(serie2)
        barChart.Series.Add(serie3)

        barChart.FirstAxisID = 1
        barChart.SecondAxisID = 2

        'create ChartSpace object and add barChart to the chartSpace
        Dim chartSpace As New ChartSpace()
        chartSpace.ExternalData = book.GetBytes()
        chartSpace.ExternalDataFileName = "Workbook1.xlsx"
        chartSpace.PlotArea = New PlotArea()
        chartSpace.PlotArea.Layout = New Layout()
        chartSpace.PlotArea.Charts.Add(barChart)

        Dim chartCategoryAxis As New ChartCategoryAxis()
        chartCategoryAxis.ID = 1
        chartCategoryAxis.Scaling = New Scaling()
        chartCategoryAxis.Scaling.Orientation = Independentsoft.Office.Charts.Orientation.MinimumToMaximum
        chartCategoryAxis.Position = AxisPosition.Bottom
        chartCategoryAxis.TickLabelPosition = TickLabelPosition.NextTo
        chartCategoryAxis.CrossingAxisID = 2
        chartCategoryAxis.Crosses = Crosses.Zero
        chartCategoryAxis.Auto = True
        chartCategoryAxis.LabelAlignment = LabelAlignment.Center
        chartCategoryAxis.LabelOffset = 100

        Dim valueAxis As New ValueAxis()
        valueAxis.ID = 2
        valueAxis.Scaling = New Scaling()
        valueAxis.Scaling.Orientation = Independentsoft.Office.Charts.Orientation.MinimumToMaximum
        valueAxis.Position = AxisPosition.Left
        valueAxis.MajorGridlines = New MajorGridlines()
        valueAxis.NumberFormat = New NumberFormat()
        valueAxis.NumberFormat.Format = "General"
        valueAxis.NumberFormat.IsSourceLinked = True
        valueAxis.TickLabelPosition = TickLabelPosition.NextTo
        valueAxis.CrossingAxisID = 1
        valueAxis.Crosses = Crosses.Zero
        valueAxis.CrossBetween = CrossBetween.Between

        chartSpace.PlotArea.Axes.Add(chartCategoryAxis)
        chartSpace.PlotArea.Axes.Add(valueAxis)

        Dim legend As New Legend()
        legend.Position = LegendPosition.Right
        legend.Layout = New Layout()

        chartSpace.Legend = legend
        chartSpace.PlotVisibleOnly = True

        Dim chartWidth As New Unit(640, UnitType.Pixel)
        Dim chartHeight As New Unit(480, UnitType.Pixel)

        Dim offset As New Offset(0, 0)
        Dim extents As New Extents(chartWidth, chartHeight)

        Dim inline As New Inline(chartSpace)
        inline.Size = New DrawingObjectSize(chartWidth, chartHeight)
        inline.ID = "1"
        inline.Name = "Chart 1"
        inline.Description = "Chart description"

        Dim drawingObject As New DrawingObject(inline)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim presentation As New Presentation()

        Dim shapeTree As New Independentsoft.Office.Presentation.Drawing.GroupShape()
        shapeTree.ID = "1"
        shapeTree.Name = "ShapeTree"
        shapeTree.ShapeProperties.TransformGroup2D = New Independentsoft.Office.Drawing.TransformGroup2D()

        Dim graphicFrame As New Independentsoft.Office.Presentation.Drawing.GraphicFrame()
        graphicFrame.ID = "3"
        graphicFrame.Name = "Chart 1"
        graphicFrame.GraphicObject = chartSpace
        graphicFrame.Locking = New GraphicFrameLocking()

        graphicFrame.Transform2D = New Independentsoft.Office.Presentation.Drawing.Transform2D()
        graphicFrame.Transform2D.Extents = New Extents(6197600, 4165600)
        graphicFrame.Transform2D.Offset = New Offset(1473200, 1346200)

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
        Dim shapeTree As New Independentsoft.Office.Presentation.Drawing.GroupShape()
        shapeTree.ID = "1"
        shapeTree.Name = "layout"

        shapeTree.ShapeProperties.TransformGroup2D = New Independentsoft.Office.Drawing.TransformGroup2D()

        Dim commonSlideData As New CommonSlideData()
        commonSlideData.ShapeTree = shapeTree

        Return commonSlideData
    End Function

End Module
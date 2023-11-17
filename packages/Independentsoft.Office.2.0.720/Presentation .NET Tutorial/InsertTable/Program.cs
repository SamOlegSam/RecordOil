using System;
using Independentsoft.Office;
using Independentsoft.Office.Drawing.Tables;
using Independentsoft.Office.Presentation;
using Independentsoft.Office.Presentation.Drawing;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentation presentation = new Presentation();

            GroupShape shapeTree = new GroupShape();
            shapeTree.ID = "2";
            shapeTree.Name = "ShapeTree";
            shapeTree.ShapeProperties.TransformGroup2D = new Independentsoft.Office.Drawing.TransformGroup2D();

            Cell cell1 = new Cell();
            cell1.ShapeTextBody = new Independentsoft.Office.Drawing.ShapeTextBody();
            cell1.ShapeTextBody.TextListStyle = new Independentsoft.Office.Drawing.TextListStyle();

            Independentsoft.Office.Drawing.TextRun run1 = new Independentsoft.Office.Drawing.TextRun("Text 123");

            Independentsoft.Office.Drawing.TextParagraph paragraph1 = new Independentsoft.Office.Drawing.TextParagraph();
            paragraph1.Content.Add(run1);

            cell1.ShapeTextBody.Paragraphs.Add(paragraph1);

            Row row1 = new Row();
            row1.Height = new Unit(50, UnitType.Pixel);
            row1.Cells.Add(cell1);
            row1.Cells.Add(cell1);
            row1.Cells.Add(cell1);

            Table table = new Table();
            table.FirstRow = true;
            table.BandedRows = true;

            table.Grid = new TableGrid();
            table.Grid.Columns.Add(new TableGridColumn(1524000));
            table.Grid.Columns.Add(new TableGridColumn(1524000));
            table.Grid.Columns.Add(new TableGridColumn(1524000));

            table.Rows.Add(row1);

            Independentsoft.Office.Presentation.Drawing.GraphicFrame graphicFrame = new Independentsoft.Office.Presentation.Drawing.GraphicFrame();
            graphicFrame.ID = "3";
            graphicFrame.Name = "table 1";
            graphicFrame.GraphicObject = table;

            graphicFrame.Transform2D = new Independentsoft.Office.Presentation.Drawing.Transform2D();
            graphicFrame.Transform2D.Offset = new Independentsoft.Office.Drawing.Offset(1524000, 1397000);
            graphicFrame.Transform2D.Extents = new Independentsoft.Office.Drawing.Extents(6096000, 370840);

            shapeTree.Elements.Add(graphicFrame);

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.ShapeTree = shapeTree;

            SlideLayout layout1 = new SlideLayout();
            layout1.CommonSlideData = GetLayoutCommonSlideData();

            Slide slide1 = new Slide();
            slide1.CommonSlideData = commonSlideData;
            slide1.Layout = layout1;

            SlideMaster master1 = new SlideMaster();
            master1.CommonSlideData = GetLayoutCommonSlideData();
            master1.Layouts.Add(layout1);

            master1.TextStyles = new SlideMasterTextStyles();
            master1.TextStyles.TitleStyle = new SlideMasterTitleTextStyle();
            master1.TextStyles.TitleStyle.ListLevel1TextStyle.DefaultTextRunProperties.FontSize = 44;

            presentation.Slides.Add(slide1);
            presentation.SlideMasters.Add(master1);

            presentation.SlideSize = new SlideSize(9144000, 6858000, SlideSizeType.Screen4x3);
            presentation.NotesSlideSize = new NotesSlideSize(6858000, 9144000);

            presentation.Save("c:\\test\\output.pptx", true);

        }

        static CommonSlideData GetLayoutCommonSlideData()
        {
            GroupShape shapeTree = new GroupShape();
            shapeTree.ID = "1";
            shapeTree.Name = "layout";

            shapeTree.ShapeProperties.TransformGroup2D = new Independentsoft.Office.Drawing.TransformGroup2D();

            CommonSlideData commonSlideData = new CommonSlideData();
            commonSlideData.ShapeTree = shapeTree;

            return commonSlideData;
        }
    }
}

using System;
using Independentsoft.Office;
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
            shapeTree.ID = "1";
            shapeTree.Name = "ShapeTree";
            shapeTree.ShapeProperties.TransformGroup2D = new Independentsoft.Office.Drawing.TransformGroup2D();

            Independentsoft.Office.Drawing.TextRun run1 = new Independentsoft.Office.Drawing.TextRun("Hello World");

            Independentsoft.Office.Drawing.TextParagraph paragraph1 = new Independentsoft.Office.Drawing.TextParagraph();
            paragraph1.Alignment = Independentsoft.Office.Drawing.TextAlignmentType.Center;
            paragraph1.Content.Add(run1);

            ShapeTextBody textBody = new ShapeTextBody();
            textBody.Paragraphs.Add(paragraph1);

            Shape shape1 = new Shape();
            shape1.ID = "2";
            shape1.Name = "Title 1";
            shape1.Locking = new Independentsoft.Office.Drawing.ShapeLocking();
            shape1.Locking.DisallowGrouping = true;
            shape1.Placeholder = new Placeholder(PlaceholderType.CenteredTitle);
            shape1.TextBody = textBody;

            Unit offsetX = new Unit(2, UnitType.Inch);
            Unit offsetY = new Unit(1, UnitType.Inch);

            Unit width = new Unit(6, UnitType.Inch);
            Unit height = new Unit(2, UnitType.Inch);

            shape1.ShapeProperties.Transform2D = new Independentsoft.Office.Drawing.Transform2D();
            shape1.ShapeProperties.Transform2D.Offset = new Independentsoft.Office.Drawing.Offset(offsetX, offsetY);
            shape1.ShapeProperties.Transform2D.Extents = new Independentsoft.Office.Drawing.Extents(width, height);
            shape1.ShapeProperties.PresetGeometry = new Independentsoft.Office.Drawing.PresetGeometry(Independentsoft.Office.Drawing.ShapeType.Rectangle);

            shapeTree.Elements.Add(shape1);
            shapeTree.Elements.Add(GetLine());

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

        public static ConnectionShape GetLine()
        {
            ConnectionShape connectionShape = new ConnectionShape();
            connectionShape.ID = "5";
            connectionShape.Name = "Line1";

            connectionShape.ShapeProperties.PresetGeometry = new Independentsoft.Office.Drawing.PresetGeometry();
            connectionShape.ShapeProperties.PresetGeometry.ShapeType = Independentsoft.Office.Drawing.ShapeType.Line;

            connectionShape.Style = new ShapeStyle();

            connectionShape.Style.FontReference = new Independentsoft.Office.Drawing.FontReference();
            connectionShape.Style.FontReference.ColorChoice = new Independentsoft.Office.Drawing.SchemeColor(Independentsoft.Office.Drawing.SchemeColorValue.Text1);
            connectionShape.Style.FontReference.Index = Independentsoft.Office.Drawing.FontCollectionIndex.Minor;

            connectionShape.Style.LineReference = new Independentsoft.Office.Drawing.LineReference();
            connectionShape.Style.LineReference.StyleMatrixIndex = 1;
            connectionShape.Style.LineReference.ColorChoice = new Independentsoft.Office.Drawing.SchemeColor(Independentsoft.Office.Drawing.SchemeColorValue.Accent1);

            connectionShape.Style.EffectReference = new Independentsoft.Office.Drawing.EffectReference();
            connectionShape.Style.EffectReference.ColorChoice = new Independentsoft.Office.Drawing.SchemeColor(Independentsoft.Office.Drawing.SchemeColorValue.Accent1);
            connectionShape.Style.EffectReference.StyleMatrixIndex = 0;

            connectionShape.Style.FillReference = new Independentsoft.Office.Drawing.FillReference();
            connectionShape.Style.FillReference.ColorChoice = new Independentsoft.Office.Drawing.SchemeColor(Independentsoft.Office.Drawing.SchemeColorValue.Accent1);
            connectionShape.Style.FillReference.StyleMatrixIndex = 0;


            Unit offsetX = new Unit(1670858, UnitType.EnglishMetricUnit);
            Unit offsetY = new Unit(5145578, UnitType.EnglishMetricUnit);

            Unit extentsWidth = new Unit(5245331, UnitType.EnglishMetricUnit);
            Unit extentsHeight = new Unit(91440, UnitType.EnglishMetricUnit);

            Independentsoft.Office.Drawing.Offset offset = new Independentsoft.Office.Drawing.Offset(offsetX, offsetY);
            Independentsoft.Office.Drawing.Extents extents = new Independentsoft.Office.Drawing.Extents(extentsWidth, extentsHeight);

            connectionShape.ShapeProperties.Transform2D = new Independentsoft.Office.Drawing.Transform2D();
            connectionShape.ShapeProperties.Transform2D.Offset = offset;
            connectionShape.ShapeProperties.Transform2D.Extents = extents;

            return connectionShape;
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
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

            Independentsoft.Office.Drawing.TextRun run1 = new Independentsoft.Office.Drawing.TextRun("Hello ");
            Independentsoft.Office.Drawing.TextRun run2 = new Independentsoft.Office.Drawing.TextRun("World");
            run2.Baseline = 30000; //superscript. Offset is 30%. If you need subscript then use value -30000

            Independentsoft.Office.Drawing.TextParagraph paragraph1 = new Independentsoft.Office.Drawing.TextParagraph();
            paragraph1.Alignment = Independentsoft.Office.Drawing.TextAlignmentType.Center;
            paragraph1.Content.Add(run1);
            paragraph1.Content.Add(run2);

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

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

            Unit offsetX = new Unit(2, UnitType.Inch);
            Unit offsetY = new Unit(1, UnitType.Inch);

            Unit width = new Unit(6, UnitType.Inch);
            Unit height = new Unit(2, UnitType.Inch);

            Picture picture = new Picture("c:\\test\\image1.png");
            picture.ID = "3";
            picture.Name = "Image1";
            picture.Stretch = new Independentsoft.Office.Drawing.Stretch();
            picture.Stretch.FillRectangle = new Independentsoft.Office.Drawing.FillRectangle();
            picture.Locking = new Independentsoft.Office.Drawing.PictureLocking();
            picture.Locking.DisallowAspectRatioChange = true;
            picture.ShapeProperties.PresetGeometry = new Independentsoft.Office.Drawing.PresetGeometry(Independentsoft.Office.Drawing.ShapeType.Rectangle);

            picture.Name = "rappin.wav";
            picture.ID = "4";
            picture.WavAudioFile = new Independentsoft.Office.Drawing.WavAudioFile("c:\\test\\audio1.wav");
            picture.ClickHyperlink = new Independentsoft.Office.Drawing.ClickHyperlink();
            picture.ClickHyperlink.Action = "ppaction://media";

            Unit pictureWidth = new Unit(640, UnitType.Pixel);
            Unit pictureHeight = new Unit(480, UnitType.Pixel);

            Unit pictureOffsetX = new Unit(2, UnitType.Inch);
            Unit pictureOffsetY = new Unit(2, UnitType.Inch);

            Independentsoft.Office.Drawing.Offset offset = new Independentsoft.Office.Drawing.Offset(pictureOffsetX, pictureOffsetY);
            Independentsoft.Office.Drawing.Extents extents = new Independentsoft.Office.Drawing.Extents(pictureWidth, pictureHeight);

            picture.ShapeProperties.Transform2D = new Independentsoft.Office.Drawing.Transform2D();
            picture.ShapeProperties.Transform2D.Offset = offset;
            picture.ShapeProperties.Transform2D.Extents = extents;

            shapeTree.Elements.Add(picture);

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

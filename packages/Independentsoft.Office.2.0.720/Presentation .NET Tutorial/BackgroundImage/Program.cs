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
            
            SlideLayout layout1 = new SlideLayout();
            layout1.CommonSlideData = GetLayoutCommonSlideData();
            
            SlideMaster master1 = new SlideMaster();
            master1.CommonSlideData = GetLayoutCommonSlideData();
            master1.Layouts.Add(layout1);

            master1.TextStyles = new SlideMasterTextStyles();
            master1.TextStyles.TitleStyle = new SlideMasterTitleTextStyle();
            master1.TextStyles.TitleStyle.ListLevel1TextStyle.DefaultTextRunProperties.FontSize = 44;

            presentation.SlideMasters.Add(master1);

            presentation.SlideSize = new SlideSize(9144000, 6858000, SlideSizeType.Screen4x3);
            presentation.NotesSlideSize = new NotesSlideSize(6858000, 9144000);

            for (int i = 1; i <= 5; i++)
            {
                GroupShape shapeTree = new GroupShape();
                shapeTree.ID = i.ToString();
                shapeTree.Name = "ShapeTree";
                shapeTree.ShapeProperties.TransformGroup2D = new Independentsoft.Office.Drawing.TransformGroup2D();

                Picture picture = new Picture("c:\\test\\image1.png");
                picture.ID = (3 + i).ToString();
                picture.Name = "Image" + i;
                picture.Stretch = new Independentsoft.Office.Drawing.Stretch();
                picture.Stretch.FillRectangle = new Independentsoft.Office.Drawing.FillRectangle();
                picture.Locking = new Independentsoft.Office.Drawing.PictureLocking();
                picture.Locking.DisallowGrouping = true;
                picture.ShapeProperties.PresetGeometry = new Independentsoft.Office.Drawing.PresetGeometry(Independentsoft.Office.Drawing.ShapeType.Rectangle);

                Unit pictureWidth = new Unit(800, UnitType.Pixel);
				Unit pictureHeight = new Unit(600, UnitType.Pixel);
				
				Unit pictureOffsetX = new Unit(1, UnitType.Inch);
                Unit pictureOffsetY = new Unit(1, UnitType.Inch);

                picture.ShapeProperties.Transform2D = new Independentsoft.Office.Drawing.Transform2D();
                picture.ShapeProperties.Transform2D.Offset = new Independentsoft.Office.Drawing.Offset(pictureOffsetX, pictureOffsetY);
                picture.ShapeProperties.Transform2D.Extents = new Independentsoft.Office.Drawing.Extents(pictureWidth, pictureHeight);

                shapeTree.Elements.Add(picture);

                CommonSlideData commonSlideData = new CommonSlideData();
                commonSlideData.ShapeTree = shapeTree;

                Slide slide1 = new Slide();
                slide1.CommonSlideData = commonSlideData;
                slide1.Layout = layout1;

                presentation.Slides.Add(slide1);
            }

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

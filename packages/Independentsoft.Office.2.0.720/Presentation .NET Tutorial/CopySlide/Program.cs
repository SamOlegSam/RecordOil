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
            Presentation input = new Presentation("c:\\test\\input.pptx");
            Presentation output = new Presentation();

            Slide slide1 = input.Slides[0];
            SlideMaster master1 = null;

            //find master
            foreach (SlideMaster currentMaster in input.SlideMasters)
            {
                if (currentMaster.Layouts.Contains(slide1.Layout))
                {
                    master1 = currentMaster;
                }
            }

            output.Slides.Add(slide1);
            output.SlideMasters.Add(master1);

            output.SlideSize = new SlideSize(9144000, 6858000, SlideSizeType.Screen4x3);
            output.NotesSlideSize = new NotesSlideSize(6858000, 9144000);

            output.Save("c:\\test\\output.pptx", true);

        }
    }
}

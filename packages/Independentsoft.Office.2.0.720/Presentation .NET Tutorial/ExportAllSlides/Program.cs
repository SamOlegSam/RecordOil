using System;
using System.IO;
using Independentsoft.Office.Presentation;
using Independentsoft.Office.Presentation.Drawing;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentation presentation = new Presentation("c:\\test\\input.pptx");

            for (int i=0; i < presentation.Slides.Count; i++)
            {
                Slide slide = presentation.Slides[i];

                DirectoryInfo slideFolder = System.IO.Directory.CreateDirectory("c:\\test\\Slide" + (i + 1));
                string slideText = "";

                if (slide.CommonSlideData != null)
                {
                    GroupShape shapeTree = slide.CommonSlideData.ShapeTree;

                    if(shapeTree != null)
                    {
                        foreach (IGroupElement element in shapeTree.Elements)
                        {
                            if (element is Picture)
                            {
                                Picture picture = (Picture)element;

                                picture.Save(slideFolder.FullName + "\\" + picture.FileName, true);
                            }
                            else if (element is Shape)
                            {
                                Shape shape = (Shape)element;

                                if (shape.TextBody != null)
                                {
                                    ShapeTextBody textBody = shape.TextBody;

                                    for (int p = 0; p < textBody.Paragraphs.Count; p++)
                                    {
                                        Independentsoft.Office.Drawing.TextParagraph paragraph = textBody.Paragraphs[p];

                                        for (int r = 0; r < paragraph.Content.Count; r++)
                                        {
                                            if (paragraph.Content[r] is Independentsoft.Office.Drawing.TextRun)
                                            {
                                                Independentsoft.Office.Drawing.TextRun run = (Independentsoft.Office.Drawing.TextRun)paragraph.Content[r];
                                                slideText += run.Text;
                                            }
                                        }

                                        slideText += "\r\n";
                                    }
                                }
                            }
                        }
                    }
                }

                StreamWriter writer = File.CreateText(slideFolder.FullName + "\\text.txt");
                writer.Write(slideText);
                writer.Close();
            }
        }
    }
}
 
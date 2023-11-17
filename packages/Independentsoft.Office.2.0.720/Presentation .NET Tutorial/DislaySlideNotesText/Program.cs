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
            Presentation presentation = new Presentation("c:\\test\\input.pptx");

            foreach (Slide slide in presentation.Slides) 
			{
				if (slide.NotesSlide != null && slide.NotesSlide.CommonSlideData != null) 
				{
					CommonSlideData data = slide.NotesSlide.CommonSlideData;

                    foreach (Independentsoft.Office.Presentation.Drawing.IGroupElement elemente in data.ShapeTree.Elements) 
					{
                        if (elemente is Independentsoft.Office.Presentation.Drawing.Shape) 
						{
                            Independentsoft.Office.Presentation.Drawing.Shape shape = (Independentsoft.Office.Presentation.Drawing.Shape)elemente;

							if (shape.TextBody != null) 
							{
                                foreach (Independentsoft.Office.Drawing.TextParagraph paragraph in shape.TextBody.Paragraphs) 
								{
                                    foreach (Independentsoft.Office.Drawing.ITextParagraphContent content in paragraph.Content) 
									{
                                        if (content is Independentsoft.Office.Drawing.TextRun) 
										{
                                            Independentsoft.Office.Drawing.TextRun run = (Independentsoft.Office.Drawing.TextRun)content;

											Console.WriteLine(run.Text);
										}
									}
								}
							}
						}
					}
				}
			}

            Console.Read();
        }
    }
}

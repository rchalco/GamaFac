﻿using Business.Main.Base;
using Domain.Main.MicroVentas.Impresion;
using Domain.Main.Wraper;
using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Layout;
using iText.Layout.Properties;
using iText.Layout.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main.Managers
{
    public class MangerPrinter : BaseManager
    {
        public Response GenerarDocumento(DataDocumento dataDocumento)
        {
            Response response = new Response();
            try
            {
                Table table = new Table(1, false);
                table.SetMinWidth(290f);
                table.SetMaxWidth(290f);
                table.SetMargins(0, 0, 0, 0);
                table.SetBorder(Border.NO_BORDER);

                string pathLogo = string.IsNullOrEmpty(dataDocumento.pathLogo) ? @"c:\fonts\Logo.jpg" : dataDocumento.pathLogo;
                Image img = new Image(ImageDataFactory
               .Create(pathLogo))
               .SetHeight(60)
               .SetWidth(150)
               .SetTextAlignment(TextAlignment.CENTER);
                Cell cellContent = new Cell(1, 1);
                cellContent.Add(img);
                cellContent.SetBorder(Border.NO_BORDER);
                table.AddCell(cellContent);

                FontProgram fontProgram = FontProgramFactory.CreateFont(@"c:\fonts\arial.ttf");
                PdfFont fuenteExterna = PdfFontFactory.CreateFont(fontProgram, PdfEncodings.WINANSI);

                Text text = new Text(dataDocumento.titulo)
                    .SetFont(fuenteExterna)
                    .SetBold();

                Paragraph subheader = new Paragraph(text)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetFontSize(14);
                cellContent = new Cell(2, 1);
                cellContent.Add(subheader);
                cellContent.SetBorder(Border.NO_BORDER);
                table.AddCell(cellContent);

                LineSeparator lineSeparator = new LineSeparator(new SolidLine());
                cellContent = new Cell(3, 1);
                cellContent.Add(lineSeparator);
                cellContent.SetBorder(Border.NO_BORDER);
                table.AddCell(cellContent);

                #region  para hacer tablas
                //// Table
                //Table table = new Table(2, false);
                //table.SetWidth(520);
                //table.SetTextAlignment(TextAlignment.CENTER);
                //Cell cell11 = new Cell(1, 1)
                //   .SetBackgroundColor(ColorConstants.GRAY)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("Concepto"));
                //Cell cell12 = new Cell(1, 1)
                //   .SetBackgroundColor(ColorConstants.GRAY)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("Costo"));

                //Cell cell21 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("Concepto 1"));
                //Cell cell22 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("10"));

                //Cell cell31 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("Concepto 2"));
                //Cell cell32 = new Cell(1, 1)
                //   .SetTextAlignment(TextAlignment.CENTER)
                //   .Add(new Paragraph("20"));

                //table.AddCell(cell11);
                //table.AddCell(cell12);
                //table.AddCell(cell21);
                //table.AddCell(cell22);
                //table.AddCell(cell31);
                //table.AddCell(cell32);

                //document.Add(table); 
                #endregion

                int i = 4;
                dataDocumento.contenido.ForEach(contenido =>
                {
                    Text text = new Text(contenido)
                    .SetFont(fuenteExterna);
                    Paragraph pContenido = new Paragraph(text)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetFontSize(10);
                    cellContent = new Cell(i, 1);
                    cellContent.Add(pContenido);
                    cellContent.SetBorder(Border.NO_BORDER);
                    table.AddCell(cellContent);
                    i++;
                });

                Paragraph leyenda = new Paragraph(dataDocumento.pie)
                   .SetTextAlignment(TextAlignment.LEFT)
                   .SetFontSize(8);
                cellContent = new Cell(i, 1);
                cellContent.Add(leyenda);
                cellContent.SetBorder(Border.NO_BORDER);
                table.AddCell(cellContent);

                table.IsComplete();
                table.SetFixedLayout();
                string fileName = "c:\\documentosGMF\\" + Guid.NewGuid() + ".pdf";
                PdfWriter writer = new PdfWriter(fileName);
                PdfDocument pdf = new PdfDocument(writer);

                Document documentAux = new Document(pdf);

                float necessaryWidth = 300f;
                IRenderer tableRenderer = table.CreateRendererSubTree().SetParent(documentAux.GetRenderer());
                LayoutResult tableLayoutResult = tableRenderer.Layout(new LayoutContext(new LayoutArea(0, new Rectangle(necessaryWidth, 1000))));
                float tableHeightTotal = tableLayoutResult.GetOccupiedArea().GetBBox().GetHeight();


                PageSize pageSize = new PageSize(300f, tableHeightTotal);
                Document document = new Document(pdf, pageSize);
                document.SetMargins(0, 0, 0, 0);
                document.Add(table);
                document.Close();
                documentAux.Close();

                response.State = ResponseType.Success;
                response.Message = fileName;
            }
            catch (Exception ex)
            {
                ProcessError(ex, response);
            }
            return response;
        }
    }
}

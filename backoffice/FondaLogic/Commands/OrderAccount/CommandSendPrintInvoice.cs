﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandSendPrintInvoice
    {
        public void Get()
        {
            Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                Phrase phrase = null;
                PdfPCell cell = null;
                PdfPTable table = null;




                document.Add(table);
                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Employee.pdf");
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.BinaryWrite(bytes);
                HttpContext.Current.Response.End();
                HttpContext.Current.Response.Close();

            }

        }
 
    }
}

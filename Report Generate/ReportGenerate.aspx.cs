using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace Report_Generate
{
    public partial class ReportGenerate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                SqlConnection con = new SqlConnection(CS);
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Employees", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ReportList.DataSource = ds;
                    ReportList.DataBind();
                }
            }
        }

        protected void generateExcel_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Employees.xls");
            Response.ContentType = "application/excel";

            System.IO.StringWriter stringWriter = new System.IO.StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);

            ReportList.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void generatePdf_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(ReportList.HeaderRow.Cells.Count);
            foreach (TableCell gridViewHeaderCell in ReportList.HeaderRow.Cells)
            {

                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text));

                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in ReportList.Rows)
            {

                foreach (TableCell gridViewCell in gridViewRow.Cells)
                {

                    PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text));
                    pdfTable.AddCell(pdfCell);
                }
            }

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Employees.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }
    }
}

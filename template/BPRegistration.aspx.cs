using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class BPRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void SendMail()
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("mudrameri@gmail.com");

            mail.From = new MailAddress("newleadgenerated@gmail.com");
            mail.Subject = "New BP Registration For MM";
            string Body = "Name:-" + txtBPName.Text + Environment.NewLine + "Mobile:-" + txtBPNumber.Text + Environment.NewLine + "Email:-" + txtBPEmail.Text + Environment.NewLine + "PAN:-" + txtBPPAN.Text + Environment.NewLine + "Aadhar:-" + txtBPAadhar.Text + Environment.NewLine + "Company:-" + txtBPCompany.Text + Environment.NewLine + "City:-" + txtBPCity.Text;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("newleadgenerated@gmail.com", "@789!@emw!");

            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
            lblMsg.Text = "MMBP Registration Successful.";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


    protected void btnBPSubmit_Click(object sender, EventArgs e)
    {
        SendMail();
    }

}
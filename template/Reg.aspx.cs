using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class reg : System.Web.UI.Page
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
            mail.Subject = "New Lead For MM";
            string Body = "Name:-"+ txtName.Text + Environment.NewLine + "Mobile:-"+txtNumber.Text + Environment.NewLine + "Email:-" + txtEmail.Text + Environment.NewLine + "Salary:-" + txtSalary.Text + Environment.NewLine + "City:-" + txtCity.Text + Environment.NewLine + "Company:-" + txtCompany.Text + Environment.NewLine + "Product Name:-" + ddlProducts.SelectedItem.Text + Environment.NewLine + "Bank Name:-" + ddlBanks.SelectedItem.Text + Environment.NewLine + "Loan Type:-" + ddlLoanType.SelectedItem.Text;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "relay-hosting.secureserver.net"; //Or Your SMTP Server Address ////"smtp.gmail.com"; //Or Your SMTP Server Address relay-hosting.secureserver.net port number 25 authorization false
            smtp.Port = 25;  //587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            ("newleadgenerated@gmail.com", "@789!@emw!");

            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
            lblMsg.Text = "Registration Successful";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SendMail();
    }

    protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlBanks.Items.Clear();
        if (ddlProducts.SelectedItem.Value == "1")
        {
            ddlBanks.Items.Insert(0, new ListItem("Add New", "1"));
            ddlBanks.Items.Insert(0, new ListItem("HDFC", "2"));


        }
    }
}
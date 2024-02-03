using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages
{
    public class ContactModel : PageModel
    { 
        /*binding the controller to the contact form model*/

        [BindProperty]
        public ContactFormModel Contact { get; set; }

        /*creating a new instance of contactFormModel*/
        public void OnGet()
        {

            Contact = new ContactFormModel();
            Contact.Message = "Enter your message here:";
            Contact.Name = "Your name";
            Contact.LastName = "your last name";
            Contact.Email = "email@gmail.com";
        }

        /*Post request to the mailing server*/

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mailbody = $@"Hallo Website owner,
            This is a new contact request from your website:
            Name: {Contact.Name}
            LastName: {Contact.LastName}
            Message: ""{Contact.Message}""

            Cheers, 
            The website Contact form";

            var confirmationBody = $@"Hallo dear user,

            We received your email and will get back to you shortly. 
            Thank you for contacting us.
            Zillo team.";

            SendMail(mailbody);

            ConfirmationEmail(confirmationBody);

            Contact = new ContactFormModel();
            Contact.Message = Request.Form[nameof(Contact.Message)];
            return RedirectToPage("Index");

        }


        
        private void SendMail(string mailbody)
        {

            /*Creating custom email*/
            var message = new MailMessage();
            message.To.Add(new MailAddress("zillocontactformrecipient@gmail.com"));
            //password: P@55w0rd-1
            message.From = new MailAddress("antonio30167826@outlook.com");
            message.Subject = "New E-mail from my website";
            message.Body = mailbody;

            /*Creating a new instance of SmtpClient and adding the required properties and variables*/

            SmtpClient client = new SmtpClient();

            client.Host = "smtp-mail.outlook.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;


            System.Net.NetworkCredential userpass = new System.Net.NetworkCredential();

            userpass.UserName = "Antonio30167826@outlook.com";
            userpass.Password = "P@55w0rdzillo";

            client.Credentials = userpass;

            client.Send(message);


        }

        /*Creating a confirmation email, following the same procces as before*/

        private void ConfirmationEmail(string confirmationBody)
        {

            var message = new MailMessage();
            message.To.Add(Contact.Email);
            message.From = new MailAddress("antonio30167826@outlook.com");
            message.Subject = "Email received!";
            message.Body = confirmationBody;

            SmtpClient client = new SmtpClient();

            client.Host = "smtp-mail.outlook.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;


            System.Net.NetworkCredential userpass = new System.Net.NetworkCredential();

            userpass.UserName = "Antonio30167826@outlook.com";
            userpass.Password = "P@55w0rdzillo";

            client.Credentials = userpass;

            client.Send(message);


        }




    }
}

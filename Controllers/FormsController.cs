using System.Net;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using ocian_net.Controllers.DTO;
using ocian_net.Data;
using ocian_net.Models;

namespace ocian_net.Controllers
{   
    [ApiController]
    [Route("api/")]
    public class FormsController : ControllerBase
    {
        [HttpPost("send_proposal")]
        public async Task<IActionResult> Proposal(AppDbContext _context, FormProposal input, CancellationToken ct)
        {
            var newForm = new FormProposalDTO(input);
            await _context.FormProposal.AddAsync(newForm.Form, ct);
            await _context.SaveChangesAsync(ct);

            return Ok(newForm.Form);
        }


        [HttpPost("send_support")]
        public async Task<IActionResult> Support(AppDbContext _context, FormSupport input, CancellationToken ct)
        {
            var newForm = new FormSupportDTO(input);
            await _context.FormSupport.AddAsync(newForm.Form, ct);
            await _context.SaveChangesAsync(ct);

            return Ok(newForm.Form);
        }

        [HttpPost("send_contact_us")]
        public async Task<IActionResult> ContactUs(AppDbContext _context, FormContactUs input, CancellationToken ct)
        {
            var newForm = new FormContactUsDTO(input);
            await _context.FormContactUs.AddAsync(newForm.Form, ct);
            await _context.SaveChangesAsync(ct);

            return Ok(newForm.Form);
        }

        [HttpPost("work_with_us")]
        public async Task<IActionResult> WorkWithUs([FromForm] FormWorkWithUs form)
        {
            DotEnv dotEnv = new DotEnv();
            
            if (form.File == null || form.File.Length <= 0)
            {
                return BadRequest("No file was uploaded");
            }

            string folder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string filepath = Path.Combine(folder, form.File.FileName);

            using (var fileStream = new FileStream(filepath, FileMode.Create))
            {
                await form.File.CopyToAsync(fileStream);
            }
            
            var filetype = form.File.ContentType;
            if ((filetype != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") && 
                (filetype != "application/pdf") && 
                (filetype != "application/msword") &&
                (filetype != "application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
            {
                return BadRequest("The file format is unsupported!");
            }

            SmtpClient client = new SmtpClient();
            NetworkCredential credential = new NetworkCredential();
            credential.UserName = dotEnv.USERNAME;
            credential.Password = dotEnv.PASSWORD;
            client.Connect(dotEnv.HOST, 587);
            client.Authenticate(SaslMechanismLogin.Create("PLAIN", credential));

            var message = new MimeMessage();
            var mailbox = new MailboxAddress (null, dotEnv.EMAIL);
            message.From.Add(mailbox);
            message.To.Add(mailbox);
            message.Subject = "Trabalhe Conosco - Formulário";

            var builder = new BodyBuilder();
            builder.TextBody = 
            $"Nome: {form.Name}\nEmail: {form.Email}\nTel.: {form.Phone}\nAssunto: {form.Subject}\nMensagem: {form.Message}";

            var namefile = $"{Path.GetTempFileName()}-{form.File.FileName}";
            builder.Attachments.Add(namefile, form.File.OpenReadStream());

            message.Body = builder.ToMessageBody();
            await client.SendAsync(message);

            return Ok("File uploaded successfully!");
        }


    }
    
}
using ArabaSatisSitesi.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace ArabaSatisSitesi.Pages
{
    public class Message
    {
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
        public string ContactMessage { get; set; }
        public string ContactID { get; set; }
    }

    public class MessagesModel : PageModel
    {
        public List<Message> MessagesList { get; set; }

        public void OnGet()
        {
            SqlCommand commandList = new SqlCommand("Select * from TableContact", SqlConnectionClass.connection);

            SqlConnectionClass.CheckConnection();

            var messages = new List<Message>();
            using (var reader = commandList.ExecuteReader())
            {
                while (reader.Read())
                {
                    messages.Add(new Message
                    {
                        ContactName = reader["ContactName"].ToString(),
                        ContactMail = reader["ContactMail"].ToString(),
                        ContactMessage = reader["ContactMessage"].ToString(),
                        ContactID = reader["ContactID"].ToString()
                    });
                }
            }
            MessagesList = messages;

        }
    }
}

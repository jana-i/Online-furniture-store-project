using EShopAdminApp.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Security;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EShopAdminApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportUsers(IFormFile file)
        {
            //make a copy
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\file\\{file.FileName}";

            using(FileStream fileStream  = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);

                fileStream.Flush(); //prepokrivanje
            }
            //read data from file

            List<User> users = getAllUsersFromFile(file.FileName);

            HttpClient client = new HttpClient();

            string URI = "https://localhost:44386/api/Admin/ImportAllUsers";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(users), Encoding.UTF8, "application/json");


            HttpResponseMessage responseMessage = client.PostAsync(URI, content).Result;

            var data = responseMessage.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index","Order");
        }

        private List<User> getAllUsersFromFile(string fileName)
        {
            List<User> users = new List<User>();

            string filePath = $"{Directory.GetCurrentDirectory()}\\file\\{fileName}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using(var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new Models.User
                        {
                            Name = reader.GetValue(0).ToString(),
                            LastName = reader.GetValue(1).ToString(),
                            Email = reader.GetValue(2).ToString(),
                            Password = reader.GetValue(3).ToString(),
                            ConfirmPassword = reader.GetValue(4).ToString(),
                            PhoneNumber = reader.GetValue(5).ToString()
                        });
                    }
                }
            }

            return users;
        }
    }
}

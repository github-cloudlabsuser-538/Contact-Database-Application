using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            // Retrieve the user from the userlist based on the provided ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, return the Details view with the user object
            if (user != null)
            {
                return View(user);
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            // Implement the Create method here
            return View();
        }


        private int GetNextUserId()
        {
            // If the userlist is empty, start the ID from 1
            if (userlist.Count == 0)
            {
                return 1;
            }

            // Find the maximum ID in the userlist
            int maxId = userlist.Max(u => u.Id);

            // Increment the maximum ID by 1 to get the next ID
            return maxId + 1;
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Generate a new user ID
            user.Id = GetNextUserId();

            // Implement the Create method (POST) here
            // Add the user to the userlist
            userlist.Add(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            // Retrieve the user from the userlist based on the provided ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, return the Edit view with the user object
            if (user != null)
            {
                return View(user);
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            // Retrieve the user from the userlist based on the provided ID
            User existingUser = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, update the user's information
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // Retrieve the user from the userlist based on the provided ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, return the Delete view with the user object
            if (user != null)
            {
                return View(user);
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            // Retrieve the user from the userlist based on the provided ID
            User user = userlist.FirstOrDefault(u => u.Id == id);

            // If user is found, remove the user from the userlist
            if (user != null)
            {
                userlist.Remove(user);

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }

            // If user is not found, return HttpNotFoundResult
            return HttpNotFound();
        }
    }
}

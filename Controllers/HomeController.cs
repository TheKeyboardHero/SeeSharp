using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltcSharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace BeltcSharp.Controllers
{
    public class HomeController : Controller
    {
        private UsersContext _context;

        public HomeController(UsersContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Landing")]
        public IActionResult Landing()
        {
            // int? means number or null
            //    V is the variable             Vpulls the user's id in session from DB to store it in CreatedByID
            int? CreatedByID = HttpContext.Session.GetInt32("idUsers");
            //  if not logged in or null redirects to login page
                if(CreatedByID == null){
                    return RedirectToAction("Index");
                }
        //    makes a list of all Activity
            List<CreateActivities> list = _context.Activities.ToList();
            return View("Landing", list);
        }


        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(Users NewUser)
        {       
             
                TryValidateModel(NewUser);
                ViewBag.error = ModelState.Values;
                
                if(ModelState.IsValid){
                    // trying to hash password
                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                    _context.Add(NewUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("idUsers", NewUser.idUsers);
                return RedirectToAction("Landing");
                }
                else
                {
                    return View("Index");
                }
        }

        
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            //                                                     V user that has email that matches the == email
            Users ReturnedValue = _context.Users.SingleOrDefault(user => user.Email == email);
//                 ^variable name      ^looks at db using context in users for single or null
            if(ReturnedValue == null){
                return View("Index");
            }
            if(email == null || password == null){
                return View("Index");
            }
            // Trying to pull back the hashed password????
            if(ReturnedValue.Email != email){
                
                if(ReturnedValue.Password != password){
                    return View("Index");
            }
            }
            
            if(ReturnedValue != null && password != null)
            {
                var Hasher = new PasswordHasher<Users>();
                // Pass the user object, the hashed password, and the PasswordToCheck
                if(0 != Hasher.VerifyHashedPassword(ReturnedValue, ReturnedValue.Password, password))
                {
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("idUsers",ReturnedValue.idUsers);
                    return RedirectToAction("Landing");
                } 

        // !!!!need something with sessions!!!!
            }
            return View("Index");
        }


        [HttpGet]
        [Route("CreateNewActivity")]
        public IActionResult CreateNew(Users NewUser)
        {
            int? CreatedByID  = HttpContext.Session.GetInt32("idUsers");
                if(CreatedByID == null){
                    return RedirectToAction("Index");}
            return View("CreateNewActivity");
        }
        

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("NewActivity")]
        public IActionResult SubmitActivity(CreateActivities NewCreateActivities)
    
        {       
            int? CreatedByID  = HttpContext.Session.GetInt32("idUsers");
                if(CreatedByID == null){
                    return RedirectToAction("Index");
                }
            int CreatedByIDasInt = (int)CreatedByID;
            NewCreateActivities.CreatedByID  = CreatedByIDasInt;

                TryValidateModel(NewCreateActivities);
                ViewBag.error = ModelState.Values;

                if(ModelState.IsValid){
                    _context.Add(NewCreateActivities);

                    _context.SaveChanges();
                return RedirectToAction("Landing");
                }
                else
                {
                    return View("CreateNewActivity");
                }
        }

        
        [HttpPost]
        [Route("Attend")]
        public IActionResult Attend(int ActivityId)
        {
            int? CurrentUserID = HttpContext.Session.GetInt32("idUsers");
            Attendees AttendingUser = new Attendees {
                CreateActivities_idActivities = ActivityId,
                Users_idUsers = (int)CurrentUserID
            };
            //loop through the attendee list
            
            //check the user id in each attendee object
            //if the session user is there, redirect/show error
            foreach(var attendee in _context.Attendees){
                // HttpContext.Session.SetInt32("idUsers", NewUser.idUsers);
                if( attendee.Users_idUsers == CurrentUserID){
                // int (CurrentUserID)){
                return RedirectToAction("Landing");
                }
            }
            _context.Attendees.Add(AttendingUser);
            _context.SaveChanges();
            // so something to allow attendee ID to be created 
            // and link w/ user in session
            return RedirectToAction("Landing");

        }

        [HttpPost]
        [Route("CancelAttend")]
        public IActionResult CancelAttend(int ActivityId)
        {
            int? CurrentUserID = HttpContext.Session.GetInt32("idUsers");
            Attendees ReturnedValues = _context.Attendees.Where(g => g.Users_idUsers == (int)CurrentUserID && g.CreateActivities_idActivities == ActivityId).SingleOrDefault();

                if( ReturnedValues == null){
                    return View("Landing");
                }
                _context.Attendees.Remove(ReturnedValues);
                _context.SaveChanges();
                return RedirectToAction("Landing");
                }
            // so something to allow attendee ID to be Destroyed
            // and link w/ user in session
            // something to only view button if already attendin
    



        [HttpPost]
        [Route("CancelActivity")]
        public IActionResult CancelActivity(int ActivityId)
        {
            int? CurrentUserID = HttpContext.Session.GetInt32("idUsers");
            CreateActivities ReturnedActivity = _context.Activities.Where(g => g.CreatedByID == (int)CurrentUserID && g.idActivity == ActivityId).SingleOrDefault();
                _context.Remove(ReturnedActivity);
                _context.SaveChanges();
                return RedirectToAction("Landing");
                
                // ADD IF STATEMENT WHERE IF I DIDNT MAKE IT I CAN'T DELETE IT *IS THROWING ERROR
        }
        [HttpPost]
        [Route("Dashboard")]
        public IActionResult Dashboard(int ActivityId)
        {
            int? CreatedByID  = HttpContext.Session.GetInt32("idUsers");
                if(CreatedByID == null){
                    return RedirectToAction("Index");}
            CreateActivities ShowActivity = _context.Activities.Where(g => g.idActivity == ActivityId).SingleOrDefault();
            List<Attendees> ReturnedValues = _context.Attendees.Where(g => g.ActivityBeingAttended.idActivity == ActivityId).ToList();
            ViewBag.Attendees = ReturnedValues;
            // ViewBag.CurrentActivity = 
            //it's not showing the correct routing/errors are thrown
            return View("Dashboard", ShowActivity);


        }
        
            // so something to allow Activity to be Destroyed by creator
            // something to only view Delete button if created by..
    }
}

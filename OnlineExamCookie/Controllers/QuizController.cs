using Microsoft.AspNetCore.Mvc;
using OnlineExamCookie.Models;

namespace OnlineExamCookie.Controllers
{
    public class QuizController : Controller
    {
        



        public IActionResult Index()
        {
            return View();
        }


        static int count = 0;
        public IActionResult Question1()
        {
            count = 0;
            var question = new QuestionModel
            {
                QuestionText = " 1. What is the Extention of Model ?",
                Options = new List<string> { ".cs", ".cshtml", ".css", ".sql" },
                CorrectOptions = ".cs"
            };
            TempData["TQ1"] = question.CorrectOptions;
            return View(question);
        }
        [HttpPost]
        public IActionResult Question1(QuestionModel question)
        {
            var correctOption = TempData["TQ1"];
            //set the Selected Quction in a cookie
           if( question.SeletedOption != null)
            {
                Response.Cookies.Append("Q1", question.SeletedOption);
            }
            else
            {
                Response.Cookies.Append("Q1", " ");
            }
            //this is to read score

            if (question.SeletedOption == correctOption.ToString())
            {
                Response.Cookies.Append("Quest1", "y");
            }
            else
            {
                Response.Cookies.Append("Quest1", "n");
            }

            return RedirectToAction("Question2");
        }

        public IActionResult Question2()
        {
           
            var question = new QuestionModel
            {
                QuestionText = "2.What is the Extention of View ?",
                Options = new List<string> { ".cs", ".cshtml", ".css", ".sql" },
                CorrectOptions= ".cshtml"
            };
            TempData["TQ2"] = question.CorrectOptions;
            return View(question);
        }


        [HttpPost]
        public IActionResult Question2(QuestionModel question)
        {
            var correctOption = TempData["TQ2"];
            //set the Selected Quction in a cookie
            if (question.SeletedOption != null)
            {
                Response.Cookies.Append("Q2", question.SeletedOption);
            }
                
            else
            {
                Response.Cookies.Append("Q2", " ");
            }
            //this is to read score

            if (question.SeletedOption == correctOption.ToString())
            {
                Response.Cookies.Append("Quest2", "y");
            }
            else
            {
                Response.Cookies.Append("Quest2", "n");
            }

            return RedirectToAction("Question3");
        }

        public IActionResult Question3()
        {
            count = 0;
            var question = new QuestionModel
            {
                QuestionText = "What is the Extention of SQL ?",
                Options = new List<string> { ".cs", ".cshtml", ".css", ".sql" },
                CorrectOptions= ".sql"
            };
            TempData["TQ3"]= question.CorrectOptions;
            return View(question);
        }

        [HttpPost]
        public IActionResult Question3(QuestionModel question)
        {
            var correctOption = TempData["TQ3"];
            //set the Selected Quction in a cookie
            if (question.SeletedOption != null)
            {
                Response.Cookies.Append("Q3", question.SeletedOption);
            }
            else
            {
                Response.Cookies.Append("Q3", " ");
            }
            //this is to read score

            if (question.SeletedOption == correctOption.ToString())
            {
                Response.Cookies.Append("Quest3", "y");
            }
            else
            {
                Response.Cookies.Append("Quest3", "n");
            }

            return RedirectToAction("Result");
        }
      

        public IActionResult Result()
        {
            //Retrive the answer form cookie
            string selectedAnswer1 = Request.Cookies["Q1"];
            string selectedAnswer2 = Request.Cookies["Q2"];
            string selectedAnswer3 = Request.Cookies["Q3"];



            ViewBag.Answer1 = selectedAnswer1;
            ViewBag.Answer2 = selectedAnswer2;
            ViewBag.Answer3 = selectedAnswer3;



            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                string question = "Quest" + (i + 1);
                if (Request.Cookies[question] == "y")
                    count++;
            }
            ViewBag.score = count;
            return View();
        }

    }
}

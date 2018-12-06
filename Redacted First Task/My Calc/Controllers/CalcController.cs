﻿using My_Calc.Helpers;
using My_Calc.Models;
using My_Calc.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Calc.Controllers
{
    public class CalcController : Controller
    {
        const int DefaultX = 3;
        const int DefaultY = 32;
        const string DefaultResult = "No data";

        public static List<string> Results = new List<string>();

        // GET: Calc
        public ActionResult Index()
        {
            return View();
        }

        [Obsolete]
        public ActionResult OldAdd(int x, int y)
        {
            return View(x + y);
        }

        /// <summary>
        /// Calculate the sum of two integer variables
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View(new CalcModel() { X = DefaultX, Y = DefaultY, Result = DefaultResult });
        }

        /// <summary>
        /// Calculate the sum of two integer variables
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(CalcModel model)//не сумма

        {
            int result = 0;
            switch (model.Op)
            {
                case Operation.Add:
                    result = model.X + model.Y;
                    break;
                case Operation.Multiplication:
                    result = model.X * model.Y;
                    break;
                case Operation.Residual:
                    result = model.X - model.Y;
                    break;
                case Operation.NoOrdinaryOperation:
                    result = 4 * model.X - 3 * model.Y;
                    break;
                case Operation.Division:

                    if (model.Y == 0)
                    {
                        Results.Add("Error! Division by zero is incorrect!");
                        break;
                    }
                    else
                    {
                        result = model.X / model.Y;
                        break;
                    }
            }

                        model.Result = string.Format("{0}{2}{1} = {3}\n", CalcResources.x, CalcResources.y, model.Op.DisplayName(), result);
                        Results.Add(model.Result);
                        Results.Add("The time is" + " " + DateTime.UtcNow);
                        return View(model);
                    
         
        }
    }
}
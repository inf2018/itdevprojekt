using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITDevProjekt.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace ITDevProjekt.Controllers
{
    public class HomeController : Controller
    {
       // static string connString = "SERVER=localhost" + ";" +
        //       "DATABASE=projekt;" +
        //       "UID=newuser1;" +
        //       "PASSWORD=123456789admin;";
        

        private IConfiguration _conf;

        public HomeController(IConfiguration conf)
        {
            _conf = conf;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Translate(Language ln)
        {
            var conn = _conf.GetConnectionString("DefaultConnection");
            MySqlConnection cnMySQL = new MySqlConnection(conn);
            var languages = new List<Language>();
            using (cnMySQL)
            {
                MySqlCommand command = new MySqlCommand("getLang", cnMySQL);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                cnMySQL.Open();
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    var language = new Language
                    {
                        lang_attr = dr[0].ToString(),
                        lang_name = dr[1].ToString(),
                    };
                    languages.Add(language);
                }
                cnMySQL.Close();
            }
            //foreach(Language dataRow in languages)
            //{
            //    Debug.WriteLine(dataRow.lang_attr + " " + dataRow.lang_name);
            //}            
            return View("Translate", languages);
        }

        [HttpPost]
        //public JsonResult Add_data(InsertText it)
        //{
        //    string msg = string.Empty;
        //    try
        //    {
        //        MySqlCommand cmd = new MySqlCommand("insertData", cnMySQL);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@lang_source", it.lang_source);
        //        cmd.Parameters.AddWithValue("@lang_translate", it.lang_translate);
        //        cmd.Parameters.AddWithValue("@text_before", it.text_before);
        //        cmd.Parameters.AddWithValue("@text_after", it.text_after);
        //        cmd.Parameters.AddWithValue("@text_token", it.text_token);
        //        cnMySQL.Open();
        //        cmd.ExecuteReader();
        //        cnMySQL.Close();
        //        msg = "Data Inserted";
        //        return Json(msg);
        //    }
        //    catch (Exception)
        //    {
        //        msg = "Error!";
        //        return Json(msg);
        //    }
        //}

        //[HttpPost]
        //public JsonResult Select_data()
        //{
        //    string msg = string.Empty;
        //    var selectDatas = new List<SelectData>();
        //    try
        //    {
        //        using (cnMySQL)
        //        {
        //            MySqlCommand command = new MySqlCommand("selectData", cnMySQL);
        //            command.CommandType = System.Data.CommandType.StoredProcedure;
                    
        //            cnMySQL.Open();
        //            var dr = command.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                var selectData = new SelectData
        //                {
        //                    lang_source = dr[0].ToString(),
        //                    lang_translate = dr[1].ToString(),
        //                    text_before = dr[2].ToString(),
        //                    text_after = dr[3].ToString(),
        //                    text_token = dr[4].ToString(),
        //                };
        //                selectDatas.Add(selectData);
        //            }
        //            cnMySQL.Close();
        //        }
        //        msg = "Data selected";
        //        return Json(selectDatas);
        //    }
        //    catch (Exception)
        //    {
        //        msg = "Error!";
        //        return Json(selectDatas);
        //    }
        //}

        private JsonResult Json(string msg, object allowGet)
        {
            throw new NotImplementedException();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

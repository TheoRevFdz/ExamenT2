using ExamenT2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ExamenT2.Controllers
{
    public class CalificacionController : Controller
    {
        private static string jalumnos = @"[
                                                {
                                                    'IdAlumno':1,
                                                    'Nombres':'Theo',
                                                    'Apellidos':'Revilla Fdz',
                                                    'Nota1': 15,
                                                    'Nota2': 15,
                                                    'Nota3': 15,
                                                    'Nota4': 15,
                                                    'Promedio': 0
                                                }
                                           ]";

        // GET: Calificacion
        public ActionResult Index()
        {
            List<Alumno> temp;
            if (string.IsNullOrEmpty(jalumnos))
            {
                temp = new List<Alumno>();
            }
            else
            {
                temp = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
            }
            temp.ForEach(a => a.Promedio = (a.Nota1 + a.Nota2 + a.Nota3 + a.Nota4) / 4);
            return View(temp);
        }

        [HttpPost]
        public ActionResult Index(string nombre = "")
        {
            List<Alumno> temp;
            if (string.IsNullOrEmpty(nombre))
            {
                temp = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
            }
            else
            {
                List<Alumno> alumnos = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
                temp = alumnos.Where(c => c.Nombres.StartsWith(nombre, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            temp.ForEach(a => a.Promedio = (a.Nota1 + a.Nota2 + a.Nota3 + a.Nota4) / 4);
            return View(temp);
        }

        public ActionResult Create()
        {
            return View(new Alumno());
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            string message = "";
            if (!ModelState.IsValid)
            {
                return View(alumno);
            }

            try
            {
                List<Alumno> temp = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
                temp.Add(alumno);
                jalumnos = JsonConvert.SerializeObject(temp);
                message = "Alumno registrado";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            ViewBag.mensaje = message;
            return View(alumno);
        }

        public ActionResult Details(int id = 0)
        {
            List<Alumno> temp = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
            Alumno reg = temp.FirstOrDefault(p => p.IdAlumno == id);
            return View(reg);
        }

        public ActionResult Edit(int id)
        {
            List<Alumno> temp = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
            Alumno reg = temp.FirstOrDefault(p => p.IdAlumno == id);
            return View(reg);
        }

        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            string message = "";
            if (!ModelState.IsValid)
            {
                return View(alumno);
            }

            try
            {
                List<Alumno> temp = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
                Alumno result = temp.FirstOrDefault(a => a.IdAlumno == alumno.IdAlumno);
                temp.Remove(result);
                temp.Add(alumno);
                jalumnos = JsonConvert.SerializeObject(temp);
                message = "Alumno editado";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            ViewBag.mensaje = message;
            return View(alumno);
        }

        public ActionResult Delete(int id)
        {
            List<Alumno> temp = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
            Alumno reg = temp.FirstOrDefault(p => p.IdAlumno == id);
            return View(reg);
        }

        [HttpPost]
        public ActionResult Delete(Alumno alumno)
        {
            string message = "";
            try
            {
                List<Alumno> temp = JsonConvert.DeserializeObject<List<Alumno>>(jalumnos);
                Alumno result = temp.FirstOrDefault(a => a.IdAlumno == alumno.IdAlumno);
                temp.Remove(result);
                jalumnos = JsonConvert.SerializeObject(temp);
                message = "Alumno eliminado";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            ViewBag.mensaje = message;
            return View(alumno);
        }
    }
}
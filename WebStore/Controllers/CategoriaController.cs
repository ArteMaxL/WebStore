﻿using Microsoft.AspNetCore.Mvc;
using WebStore.Datos;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = _context.Categorias;
            return View(lista);
        }
        //Get
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria categoria)
        {
            if (!ModelState.IsValid) { return View(categoria); }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

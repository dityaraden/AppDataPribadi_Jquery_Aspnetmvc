using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppDataPribadi.Data;
using AppDataPribadi.Models;

namespace AppDataPribadi.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonDbContext _context;

        public PersonController(PersonDbContext context)
        {
            _context = context;
        }

        // List - Display Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.ToListAsync());
        }

        // Create - GET
        public IActionResult Create()
        {
            return View();
        }

        // Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Data berhasil ditambahkan!" });
            }

            // Jika data tidak valid, berikan pesan error
            return Json(new { success = false, message = "Gagal menambahkan data. Periksa kembali input Anda." });
        }


        // Update - GET
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound();

            return View("Edit", person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Person person)
        {
            if (id != person.NIK) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Data berhasil diperbarui." });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Terjadi kesalahan saat menyimpan data. " + ex.Message });
                }
            }

            return Json(new { success = false, message = "Model tidak valid." });
        }


        // Delete - GET
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null) return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person == null) return NotFound();

            return View(person);
        }

        // Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(long id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.NIK == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }


    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TwTodos.Contexts;
using TwTodos.Models;

namespace TwTodos.Controllers;

public class TodoController : Controller
{

    private readonly TwTodosContexts _context;

    public TodoController(TwTodosContexts contexts)
    {
        _context = contexts;
    }
    public IActionResult Index()
    {
        ViewData["Title"] = "Lista de Tarefas";
        var todos = _context.Todos.ToList();
        return View(todos);
    }
    public IActionResult Create()
    {
        ViewData["Title"] = "Nova Tarefa";
        return View("Form");
    }

    [HttpPost]




    [HttpPost]
    public IActionResult Create(Todo todo)
    {
        if (ModelState.IsValid)
        {
            todo.CreatedAt = DateTime.Now;
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewData["Title"] = "Nova Tarefa";
        return View("Form", todo);
    }


    public IActionResult Edit(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        ViewData["Title"] = "Editar Tarefa";
        return View("Form", todo);

    }
    [HttpPost]
    public IActionResult Edit(Todo todo)
    {
        if (ModelState.IsValid)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Editar Tarefa";
        return View("Form, todo");
    }

    public IActionResult Delete(int id)
    {

        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }
        ViewData["Title"] = "Excluir tarefa";
        return View(todo);
    }

    [HttpPost]
    public IActionResult Delete(Todo todo)
    {
        _context.Todos.Remove(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Finish(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo is null)
        {
            return NotFound();
        }

        todo.FinisheadAt = DateOnly.FromDateTime(DateTime.Now);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}

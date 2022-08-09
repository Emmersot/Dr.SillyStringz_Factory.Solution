using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineerController : Controller
  {
    private readonly FactoryContext _db;

    public EngineerController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Engineer.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machine, "MachineId", "Name");
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Machine machine, int MachineId)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      if(EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId});
        _db.SaveChanges();
      }
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
          .Include(machine => machine.JoinEntities)
          .ThenInclude(join => join.Engineer)
          .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
    var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
    ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
    return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, int EngineerId)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
        return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      if(EngineerId != 0)
      {
        _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = machine.MachineId});
        _db.SaveChanges();
      }
        return RedirectToAction("Index");
    }

      [HttpPost]
      public ActionResult DeleteEngineer(int joinId)
      {
        var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
        _db.EngineerMachine.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
  }
}
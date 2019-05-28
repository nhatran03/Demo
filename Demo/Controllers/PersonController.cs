using Demo.Model.Model;
using Demo.Services.Countries;
using Demo.Services.Persons;
using System.Net;
using System.Web.Mvc;

namespace Demo.Controllers
{
	public class PersonController : Controller
    {
        //private LabDbContext db = new LabDbContext();
		private IPersonService personService;
		private ICountryService countryService;

		public PersonController(IPersonService personService,
			ICountryService countryService)
		{
			this.personService = personService;
			this.countryService = countryService;
		}

        // GET: Person
        public ActionResult Index()
        {
            var persons = personService.GetAll();
            return View(persons);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            
            Person person = personService.GetById(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(countryService.GetAll());
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Phone,Address,State,CountryId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] Person person)
        {
            if (ModelState.IsValid)
            {
                personService.Create(person);               
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(countryService.GetAll());
            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = personService.GetById((int)id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(countryService.GetAll());
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Address,State,CountryId,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] Person person)
        {
            if (ModelState.IsValid)
            {
                personService.Update(person);                
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(countryService.GetAll());
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = personService.GetById((int)id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Person person = personService.GetById((int)id);
			personService.Delete(person);
            return RedirectToAction("Index");
        }

        
    }
}

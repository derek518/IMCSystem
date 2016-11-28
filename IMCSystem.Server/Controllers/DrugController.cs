using IMCSystem.Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace IMCSystem.Server.Controllers
{
    public class DrugController : ODataController
    {
        IMCContext _db = new IMCContext();
        private bool Exists(int key)
        {
            return _db.Drugs.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery(PageSize = 200)]
        public IHttpActionResult Get()
        {
            return Ok(_db.Drugs.AsQueryable());
        }

        [EnableQuery]
        public IHttpActionResult Get([FromODataUri] int key)
        {
            return Ok(_db.Drugs.SingleOrDefault(d => d.Id == key));
        }

        public async Task<IHttpActionResult> Post(Drug drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            drug.UpdatedAt = drug.CreatedAt = DateTime.Now;
            _db.Drugs.Add(drug);
            await _db.SaveChangesAsync();
            return Created(drug);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Drug> drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await _db.Drugs.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            drug.Patch(entity);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
    }
}

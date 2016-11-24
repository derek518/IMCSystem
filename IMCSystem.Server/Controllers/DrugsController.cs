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
    public class DrugsController : ODataController
    {
        IMCContext db = new IMCContext();
        private bool Exists(int key)
        {
            return db.Drugs.Any(p => p.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [EnableQuery]
        public IQueryable<Drug> Get()
        {
            return db.Drugs;
        }

        [EnableQuery]
        public SingleResult<Drug> Get([FromODataUri] int key)
        {
            IQueryable<Drug> result = db.Drugs.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Drug drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            drug.UpdatedAt = drug.CreatedAt = DateTime.Now;
            db.Drugs.Add(drug);
            await db.SaveChangesAsync();
            return Created(drug);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Drug> drug)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Drugs.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            drug.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
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

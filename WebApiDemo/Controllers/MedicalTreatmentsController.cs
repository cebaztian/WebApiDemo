using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MedicalTreatmentsController : ApiController
    {
        private WebApiDemoContext db = new WebApiDemoContext();

        // GET: api/MedicalTreatments
        public IQueryable<MedicalTreatment> GetMedicalTreatments()
        {
            return db.MedicalTreatments;
        }

        // GET: api/MedicalTreatments/5
        [ResponseType(typeof(MedicalTreatment))]
        public async Task<IHttpActionResult> GetMedicalTreatment(long id)
        {
            MedicalTreatment medicalTreatment = await db.MedicalTreatments.FindAsync(id);
            if (medicalTreatment == null)
            {
                return NotFound();
            }

            return Ok(medicalTreatment);
        }

        // PUT: api/MedicalTreatments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMedicalTreatment(long id, MedicalTreatment medicalTreatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicalTreatment.Id)
            {
                return BadRequest();
            }

            db.Entry(medicalTreatment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalTreatmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MedicalTreatments
        [ResponseType(typeof(MedicalTreatment))]
        public async Task<IHttpActionResult> PostMedicalTreatment(MedicalTreatment medicalTreatment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MedicalTreatments.Add(medicalTreatment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = medicalTreatment.Id }, medicalTreatment);
        }

        // DELETE: api/MedicalTreatments/5
        [ResponseType(typeof(MedicalTreatment))]
        public async Task<IHttpActionResult> DeleteMedicalTreatment(long id)
        {
            MedicalTreatment medicalTreatment = await db.MedicalTreatments.FindAsync(id);
            if (medicalTreatment == null)
            {
                return NotFound();
            }

            db.MedicalTreatments.Remove(medicalTreatment);
            await db.SaveChangesAsync();

            return Ok(medicalTreatment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicalTreatmentExists(long id)
        {
            return db.MedicalTreatments.Count(e => e.Id == id) > 0;
        }
    }
}
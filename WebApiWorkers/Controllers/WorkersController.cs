using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiWorkers;

namespace WebApiWorkers.Controllers
{
    /// <summary>
    /// API controller for Worker CRUD
    /// </summary>
    public class WorkersController : ApiController
    {
        private Factory db = new Factory();

        // GET: api/Workers
        /// <summary>
        /// Read all workers information
        /// </summary>
        /// <returns>Collection of Workers</returns>
        public IQueryable<Worker> GetWorkers()
        {
            return db.Workers;
        }

        // GET: api/Workers/5
        /// <summary>
        /// Read Workers information by Id
        /// </summary>
        /// <param name="id">Worker's database Id</param>
        /// <returns>Worker or Null</returns>
        [ResponseType(typeof(Worker))]
        public IHttpActionResult GetWorker(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            return Ok(worker);
        }

        // PUT: api/Workers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="worker"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorker(int id, Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != worker.Id)
            {
                return BadRequest();
            }

            db.Entry(worker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkerExists(id))
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

        // POST: api/Workers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        [ResponseType(typeof(Worker))]
        public IHttpActionResult PostWorker(Worker worker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workers.Add(worker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = worker.Id }, worker);
        }

        // DELETE: api/Workers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(Worker))]
        public IHttpActionResult DeleteWorker(int id)
        {
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return NotFound();
            }

            db.Workers.Remove(worker);
            db.SaveChanges();

            return Ok(worker);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkerExists(int id)
        {
            return db.Workers.Count(e => e.Id == id) > 0;
        }
    }
}
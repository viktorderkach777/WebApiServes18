namespace WebApiWorkers
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// class-Context for DataBase
    /// </summary>
    public class Factory : DbContext
    {
        // Your context has been configured to use a 'Factory' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApiWorkers.Factory' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Factory' 
        // connection string in the application configuration file.

            /// <summary>
            /// Constuctor Method for DB context class
            /// </summary>
        public Factory()
            : base("name=Factory")
        {
        }
        
        /// <summary>
        /// Table for Workers
        /// </summary>
         public virtual DbSet<Worker> Workers { get; set; }
    }

    /// <summary>
    /// Model class for "Workers" entity
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// worker's first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// worker's last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// workers age
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// workers salary
        /// </summary>
        public decimal Salary { get; set; }
    }
}
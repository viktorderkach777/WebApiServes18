using System.Data.Entity;

namespace WebApiWorkers
{
    internal class CustomInit<T> : DropCreateDatabaseIfModelChanges<Factory>
    {

        protected override void Seed(Factory context)
        {
            base.Seed(context);

            context.Workers.Add(new Worker
            {
                FirstName = "F1",
                LastName ="L1",
                Age = 31,
                 Salary = 1900m
            });

            context.Workers.Add(new Worker
            {
                FirstName = "F2",
                LastName = "L2",
                Age = 32,
                Salary = 2900m
            });

            context.Workers.Add(new Worker
            {
                FirstName = "F3",
                LastName = "L3",
                Age = 33,
                Salary = 3900m
            });
            context.SaveChanges();
        }

    }
}
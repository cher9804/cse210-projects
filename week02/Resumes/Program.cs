using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Graphite Connect";
        job1._jobTitle = "Integrations Specialist";
        job1._startYear = 2023;
        job1._endYear = 2025;
        // job1.DisplayJobDetails();

        Job job2 = new Job();
        job2._company = "Nutricost";
        job2._jobTitle = "HR Assistant";
        job2._startYear = 2024;
        job2._endYear = 2026;

        Resume resume1 = new Resume();
        resume1._name = "Cristian Hernandez";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();

        // Resume resume2 = new Resume();
        // resume2._name = "Laura Navarro";
        // resume2._jobs.Add(job2);










    }
}
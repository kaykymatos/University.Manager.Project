﻿using University.Manager.Project.Course.Domain.Validation;

namespace University.Manager.Project.Course.Domain.Entities
{
    public class CourseEntity : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Workload { get; private set; }
        public decimal TotalValue { get; private set; }
        public CourseCategory CourseCategory { get; private set; }
        public long CourseCategoryId { get; private set; }
        public CourseEntity()
        {

        }
        public CourseEntity(long id, string name, string description, DateTime workload, decimal totalValue)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidationDomain(name, description, workload, totalValue);
        }
        public void UpdateDomain(string name, string description, DateTime workload, decimal totalValue)
        {
            ValidationDomain(name, description, workload, totalValue);
            UpdatedData = DateTime.Now;
        }
        private void ValidationDomain(string name, string description, DateTime workLoad, decimal totalValue)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid Name, Name is required!");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, Name is too short, minimum 3 characters!");
            DomainExceptionValidation.When(name.Length > 200,
                "Invalid Name, Name is too large, maximum 200 characters!");
            Name = name;

            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
                "Invalid Description, Description is required!");
            DomainExceptionValidation.When(description.Length < 3,
                "Invalid Description, Description is too short, minimum 3 characters!");
            DomainExceptionValidation.When(name.Length > 200,
                "Invalid Description, Description is too large, maximum 200 characters!");
            Description = description;

            DomainExceptionValidation.When(workLoad == DateTime.MinValue,
               "Invalid Workload, Workload is required!");
            DomainExceptionValidation.When(workLoad.Hour <= 0,
                "Invalid Workload, Workload is too short, minimum 1 hour!");
            Workload = workLoad;

            DomainExceptionValidation.When(totalValue <= 0,
               "Invalid Total Value, Total Value is required!");
            DomainExceptionValidation.When(totalValue >= 9999999,
                "Invalid Total Value, Total Value is too large, maximum $9999998.00!");
            TotalValue = totalValue;
        }
    }
}

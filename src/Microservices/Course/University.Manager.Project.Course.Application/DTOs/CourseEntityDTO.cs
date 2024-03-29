﻿namespace University.Manager.Project.Course.Application.DTOs
{
    public class CourseEntityDTO
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Workload { get; set; }
        public decimal TotalValue { get; set; }
        public long CourseCategoryId { get; set; }

    }
}

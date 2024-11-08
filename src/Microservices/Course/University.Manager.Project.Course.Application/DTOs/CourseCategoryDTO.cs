﻿using University.Manager.Project.Course.Application.Interfaces;

namespace University.Manager.Project.Course.Application.DTOs
{
    public class CourseCategoryDTO : IBaseModel
    {
        public long Id { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime UpdatedData { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}

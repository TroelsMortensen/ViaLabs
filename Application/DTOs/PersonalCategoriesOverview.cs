﻿using Entities;

namespace Application.DTOs;

public class PersonalCategoriesOverview
{
    public IList<CategoryDTO> Categories { get; set; }
}
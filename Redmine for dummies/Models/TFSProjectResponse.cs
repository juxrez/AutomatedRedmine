﻿using System.Collections.Generic;

namespace Redmine_for_dummies.Models
{
    public class TFSProjectResponse
    {
        public int Count { get; set; }
        public List<TfsProject> Value { get; set; }
    }
}

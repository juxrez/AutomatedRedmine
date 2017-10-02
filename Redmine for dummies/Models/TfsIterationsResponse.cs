using System;
using System.Collections.Generic;

namespace Redmine_for_dummies.Models
{
    public class TfsIterationsResponse
    {
        public int Count { get; set; }
        public List<TfsIteration> Value { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Entity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime? updatedDate { get; set; }
    }
}

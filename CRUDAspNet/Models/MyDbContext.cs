﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAspNet.Models
{
    public class MyDbContext:DbContext
    {
        public DbSet<EmployeModel> Employes { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
    }
}

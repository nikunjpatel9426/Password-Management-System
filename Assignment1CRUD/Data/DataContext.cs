﻿using Assignment1CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment1CRUD.Data
{
    public class DataContext : DbContext{

        public DbSet<UserData>  UserData { get; set; }

        public DbSet<PassManage> PassManage { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}

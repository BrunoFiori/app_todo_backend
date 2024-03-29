﻿using App_Todo_Backend.Contract.Todo;
using App_Todo_Backend.Data;
using AutoMapper;

namespace App_Todo_Backend.Repository.Todo
{
    public class TodoRepository : GenericRepository<Data.Todo>, ITodoRepository
    {
        private readonly TodoDbContext _context;
        public TodoRepository(TodoDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }
    }
}

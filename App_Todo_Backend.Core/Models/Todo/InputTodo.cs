﻿using System.ComponentModel.DataAnnotations;

namespace App_Todo_Backend.Core.Models.Todo
{
    public class InputTodo
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
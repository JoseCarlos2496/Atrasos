﻿namespace Atrasos.Domain.Entities
{
    public class BaseEntity<T>
    {
        public required T Id { get; set; }
    }
}

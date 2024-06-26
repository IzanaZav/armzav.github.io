﻿namespace Gradebook.Domain.Entities;

public class Grade : BaseEntity
{
    public int Value { get; set; }
    public Student Student { get; set; }
    public Subject Subject { get; set; }
    public DateTime Date { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace DemoWeb1.Models;

public class Person
{
    [Display(Name="What's your name?")]
    public string? Name { get; set; }
}
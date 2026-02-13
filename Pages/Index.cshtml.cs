using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortfolioWebsite.Pages;

public class IndexModel : PageModel
{
    public string Name { get; set; } = "Nitish";
    public string Title { get; set; } = "Full Stack Developer";
    public string Bio { get; set; } = "Passionate developer building modern web applications with .NET and cutting-edge technologies.";
    
    public List<Project> Projects { get; set; } = new()
    {
        new Project 
        { 
            Name = "E-Commerce Platform", 
            Description = "A full-featured e-commerce solution built with ASP.NET Core and React",
            Technologies = new[] { "ASP.NET Core", "React", "SQL Server", "Azure" },
            Link = "#"
        },
        new Project 
        { 
            Name = "Task Management System", 
            Description = "Real-time collaboration tool for project management",
            Technologies = new[] { "Blazor", "SignalR", "MongoDB", "Docker" },
            Link = "#"
        },
        new Project 
        { 
            Name = "Portfolio CMS", 
            Description = "Content management system for developers and designers",
            Technologies = new[] { "ASP.NET MVC", "Entity Framework", "Bootstrap" },
            Link = "#"
        }
    };

    public List<Skill> Skills { get; set; } = new()
    {
        new Skill { Name = "C# / .NET", Level = 90 },
        new Skill { Name = "ASP.NET Core", Level = 85 },
        new Skill { Name = "JavaScript / TypeScript", Level = 80 },
        new Skill { Name = "SQL Server", Level = 85 },
        new Skill { Name = "Azure / Cloud", Level = 75 },
        new Skill { Name = "React / Blazor", Level = 80 }
    };

    public void OnGet()
    {
    }
}

public class Project
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string[] Technologies { get; set; } = Array.Empty<string>();
    public string Link { get; set; } = string.Empty;
}

public class Skill
{
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
}

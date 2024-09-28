using Microsoft.EntityFrameworkCore;
using ServerTest.Models;
using System.Diagnostics;

namespace ServerTest.Service;

public class STDataContext : DbContext
{
    private readonly string _ConnString = string.Empty;
    
    public STDataContext(string _ConnString)
    { this._ConnString = _ConnString; }
    
    
    public STDataContext(DbContextOptions<STDataContext> _Options) : base(_Options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder _OptionsBuilder)
    {
        _OptionsBuilder.UseNpgsql(_ConnString);
        _OptionsBuilder.LogTo(_S => Debug.WriteLine(_S));
    }

    //                       \/ table name
    public DbSet<Superhero> Superheroes { get; set; }
}

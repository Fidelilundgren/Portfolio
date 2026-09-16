using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Domain.Models;

public class Page
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int VisitCount { get; set; }

    public List<Block> Blocks { get; set; } = [];
}

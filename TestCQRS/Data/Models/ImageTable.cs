using System;
using System.Collections.Generic;

namespace TestCQRS.Data.Models;

public partial class ImageTable
{
    public int Id { get; set; }

    public byte[]? Image { get; set; }
}

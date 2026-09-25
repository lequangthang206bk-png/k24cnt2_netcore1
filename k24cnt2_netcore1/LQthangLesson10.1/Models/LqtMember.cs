using System;
using System.Collections.Generic;

namespace LQthangLesson10._1.Models;

public partial class LqtMember
{
    public long Id { get; set; }

    public string? LqtUserName { get; set; }

    public string? LqtPassword { get; set; }

    public string? LqtFullName { get; set; }

    public string? LqtEmail { get; set; }

    public string? LqtPhone { get; set; }

    public bool? LqtStatus { get; set; }
}

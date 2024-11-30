using System;
using System.Collections.Generic;

namespace E_knjiznica.Models;
public class Member
{
    public int ID { get; set; }
    public string? LastName { get; set; }
    public string? FirstMidName { get; set; }
    public DateTime MembershipDate { get; set; }
    public string? Credentials {get; set;}

}
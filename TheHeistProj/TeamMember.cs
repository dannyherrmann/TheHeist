using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeistProj;

public class TeamMember
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public decimal CourageFactor { get; set; }
    public TeamMember(string name, int skillLevel, decimal courageFactor)
    {
        Name = name;
        SkillLevel = skillLevel;
        CourageFactor = courageFactor;
    }
    public override string ToString()
    {
        return $@"
=================================
Name: {Name}
Skill Level: {SkillLevel}
Courage Factor: {CourageFactor}
=================================";
    }

}

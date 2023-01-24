using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeistProj;

public class TeamMemberBuilderV2
{
    public TeamMember Run()
    {
        TeamMember teamMember = new TeamMember();

        Console.Write("\tName --> ");

        teamMember.Name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(teamMember.Name))
        {
            return teamMember;
        }

        Console.Write("\tSkill Level --> ");

        string skillLevelInput = Console.ReadLine();

        int skillLevelAsInt;

        while (!int.TryParse(skillLevelInput, out skillLevelAsInt) || skillLevelAsInt <= 0)
        {
            Console.Write("\tSkill must be a positive integer!!\n");
            Console.Write("\tSkill Level --> ");
            skillLevelInput = Console.ReadLine();
        }

        teamMember.SkillLevel = Convert.ToInt32(skillLevelInput);

        Console.Write("\tCourage Factor --> ");

        string courageFactorInput = Console.ReadLine();

        decimal courageAsDec;

        while (!decimal.TryParse(courageFactorInput, out courageAsDec) || courageAsDec < 0.0M ||
               courageAsDec > 2.0M)
        {
            Console.Write("\tPlease enter a decimal between 0.0 and 2.0!!\n");
            Console.Write("\tCourage Factor --> ");
            courageFactorInput = Console.ReadLine();
        }

        teamMember.CourageFactor = Convert.ToDecimal(courageFactorInput);

        return teamMember;

    }
}

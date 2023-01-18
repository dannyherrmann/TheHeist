using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeistProj;

public class TeamMemberBuilder
{
    public void Run()
    {
        Console.WriteLine("Let's plan your heist!\n");

        Console.Write("Enter # of team members: ");

        int teamMemberCountInput = Convert.ToInt32(Console.ReadLine());

        List<TeamMember> TeamMemberList = new List<TeamMember>();

        for (int i = 1; i <= teamMemberCountInput; i++)
        {
            Console.WriteLine($"\nTeam Member #{i}:");

            Console.Write("\tName --> ");

            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("\tCome on...enter a name!!\n");
                Console.Write("\tName --> ");
                name = Console.ReadLine();
            }

            Console.Write("\tSkill Level --> ");

            string skillLevelInput = Console.ReadLine();

            int skillLevelAsInt;

            if (!int.TryParse(skillLevelInput, out skillLevelAsInt) || skillLevelAsInt <= 0)
            {
                Console.Write("\tSkill must be a positive integer!!\n");
                Console.Write("\tSkill Level --> ");
                skillLevelInput = Console.ReadLine();
            } 
            else
            {
                skillLevelAsInt = Convert.ToInt32(skillLevelInput);
            }

            Console.Write("\tCourage Factor --> ");

            string courageFactorInput = Console.ReadLine();

            decimal courageAsDec;

            if (!decimal.TryParse(courageFactorInput, out courageAsDec) || courageAsDec < 0M || courageAsDec > 2M)
            {
                Console.Write("\tPlease enter a decimal between 0.0 and 2.0!!\n");
                Console.Write("\tCourage Factor --> ");
                courageFactorInput = Console.ReadLine();
            }
            else
            {
                courageAsDec = Convert.ToDecimal(courageFactorInput);
            }

            Console.Write("\n");

            TeamMember newTeamMember = new TeamMember (name, skillLevelAsInt, courageAsDec);

            TeamMemberList.Add (newTeamMember);

        }

        Console.Write($"Here is the count of team members: {TeamMemberList.Count}\n");

        foreach (var teamMember in TeamMemberList)
        {
            Console.WriteLine("Team Member: Name: {0}, Skill Level: {1}, Courage Factor: {2}",teamMember.Name,teamMember.SkillLevel,teamMember.CourageFactor);
        }
    }

}

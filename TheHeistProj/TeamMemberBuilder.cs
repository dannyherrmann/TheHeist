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
        Random rnd = new Random();
        int bankLevel = 100 + rnd.Next(-10, 10);
        List<TeamMember> TeamMemberList = new List<TeamMember>();
        var teamSkillLevels = new List<int>();


        Console.WriteLine("Let's plan your heist!\n");

        Console.Write("Enter # of team members: ");

        string numTeamMembersInput = Console.ReadLine();

        int numTeamMembers;

        while (!int.TryParse(numTeamMembersInput, out numTeamMembers) || numTeamMembers < 1)
        {
            Console.Write("Please enter at least 1 team member!!\n");
            Console.Write("Enter # of team members: ");
            numTeamMembersInput = Console.ReadLine();
        }

        numTeamMembers = Convert.ToInt32(numTeamMembersInput);

        Console.Clear();

        for (int i = 1; i <= numTeamMembers; i++)
        {
            Console.WriteLine($"\nTeam Member #{i}:");

            Console.Write("\tName --> ");

            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name)) 
            {
                break;
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
            
            skillLevelAsInt = Convert.ToInt32(skillLevelInput);
            
            Console.Write("\tCourage Factor --> ");

            string courageFactorInput = Console.ReadLine();

            decimal courageAsDec;

            while (!decimal.TryParse(courageFactorInput, out courageAsDec) || courageAsDec < 0.0M || courageAsDec > 2.0M)
            {
                Console.Write("\tPlease enter a decimal between 0.0 and 2.0!!\n");
                Console.Write("\tCourage Factor --> ");
                courageFactorInput = Console.ReadLine();
            }
            
            courageAsDec = Convert.ToDecimal(courageFactorInput);
            
            Console.Write("\n");

            TeamMember newTeamMember = new TeamMember (name, skillLevelAsInt, courageAsDec);

            TeamMemberList.Add (newTeamMember);

            teamSkillLevels.Add(newTeamMember.SkillLevel);

            Console.Clear();

        }

        //Console.Clear();

        Console.Write($"There will be {TeamMemberList.Count} team members part of this heist! Press any key to continue\n");

        foreach (var teamMember in TeamMemberList)
        {
            Console.WriteLine(teamMember);
        }

        Console.ReadKey();
        Console.Clear();
        int teamSkillLevel = teamSkillLevels.Sum();

        Console.Write($"Bank's level = {bankLevel}\n");
        Console.WriteLine($"Team skill leavel = {teamSkillLevel}\n");

        Console.Write("Click any key to see the results of this Heist!!");
        Console.ReadKey();
        Console.Clear();

        if (teamSkillLevel >= bankLevel)
        {
            int diff = teamSkillLevel - bankLevel;
            Console.WriteLine($"This heist was a SUCCESS! You beat the bank by {diff} points\n");
        } else
        {
            int diff = bankLevel- teamSkillLevel;
            Console.WriteLine($"This heist was a FAILURE :( The bank beat you by {diff} points");
        }

        Console.ReadKey();
    }

}

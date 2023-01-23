using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeistProj;

public class TeamMemberBuilder
{
    public TeamMember Run()
    {
        TeamMember teamMember = new TeamMember();

        List<TeamMember> TeamMemberList = new List<TeamMember>();
        
        var teamSkillLevels = new List<int>();

        var success = new List<int>();

        var failure = new List<int>();

        Console.Write("Enter # of trial runs: ");

        string trialRunInput = Console.ReadLine();

        int trialRuns;

        while (!int.TryParse(trialRunInput, out trialRuns) || trialRuns < 1)
        {
            Console.Write("Can you please enter at least 1 run??\n");
            Console.Write("Enter # of trial runs: ");
            trialRunInput = Console.ReadLine();
        }

        trialRuns = Convert.ToInt32(trialRunInput);

        Console.Write("Enter bank difficulty level: ");

        string bankLevelInput = Console.ReadLine();

        int bankLevelUser;

        while (!int.TryParse(bankLevelInput, out bankLevelUser) || bankLevelUser <= 0 || bankLevelUser > 100)
        {
            Console.Write("Please enter a number greater than 0 and less than or equal to 100");
            Console.Write("Enter bank difficulty level: ");
            bankLevelInput = Console.ReadLine();
        }

        bankLevelUser = Convert.ToInt32(bankLevelInput);
        
        Console.Clear();

        for (int x = 1; x <= trialRuns; x++)
        {
            Random rnd = new Random();
            int bankLevel = bankLevelUser + rnd.Next(-10, 10);
            Console.WriteLine($"Trial Run #{x}");

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

                while (!decimal.TryParse(courageFactorInput, out courageAsDec) || courageAsDec < 0.0M ||
                       courageAsDec > 2.0M)
                {
                    Console.Write("\tPlease enter a decimal between 0.0 and 2.0!!\n");
                    Console.Write("\tCourage Factor --> ");
                    courageFactorInput = Console.ReadLine();
                }

                courageAsDec = Convert.ToDecimal(courageFactorInput);

                Console.Write("\n");

                TeamMember newTeamMember = new TeamMember(name, skillLevelAsInt, courageAsDec);

                TeamMemberList.Add(newTeamMember);

                teamSkillLevels.Add(newTeamMember.SkillLevel);

            }

            Console.Clear();

            Console.Write(
                $"There will be {TeamMemberList.Count} team members part of this heist! Press any key to continue\n");

            foreach (var teamMember in TeamMemberList)
            {
                Console.WriteLine(teamMember);
            }

            Console.ReadKey();
            Console.Clear();
            int teamSkillLevel = teamSkillLevels.Sum();

            Console.Write($"Bank's level = {bankLevel}\n");
            Console.WriteLine($"Team skill level = {teamSkillLevel}\n");

            Console.Write("Click any key to see the results of this Heist!!");
            Console.ReadKey();
            Console.Clear();

            if (teamSkillLevel >= bankLevel)
            {
                int diff = teamSkillLevel - bankLevel;
                Console.WriteLine($"This heist was a SUCCESS! You beat the bank by {diff} points\n");
                success.Add(1);
            }
            else
            {
                int diff = bankLevel - teamSkillLevel;
                Console.WriteLine($"This heist was a FAILURE :( The bank beat you by {diff} points\n");
                failure.Add(1);
            }

            if (x == trialRuns)
            {
                Console.WriteLine("Press any key to see results of all trial runs!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Press any key to move on to next trial run\n");
                Console.ReadKey();
            }
            TeamMemberList.Clear();
            teamSkillLevels.Clear();
            Console.Clear();
        }

        int successCount = success.Sum();
        int failureCount = failure.Sum();
        Console.Write($"Success Count: {successCount}\n");
        Console.Write($"Failure Count: {failureCount}");
        return TeamMember;
    }
}

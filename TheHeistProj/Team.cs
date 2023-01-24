using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeistProj;

public class Team
{
    public Team()
    {
        _memberBuilder = new TeamMemberBuilderV2();
        _members = new List<TeamMember>();
        _skillLevels = new List<int>();
    }

    private TeamMemberBuilderV2 _memberBuilder;

    private List<TeamMember> _members;

    private List<int> _skillLevels;

    public void Build()
    {
        Console.WriteLine("Let's plan your heist!\n");

        bool building = true;

        do
        {
            TeamMember newMember = _memberBuilder.Run();
           
            if (string.IsNullOrWhiteSpace(newMember.Name))
            {
                building = false;
            }
            else
            {
                Console.WriteLine($"Adding {newMember.Name} to the team!");
                Console.WriteLine();
                _members.Add(newMember);
                _skillLevels.Add(newMember.SkillLevel);
            }
        } while (building);
    }

    public void DisplayTeamInfo()
    {
        Console.Write($"There will be {_members.Count} team members part of this heist! Press any key to continue\n");

        _members.ForEach(member => Console.WriteLine(member));

        Console.ReadKey();
    }

    public void TrialRuns()
    {
        Console.WriteLine("Enter # of trial runs: ");

        string trialRunInput = Console.ReadLine();

        int trialRuns;

        while (!int.TryParse(trialRunInput, out trialRuns) || trialRuns < 1)
        {
            Console.Write("Can you please enter at least 1 run??\n");
            Console.Write("Enter # of trial runs: ");
            trialRunInput = Console.ReadLine();
        }

        trialRuns = Convert.ToInt32(trialRunInput);

    }
}

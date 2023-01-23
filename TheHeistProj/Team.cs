using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeistProj;

public class Team
{
    private TeamMemberBuilder _memberBuilder;

    private List<TeamMember> _members;

    public void Build()
    {
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

        bool building = true;
        int i = 1;

        do
        {
            i += 1;
            TeamMember newMember = _memberBuilder.Run();
           
            if (string.IsNullOrWhiteSpace(newMember.Name) || i <= numTeamMembers)
            {
                building = false;
            }
            else
            {
                Console.WriteLine($"Adding {newMember.name} to the team!");
                Console.WriteLine();
                _members.Add(newMember);
            }
        } while (building);
    }

    public void DisplayTeamInfo()
    {
        Console.Write($"There will be {_members.Count} team members part of this heist! Press any key to continue\n");

        _members.ForEach(member => Console.WriteLine(member));

        Console.ReadKey();
    }
}

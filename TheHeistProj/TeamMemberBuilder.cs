﻿using System;
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

        string numTeamMembersInput = Console.ReadLine();

        int numTeamMembers;

        while (!int.TryParse(numTeamMembersInput, out numTeamMembers) || numTeamMembers < 1)
        {
            Console.Write("Please enter at least 1 team member!!\n");
            Console.Write("Enter # of team members: ");
            numTeamMembersInput = Console.ReadLine();
        }

        numTeamMembers = Convert.ToInt32(numTeamMembersInput);

        List<TeamMember> TeamMemberList = new List<TeamMember>();

        for (int i = 1; i <= numTeamMembers; i++)
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

        }

        Console.Write($"There will be {TeamMemberList.Count} team members part of this heist!\n");

        foreach (var teamMember in TeamMemberList)
        {
            Console.WriteLine(teamMember);
        }

        Console.ReadLine();
    }

}

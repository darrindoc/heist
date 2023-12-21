using System;
using System.Collections.Generic;
using Classes;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Plan Your Heist!");

        Console.WriteLine("Choose bank difficulty level (integer). Default is 100.");
        int bankDifficultyLevel = Convert.ToInt32(Console.ReadLine()); //user sets difficulty of bank

        List<TeamMember> teamMembers = new List<TeamMember>();  //create List to store team members
        bool creatingMembers = true;  //create a bool so we can use a WHILE loop

    while (creatingMembers){
        Console.WriteLine("Enter team member's name. Enter a blank name to continue: ");
        string teamMemberName = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(teamMemberName)){
            creatingMembers = false; //stop collecting team member information
        }
        else {

        Console.WriteLine("Enter your team member's skill (integer 1-50):");
        int teamMemberSkill = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter your team member's courage (decimal 0.0 - 2.0):");
        double teamMemberCourage = Convert.ToDouble(Console.ReadLine());

        TeamMember newTeamMember = new TeamMember(teamMemberName, teamMemberSkill, teamMemberCourage);
        teamMembers.Add(newTeamMember);
        }
    }

    Console.WriteLine("There are " + teamMembers.Count + " members on this team.");

    Console.WriteLine("How many trial runs do you want to do?");
    int trialRuns = Convert.ToInt32(Console.ReadLine());


    int teamSkillLevel = teamMembers.Select(i => i.Skill).Sum();

    int i = 1;  //set i to zero for the while loop
    
    int successfulRuns = 0;
    int failedRuns = 0;

    while ( i <= trialRuns ) { //i incrememnts by +1 every loop until it is greater than trailRuns

    Random bankLuck = new Random();
    int bankLuckValue = bankLuck.Next(-10, 10); //create random modifier for bank difficulty

    int adjustedBankDifficulty = bankDifficultyLevel + bankLuckValue;
    Console.WriteLine("Your team's skill level is " + teamSkillLevel + "!");
    Console.WriteLine("The Bank's difficulty level is " + adjustedBankDifficulty + "!");

    if (adjustedBankDifficulty > teamSkillLevel)
    {
        Console.WriteLine("Your team failed! The cops got you! 👮");
        Console.WriteLine();
        i++;
        failedRuns++;
    }
    else 
    {
        Console.WriteLine("Your team succeeded! You are the best crime team! 💰");
        Console.WriteLine();
        i++;
        successfulRuns++;
    }
    }
    Console.WriteLine("You succeeded " + successfulRuns + " times and failed " + failedRuns + " times!"); //prints how many successess and failures there were
    }
}




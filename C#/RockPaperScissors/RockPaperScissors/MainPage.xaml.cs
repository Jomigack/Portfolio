namespace RockPaperScissors
{
    public partial class MainPage : ContentPage
    {
        //Vars to not reset
        int amtofRounds = 1;
        int userWins = 0;
        int aiWins = 0;
        int userLoss = 0;
        int aiLoss = 0;
        string userChoice = "";
        string aiDecision = "";

        public MainPage()
        {
            InitializeComponent();
        }

        public void ClickRock(object sender,EventArgs e)
        {
            userChoice = "rock";
            AiTurnAndFinale();

        }
        public void ClickPaper(object sender, EventArgs e)
        {
            userChoice = "paper";
            AiTurnAndFinale();
        }

        public void ClickScissors(object sender, EventArgs e)
        {
            userChoice = "scissors";
            AiTurnAndFinale();
        }

        async Task AiTurnAndFinale() //Function must be called this in order to use Task.Delay commands for the delay of the execution of commandss
        {
            UserWeapons.IsVisible = false;
            RoundOutput.Text = "The AI is making their decision";
            await Task.Delay(750);
            RoundOutput.Text = "The AI is making their decision.";
            await Task.Delay(750);
            RoundOutput.Text = "The AI is making their decision..";
            await Task.Delay(750);
            RoundOutput.Text = "The AI is making their decision...";
            await Task.Delay(1500);
            
                amtofRounds++;
            
            Random aiChoice = new Random();
            int aiDecisionInt = aiChoice.Next(1,4); //1-3 for AI Choice
            switch (aiDecisionInt) //Converts int to string for easier reading and printing
            {
                case 1:
                    aiDecision = "rock";
                    break;
                case 2:
                    aiDecision = "paper";
                    break;
                case 3:
                    aiDecision = "scissors";
                    break;
                default:
                    aiDecision = "invalid value";
                    break;
            }

            //To see who wins or not:

            //rock

            if(userChoice == "rock" && aiDecision == "paper")
            {
                aiWins++;
                userLoss++;

                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, you lose!";

            }
            else if(userChoice == "rock" && aiDecision == "scissors")
            {
                userWins++;
                aiLoss++;
                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, you win!";
            }
            else if (userChoice == "rock" && aiDecision == "rock")
            {
                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, it was a tie!";
            }
            //paper
            if(userChoice == "paper" && aiDecision == "rock")
            {
                userWins++;
                aiLoss++;
                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, you win!";
            }
            else if (userChoice == "paper" && aiDecision == "scissors")
            {
                aiWins++;
                userLoss++;
                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, you lose!";
            }
            else if (userChoice == "paper" && aiDecision == "paper")
            {
                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, it was a tie!";
            }
            //Scissors
            if (userChoice == "scissors" && aiDecision == "rock")
            {
                userLoss++;
                aiWins++;
                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, you lose!";
            }
            else if (userChoice == "scissors" && aiDecision == "paper")
            {
                userWins++;
                aiLoss++;
                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, you win!";
            }
            else if (userChoice == "scissors" && aiDecision == "scissors")
            {
                RoundOutput.Text = $"You chose {userChoice} and the bot chose {aiDecision}, it was a tie!";
            }
            //Text Changes
            RoundNumOutput.Text = $"Round Number: {amtofRounds}";
            UWin.Text = $"User Wins: {userWins}";
            ULoss.Text = $"User Losses: {userLoss}";
            AIWin.Text = $"AI Wins: {aiWins}";
            AILoss.Text = $"AI Loss: {aiLoss}";

            await Task.Delay(3000);
            UserWeapons.IsVisible = true;
            RoundOutput.Text = "The Details of the Fight Will be Given Here!";
        }

    }

}

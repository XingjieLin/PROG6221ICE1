
namespace XingjieLin_ST10071865_PROG6221_ICE1
{
    class ScriptDetails
    {
        //Variable Declaration
        //By using lamba expression input validation is achived
        private int _numScript;   
        public int numScript { get => _numScript; set => _numScript = value > 0 ? value : 0; }

        private int _numQuestion;
        public int numQuestion { get => _numQuestion; set => _numQuestion = (value >= 1 && value <= 10) ? value : 0; }

        private int _QuestionSubTotal;
        public int questionSubtotal { get => _QuestionSubTotal; set => _QuestionSubTotal = value > 0 ? value : 0; }

        private int _numLectur;
        public int numLecture { get => _numLectur; set => _numLectur = value > 0 ? value : 0; }

        //this variable store the total mark for the script
        public int scriptTotal { get; set; }
        

        /*This method will calculate and display:
         * number of scripts each lecture need to mark
         * time needed to mark all the scripts
        */
        public void generateReport()
        {
            int numScripts = _numScript / _numLectur; //Calculate how many scripts each lecturer need to mark
            int numExtraScripts = _numScript % _numLectur; //Calculate how many extra scripts last lecturer need to mark

            int totalSeconds = numScripts * _numQuestion * scriptTotal * 2; //Calculate total seconds need to mark the script
            int extraSeconds = numExtraScripts * _numQuestion * scriptTotal * 2;
            int totalMinutes = totalSeconds / 60; //Calculate the total minutes need to mark the script
            int extraMinutes = extraSeconds / 60;
            int totalHours = totalMinutes / 60;//Calculate the total hours need to mark the script
            int extraHours = extraMinutes / 60;
            int remainingTotalMinutes = totalMinutes % 60;
            int remainingExtraMinutes = extraMinutes % 60;

            // Display the report
            Console.WriteLine($"\nEach lecturer will mark {numScripts} scripts, except the last lecturer who will mark {numScripts + numExtraScripts} scripts.");
            Console.WriteLine($"\nEstimated time to mark {numScripts} scripts: {totalHours} hours {remainingTotalMinutes + (totalSeconds % 60 >= 30 ? 1 : 0)} minutes");
            Console.WriteLine($"Estimated time to mark {numExtraScripts} additional scripts: {extraHours} hours {remainingExtraMinutes + (extraSeconds % 60 >= 30 ? 1 : 0)} minutes");
        }
    }

    class ConsoleApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("Thrivetech Global Technology Institute Scripts Distribution Application");
            Console.WriteLine("***********************************************************************\n");

            //Create an object to store Script detail
            var scriptDetail = new ScriptDetails();
            
            //Prompt user for input until match criteria
            while (scriptDetail.numScript == 0)
            {
                Console.WriteLine("Please enter the total number of scripts to be marked(EG.Input must be greater than 0)");
                scriptDetail.numScript = Convert.ToInt32(Console.ReadLine());
            }

            //Prompt user for input until match criteria
            while (scriptDetail.numQuestion == 0)
            {
                Console.WriteLine("Please enter the total number of quetions(EG.Input must be between 1 and 10)");
                scriptDetail.numQuestion = Convert.ToInt32(Console.ReadLine());
            }

            //Prompt user for input until match criteria
            for (int i = 0; i < scriptDetail.numQuestion; i++)
            {
                while (scriptDetail.questionSubtotal == 0)
                {
                    Console.WriteLine($"Please enter the subTotal for question {i+1}(EG.Input must be greater than 0)");
                    scriptDetail.questionSubtotal = Convert.ToInt32(Console.ReadLine());
                }
                scriptDetail.scriptTotal += scriptDetail.questionSubtotal;
                scriptDetail.questionSubtotal = 0;
            }

            //Prompt user for input until match criteria
            while (scriptDetail.numLecture == 0)
            {
                Console.WriteLine("Please enter the number of lecturers marking the scripts(EG.Input must be greater than 0)");
                scriptDetail.numLecture = Convert.ToInt32(Console.ReadLine());
            }

            //Call report generation method
            scriptDetail.generateReport();

        }

    }
}
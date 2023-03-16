
namespace XingjieLin_ST10071865_PROG6221_ICE1
{
    class ScriptDetails
    {
        private int _numScript;   
        public int numScript { get => _numScript; set => _numScript = value > 0 ? value : 0; }

        private int _numQuestion;
        public int numQuestion { get => _numQuestion; set => _numQuestion = (value >= 1 && value <= 10) ? value : 0; }

        private int _QuestionSubTotal;
        public int questionSubtotal { get => _QuestionSubTotal; set => _QuestionSubTotal = value > 0 ? value : 0; }

        private int _numLectur;
        public int numLecture { get => _numLectur; set => _numLectur = value > 0 ? value : 0; }

        public int scriptTotal { get; set; }

        public void generateReport()
        {
            int numScripts = _numScript / _numLectur;
            int numExtraScripts = _numScript % _numLectur;

            int totalSeconds = numScripts * _numQuestion * scriptTotal * 2; 
            int extraSeconds = numExtraScripts * _numQuestion * scriptTotal * 2;
            int totalMinutes = totalSeconds / 60;
            int extraMinutes = extraSeconds / 60;
            int totalHours = totalMinutes / 60;
            int extraHours = extraMinutes / 60;
            int remainingTotalTimeMinutes = totalMinutes % 60;
            int remainingAdditionalTimeMinutes = extraMinutes % 60;

            // Output the results
            Console.WriteLine($"\nEach lecturer will mark {numScripts} scripts, except the last lecturer who will mark {numScripts + numExtraScripts} scripts.");
            Console.WriteLine($"\nEstimated time to mark {numScripts} scripts: {totalHours} hours {remainingTotalTimeMinutes + (totalSeconds % 60 >= 30 ? 1 : 0)} minutes");
            Console.WriteLine($"Estimated time to mark {numExtraScripts} additional scripts: {extraHours} hours {remainingAdditionalTimeMinutes + (extraSeconds % 60 >= 30 ? 1 : 0)} minutes");
        }
    }

    class ConsoleApp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("Thrivetech Global Technology Institute Scripts Distribution Application");
            Console.WriteLine("***********************************************************************\n");

            var scriptDetail = new ScriptDetails();

            while (scriptDetail.numScript == 0)
            {
                Console.WriteLine("Please enter the total number of scripts to be marked(EG.Input must be greater than 0)");
                scriptDetail.numScript = Convert.ToInt32(Console.ReadLine());
            }

            while (scriptDetail.numQuestion == 0)
            {
                Console.WriteLine("Please enter the total number of quetions(EG.Input must be between 1 and 10)");
                scriptDetail.numQuestion = Convert.ToInt32(Console.ReadLine());
            }

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
            
            
            while (scriptDetail.numLecture == 0)
            {
                Console.WriteLine("Please enter the number of lecturers marking the scripts(EG.Input must be greater than 0)");
                scriptDetail.numLecture = Convert.ToInt32(Console.ReadLine());
            }

            scriptDetail.generateReport();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration4.A
{
    public class SecretNumber
    {
        private int _count;         //Antalet gissningar
        private int _number;        //Det hemliga talet
        
        public const int MaxNumberOfGuesses = 7;    //Max antal gissningar

        public SecretNumber()
        {
            Initialize();
        }


        public void Initialize()
        {
            _count = 0;

            Random randomNum = new Random();
            _number = randomNum.Next(1, 101);
        }

        public bool MakeGuess(int number) //Här görs gissningarna
        {

            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            _count++;

            if (number == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", _count);
                return true;
            }
            else if (number > _number)
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, (MaxNumberOfGuesses - _count));
            }
            else if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", number, (MaxNumberOfGuesses - _count));
            }

            if (_count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}.", _number);
            }

            return false;
        }

    }
}

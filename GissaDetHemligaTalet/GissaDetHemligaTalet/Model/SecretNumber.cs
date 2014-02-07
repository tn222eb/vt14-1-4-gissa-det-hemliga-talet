using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace GissaDetHemligaTalet.Model
{
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess };
    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuesses;

        public const int MaxNumberOfGuesses = 7;

        // Kollar om man kan göra en gissning eller inte
        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses && !_previousGuesses.Contains(_number);
            }
        }

        // Ger antalet gjorda gissningar 
        public int Count
        {
            get
            {
                return _previousGuesses.Count();
            }
        }

        // Ger det hemliga talet hemliga talet om man inte kan göra fler gissningar
        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
        }

        // Ger resultat av sista utförda gissningen
        public Outcome Outcome { get; private set; }

        // Ger referens till samling innehållande utförda gissningar
        public ReadOnlyCollection<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses.AsReadOnly();
            }
        }

        // Skapar klassens alla medlemmar
        public void Initialize()
        {
            // Slumpar hemliga-talet mellan 1 och 100
            Random random = new Random();
            _number = random.Next(1, 101);

            _previousGuesses.Clear();

            Outcome = Outcome.Indefinite;
        }

        // Kollar om det gissade talet är rätt eller fel
        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count > MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (Count == MaxNumberOfGuesses)
            {
                return Outcome = Outcome.NoMoreGuesses;
            }


            if (PreviousGuesses.Contains(guess))
            {
                return Outcome = Outcome.PreviousGuess;
            }

            _previousGuesses.Add(guess);

            if (guess > _number)
            {
                return Outcome = Outcome.High;
            }
            else if (guess < _number)
            {
                return Outcome = Outcome.Low;
            }
            else
            {
                return Outcome = Outcome.Correct;
            }

        }

        // Konstruktor
        public SecretNumber()
        {
            _previousGuesses = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }


    }
}
using GissaDetHemligaTalet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GissaDetHemligaTalet
{
    public partial class Default : System.Web.UI.Page
    {
        private SecretNumber SecretNumber
        {
            get
            {
                if (Session["SecretNumber"] == null)
                {
                    Session["SecretNumber"] = new SecretNumber();
                }
                return Session["SecretNumber"] as SecretNumber;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int numberChosen = int.Parse(ValueTextBox.Text);
                Outcome answer = SecretNumber.MakeGuess(numberChosen);
                GuessesPlaceHolder.Visible = true;
                Guesses.Text = string.Join(", ", SecretNumber.PreviousGuesses);

                if (answer == Outcome.High)
                {
                    Guesses.Text += String.Format(" För högt!");
                }
                else if (answer == Outcome.Low)
                {
                    Guesses.Text += String.Format(" För lågt!");
                }
                else if (answer == Outcome.Correct)
                {
                    Result.Text = String.Format(" Grattis! Du vann!");
                    ValueTextBox.Enabled = false;
                    SendButton.Enabled = false;
                    ResultPlaceHolder.Visible = true;
                    RandomNumberButton.Visible = true;
                    RandomNumberButton.Focus();
                }
                else if (answer == Outcome.PreviousGuess)
                {
                    Guesses.Text += String.Format(" Du har redan gissat på talet");
                }
                else if (answer == Outcome.NoMoreGuesses)
                {
                    Result.Text = String.Format(" Du har inga gissningar kvar. Det hemliga talet var {0}", SecretNumber.Number);
                    ValueTextBox.Enabled = false;
                    SendButton.Enabled = false;
                    ResultPlaceHolder.Visible = true;
                    RandomNumberButton.Visible = true;
                    RandomNumberButton.Focus();
                }
            }
        }

        protected void RandomNumberButton_Click(object sender, EventArgs e)
        {
            SecretNumber.Initialize();
        }
    }
}
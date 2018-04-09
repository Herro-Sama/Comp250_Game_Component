using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	private int[] layers = new int[] { 900, 8, 8, 3 };
	private float[] networkGuess = new float[] {0,0,0};
	NeuralNetworkAttempt Network;

    private bool playerFirstGuess;

	void Start()
	{
		Network = new NeuralNetworkAttempt (layers);
		layers [0] += 3;
		Network.Mutate();
	}

    public void FitnessRating(bool CorrectAnswer)
    {
        if (CorrectAnswer == true)
        {
            return;
        }
        else
        {
            Network.Mutate();
        }
    }


	// Update is called once per frame
	public void DoNeuralNetworking(float[] PlayerChoice) 
	{
		networkGuess = Network.FeedForward(PlayerChoice);
		print ("Part one - " + networkGuess [0]);
		print ("Part Two - " + networkGuess [1]);
		print ("Part Three - " + networkGuess [2]);
        playerFirstGuess = true;
	}

	public string GetNetworkGuessString()
	{
		if (networkGuess != null && playerFirstGuess != false)
		{
			if (networkGuess[0] > networkGuess[1])
			{
                if (networkGuess[0] > networkGuess[2])
                {
                    return "Rock";
                }
                return "Scissors";

            }
			if (networkGuess[1] > networkGuess[2])
			{
				return "Paper";
			}
			else
			{
				return "Scissors";
			}

		}
		return "Unknown";
	}

}

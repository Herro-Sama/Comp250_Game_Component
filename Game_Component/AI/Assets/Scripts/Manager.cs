using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    /*
     * This script is used to create and store the network, it's also used to manage the network and relay information to other scripts so nothing else touchs the neural network. 
     */

	private int[] layers = new int[] { 900, 300, 16, 3 };
	private float[] networkGuess = new float[] {0,0,0};
	NeuralNetworkAttempt Network;

    private bool playerFirstGuess;

    // On Start up create the network.
    void Start()
	{
		Network = new NeuralNetworkAttempt (layers);
		layers [0] += 3;
		Network.Mutate();
	}

    // Make the network mutate.
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

    // Used by the DisplayNeuralOutput script.
    public float[] GetNetworkGuessFloat()
    {
        if (playerFirstGuess != false)
        {
            return networkGuess;
        }
        return new float[] {0,0,0};
    }


	// This is used when the player makes a guess.
	public void DoNeuralNetworking(float[] PlayerChoice) 
	{
		networkGuess = Network.FeedForward(PlayerChoice);
        playerFirstGuess = true;
	}

    // This returns a string based on which of the outputs is highest.
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

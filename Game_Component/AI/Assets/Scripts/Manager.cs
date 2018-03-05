using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	private int[] layers = new int[] { 3, 8, 8, 3 };
	private float[] networkGuess = new float[] {0,0,0};
	NeuralNetworkAttempt Network;
	private string guessString;

	void Start()
	{
		Network = new NeuralNetworkAttempt (layers);
		layers [0] += 3;
		Network.Mutate();
	}

	// Update is called once per frame
	public void DoNeuralNetworking(float[] PlayerChoice) 
	{
		networkGuess = Network.FeedForward(PlayerChoice);
		print ("Part one - " + networkGuess [0]);
		print ("Part Two - " + networkGuess [1]);
		print ("Part Three - " + networkGuess [2]);
	}

	public string GetNetworkGuessString()
	{
		if (networkGuess != null)
		{
			if (networkGuess[0] == 1)
			{
				return "Rock";
			}
			if (networkGuess[1] == 1)
			{
				return "Paper";
			}
			if (networkGuess [2] == 1)
			{
				return "Scissors";
			}

		}
		return "Unknown";
	}

}

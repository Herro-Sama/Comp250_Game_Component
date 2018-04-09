using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject ManagerRef;
	private float[] playerGuess = new float[3] {0,0,0};

	public void RockPicked()
	{
		playerGuess [0] = 1;
		playerGuess [1] = 0;
		playerGuess [2] = 0;
		ManagerRef.GetComponent<Manager>().DoNeuralNetworking(playerGuess);
	}

	public void PaperPicked()
	{
		playerGuess [0] = 0;
		playerGuess [1] = 1;
		playerGuess [2] = 0;
		ManagerRef.GetComponent<Manager>().DoNeuralNetworking(playerGuess);
	}

	public void ScissorsPicked()
	{
		playerGuess [0] = 0;
		playerGuess [1] = 0;
		playerGuess [2] = 1;
		ManagerRef.GetComponent<Manager>().DoNeuralNetworking(playerGuess);
	}

    public void WrongPicked()
    {
        ManagerRef.GetComponent<Manager>().FitnessRating(false);
    }
}

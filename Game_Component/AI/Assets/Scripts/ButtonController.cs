using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    // This script controls the buttons sending various information to the Manager script.

	public GameObject ManagerRef;
	private float[] playerGuess = new float[3] {0,0,0};

    // Choice for rock.
	public void RockPicked()
	{
		playerGuess [0] = 1;
		playerGuess [1] = 0;
		playerGuess [2] = 0;
		ManagerRef.GetComponent<Manager>().DoNeuralNetworking(playerGuess);
	}

    // Choice for paper.
    public void PaperPicked()
	{
		playerGuess [0] = 0;
		playerGuess [1] = 1;
		playerGuess [2] = 0;
		ManagerRef.GetComponent<Manager>().DoNeuralNetworking(playerGuess);
	}

    // Choice for Scissors.
    public void ScissorsPicked()
	{
		playerGuess [0] = 0;
		playerGuess [1] = 0;
		playerGuess [2] = 1;
		ManagerRef.GetComponent<Manager>().DoNeuralNetworking(playerGuess);
	}

    // Tell the manager that the guess was wrong and to mutate.
    public void WrongPicked()
    {
        ManagerRef.GetComponent<Manager>().FitnessRating(false);
    }
}

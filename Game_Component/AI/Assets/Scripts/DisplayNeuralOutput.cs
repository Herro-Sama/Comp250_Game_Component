using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayNeuralOutput : MonoBehaviour
{

    // This script gets the output of the neural network for use later.
    public GameObject rockGuess;
    public GameObject paperGuess;
    public GameObject scissorsGuess;

    public GameObject managerRef;

    private float[] networkGuess;


    // This is called constantly to make sure that it has the most up to date info without having dependancies.
    void FixedUpdate()
    {
        if (managerRef != null)
        {
            networkGuess = managerRef.GetComponent<Manager>().GetNetworkGuessFloat();

            rockGuess.GetComponent<Text>().text = "Weight for guess: " + networkGuess[0];

            paperGuess.GetComponent<Text>().text = "Weight for guess: " + networkGuess[1];

            scissorsGuess.GetComponent<Text>().text = "Weight for guess: " + networkGuess[2];
        }
    }


}

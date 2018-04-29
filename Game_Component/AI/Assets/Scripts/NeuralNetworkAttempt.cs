using System.Collections.Generic;
using System;
using UnityEngine;

/*
 *  Based on the code by youtube Channel The One https://www.youtube.com/watch?v=Yq0SfuiOVYE
 *  The current version has been adapted but not by much. 
 *  I've mainly added the PreviousMemory variable and associated funcionality.
 * 
 */ 

public class NeuralNetworkAttempt
{
    // Create all the variables for the neural network.
	private List<float[]> PreviousMemory = new List<float[]> ();
	private int[] layers;
	private float[][] neurons;
	private float[][][] weights;

    // Called when creating the neural network to set the number of layers and their size.
	public NeuralNetworkAttempt(int[] layers)
	{
		this.layers = new int[layers.Length];
		for (int i = 0; i < layers.Length; i++)
		{
			this.layers [i] = layers [i];
		}
		InitNeurons ();
		InitWeights ();
	}

    // This is used to create a copy of a neural network from an existing network.
	public NeuralNetworkAttempt(NeuralNetworkAttempt copyNetwork)
	{
		this.layers = new int[copyNetwork.layers.Length];
		for (int i = 0; i < copyNetwork.layers.Length; i++)
		{
			this.layers [i] = copyNetwork.layers [i];
		}

		InitNeurons ();
		InitWeights ();
		CopyWeights (copyNetwork.weights);
	}

    // This is a function used for copying weight information.
	private void CopyWeights(float[][][] copyweights)
	{
		for (int i = 0; i < weights.Length; i++)
		{
			for (int j = 0; j < weights [i].Length; j++)
			{
				for (int k = 0; k < weights[i][j].Length; k++)
				{
					weights [i] [j] [k] = copyweights [i] [j] [k];
				}
			}
		}

	}

    // This is used to create all of the neurons for the network.
	private void InitNeurons()
	{
		List<float[]> neuronsList = new List<float[]> ();

		for (int i = 0; i < layers.Length; i++)
		{
			neuronsList.Add (new float[layers [i]]);
		}

		neurons = neuronsList.ToArray ();
	}

    // This is used to create all of the weights for each of the networks.
	private void InitWeights()
	{
		List<float[][]> weightslist = new List<float[][]> ();

		for (int i = 0; i < layers.Length; i++)
		{
			List<float[]> layersweightslist = new List<float[]> ();

			int neuronsInPreviousLayer = layers[i];

			for (int j = 0; j < neurons [i].Length; j++)
			{
				float[] neuronWeights = new float[neuronsInPreviousLayer];

				for (int k = 0; k < neuronsInPreviousLayer; k++)
				{
                    // This creates the weight but initially it's set to being a random number in a range.
                    neuronWeights [k] = (float)UnityEngine.Random.Range(-0.5f, 0.5f);
				}

				layersweightslist.Add (neuronWeights);
			}

			weightslist.Add (layersweightslist.ToArray ());
		}

		weights = weightslist.ToArray ();

	}

    // This is called when you want to actually use the neural network.
	public float[] FeedForward(float[] inputs)
	{
        // Add the inputs into the previous memory.
		PreviousMemory.Add(inputs);
		for (int l = 0; l < PreviousMemory.Count; l++)
		{
			// For each part of the previous memory set the neurons in the first layer to have a value.
			for (int i = 0; i < PreviousMemory[l].Length; i++)
			{
				neurons [0] [i] = PreviousMemory[l] [i];
			}
		}

        // Pass through each of the neurons and multiply their value with a weighting, value boosts the default value.
		for (int i = 0; i < neurons.Length; i++)
		{
			for (int j = 0; j < neurons[i].Length; j++)
			{
				float value = 0.25f;
				for (int k = 0; k < weights[i][j].Length; k++)
				{
					value += weights [i] [j] [k] * neurons [i] [k];
				}

                // Prevent the neurons from having a value above one or going below negative one.
				neurons [i] [j] = (float)Math.Tanh (value);
			}
		}
			
        // Return the last set of neurons.
		return neurons[neurons.Length - 1];
	}

    // This function is called to change all of the weights randomly to change the network.
	public void Mutate()
	{
		for (int i = 0; i < weights.Length; i++)
		{
			for (int j = 0; j < weights[i].Length; j++)
			{
				for (int k = 0; k < weights[i][j].Length; k++)
				{
					float weight = weights [i] [j] [k];

                    // Change the neural networks weight to a random number in this range.
					float factor = UnityEngine.Random.Range (-1.0f, 1.0f);
					weight *= factor;
					
					weights [i] [j] [k] = weight;
				}

			}
		}

	}
		
}

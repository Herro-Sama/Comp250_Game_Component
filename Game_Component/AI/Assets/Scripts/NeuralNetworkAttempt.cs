using System.Collections.Generic;
using System;
using UnityEngine;

/*
 *  Based on the code by youtube Channel The One https://www.youtube.com/watch?v=Yq0SfuiOVYE
 *  The current version has been adapted but not by much.
 * 
 */ 

public class NeuralNetworkAttempt
{
	private List<float[]> PreviousMemory = new List<float[]> ();
	private int[] layers;
	private float[][] neurons;
	private float[][][] weights;

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

	private void InitNeurons()
	{
		List<float[]> neuronsList = new List<float[]> ();

		for (int i = 0; i < layers.Length; i++)
		{
			neuronsList.Add (new float[layers [i]]);
		}

		neurons = neuronsList.ToArray ();
	}

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
					neuronWeights [k] = (float)UnityEngine.Random.Range(-0.5f, 0.5f);
				}

				layersweightslist.Add (neuronWeights);
			}

			weightslist.Add (layersweightslist.ToArray ());
		}

		weights = weightslist.ToArray ();

	}

	public float[] FeedForward(float[] inputs)
	{
		PreviousMemory.Add(inputs);
		for (int l = 0; l < PreviousMemory.Count; l++)
		{
			
			for (int i = 0; i < PreviousMemory[l].Length; i++)
			{
				neurons [0] [i] = PreviousMemory[l] [i];
			}
		}

		for (int i = 0; i < neurons.Length; i++)
		{
			for (int j = 0; j < inputs.Length; j++)
			{
				float value = 0.25f;
				for (int k = 0; k < inputs.Length; k++)
				{
					value += weights [i] [j] [k] * neurons [i] [k];
				}

				neurons [i] [j] = (float)Math.Tanh (value);
			}
		}
			
		return neurons[neurons.Length - 1];
	}

	public void Mutate()
	{
		for (int i = 0; i < weights.Length; i++)
		{
			for (int j = 0; j < weights[i].Length; j++)
			{
				for (int k = 0; k < weights[i][j].Length; k++)
				{
					float weight = weights [i] [j] [k];

					float randomNumber = UnityEngine.Random.Range(0.0f, 10.0f);

					if (randomNumber <= 2f)
					{
						weight *= -1f;
					} 

					else if (randomNumber <= 4f)
					{
						weight = UnityEngine.Random.Range (-0.5f, 0.5f);
					} 

					else if (randomNumber <= 6f)
					{
						float factor = UnityEngine.Random.Range (-1.0f, 1.0f) + 1f;
						weight *= factor;
					} 

					else if (randomNumber <= 8f)
					{
						float factor = UnityEngine.Random.Range (0f, 1.0f);
						weight *= factor;
					}

					weights [i] [j] [k] = weight;
				}

			}
		}

	}
		
}

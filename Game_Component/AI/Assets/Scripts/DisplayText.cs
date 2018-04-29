using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

    // This script gets the current guess from the network. 
	public GameObject managerRef;

	void FixedUpdate () 
	{
		gameObject.GetComponent<Text> ().text = managerRef.GetComponent<Manager> ().GetNetworkGuessString ();
	}
}

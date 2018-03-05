using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour {

	public GameObject managerRef;

	void FixedUpdate () 
	{
		gameObject.GetComponent<Text> ().text = managerRef.GetComponent<Manager> ().GetNetworkGuessString ();
	}
}

using UnityEngine;
using System.Collections;

public class TranscriptManager : MonoBehaviour {

	public static TranscriptManager _instance;

	public GameObject player;

	void Awake()
	{
		_instance = this;
		player = GameObject.FindGameObjectWithTag("PlayerTranscript");
	}
}

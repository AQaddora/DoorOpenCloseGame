using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	private Transform player;
	private Animator openAnim;

	public float doorGap;
	public float distanceToPlayer;

	private AudioSource audioSource;
	private bool doorIsClosed = true;

	void Start ()
	{
		audioSource = GetComponent<AudioSource>();
		openAnim = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update ()
	{
		if((Mathf.Abs(Vector3.Distance(transform.position, player.position)) <= distanceToPlayer) && doorIsClosed)
		{
			OpenDoor();
			Debug.Log("Player in Range");
		}
		else if(!doorIsClosed && (Mathf.Abs(Vector3.Distance(transform.position, player.position)) > distanceToPlayer))
		{
			Debug.Log("Player not in Range");
			CloseDoor();
		}
	}

	private void OpenDoor()
	{
		audioSource.Play();
		doorIsClosed = false;
		openAnim.SetTrigger("Open");
	}

	private void CloseDoor()
	{
		audioSource.Play();
		doorIsClosed = true;
		openAnim.SetTrigger("Close");
	}
}

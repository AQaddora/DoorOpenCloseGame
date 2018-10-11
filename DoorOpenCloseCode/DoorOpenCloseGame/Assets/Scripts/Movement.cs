using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 30;

	float verticalMove, horizontalMove;

	private Rigidbody rb;
	Animator anim;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

		horizontalMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		verticalMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		if(transform.position.y < -1)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
	}

	private void FixedUpdate()
	{
		transform.Translate(new Vector3(horizontalMove, 0, verticalMove));
		anim.SetFloat("Speed", Mathf.Abs(verticalMove) + Mathf.Abs(horizontalMove));
	}
}

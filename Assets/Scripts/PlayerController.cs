using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int count;
	public Text countText;
	public Text winText;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		countText.text = "";
		winText.text = "";
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(0);
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick"))
		{
			other.gameObject.SetActive (false);
		}
		MakeCount ();
	}

	void MakeCount () {
		count += 1;
		countText.text = count.ToString ();
		if (count >= 12) {
			winText.text = "You done...?";
		}
	}


}

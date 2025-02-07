using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float force;
	private Vector3 movement;
	private Rigidbody rb;

	void Start () {

		rb = GetComponent<Rigidbody>();
	}
	
	void Update () {

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		movement = new Vector3(horizontal, 0.5f, vertical);
		rb.AddForce(movement * force * Time.deltaTime);

	}

	void OnTriggerEnter(Collider obj){
		//If the player touchs the final goal
		if(obj.gameObject.tag == "Final"){
			if(Application.loadedLevelName == "mazeLevel_1"){
				Application.LoadLevel("mazeLevel_2");
			}else{
				Application.LoadLevel("mazeLevel_1");
			}
		}

	}

}

using UnityEngine;
using System.Collections;

public class ControllerCamera : MonoBehaviour {

	public GameObject player;
	private Vector3 offSet;

	void Start () {
		//get vector between player and maincamera
		offSet = this.transform.position - player.transform.position;
	}
	
	void Update () {
		//update main camera position with the initial offSet vector
		this.transform.position = player.transform.position + offSet;
	}


}

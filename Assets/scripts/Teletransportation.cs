using UnityEngine;
using System.Collections;

public class Teletransportation : MonoBehaviour {

	public GameObject targetPortal;
	private GameObject player;
	//this static flag allows to controll infinite teletransportation between portals on the scene
	public static bool colliderFlag;

	void Start () {
		//Get instance of the player to get its current position. 
		player = GameObject.FindGameObjectWithTag("Player");
		colliderFlag = false;

	}
	
	void Update () {}

	void OnTriggerEnter (Collider  col)
	{
		//if the player collides with a portal and the flag is down
		if(col.gameObject.tag == "Player" && !colliderFlag)
		{
			MoveTowardsTarget();
			//make the flag true to avoid infinite teletransportation
			//like the flag is static, all portals will have the flag true
			colliderFlag = true;

		}
	}

	void OnTriggerExit(Collider  col){
		//start Coroutine to wait time without interrupt the main thread
		StartCoroutine (flagController());
	}

	/*
	 * This method moves towards a target at a set speed.
	 */
	private void MoveTowardsTarget() {
		//offset vector to avoid that the player falls down below the floor.
		Vector3 offPortalSetVector = new Vector3(targetPortal.transform.position.x, targetPortal.transform.position.y + 0.2f, targetPortal.transform.position.z);
		player.transform.position = Vector3.MoveTowards(this.transform.position, offPortalSetVector, 100);
	}

	/*
	 * This method is called when the player exits to any portal, to down the flag and allow next teletransportation
	 */
	IEnumerator flagController(){
		float SECONDS_TO_WAIT = 0.5f;
		yield return new WaitForSeconds(SECONDS_TO_WAIT);
		colliderFlag = false;
	}



}




















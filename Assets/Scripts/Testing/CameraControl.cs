using UnityEngine;
using System.Collections;
using C;

public class CameraControl : MonoBehaviour {
    
	public Transform standardPos;
	public float smooth = 3000f;
	public int numCheckPoints = 5;

	private Vector3 relCameraPos;       // The relative position of the camera from the player.
	private float relCameraPosMag;      // The distance of the camera from the player.

	private Vector3 newPos;
	public Transform player;

	void Awake() {
		relCameraPos = standardPos.position - (player.position);
		relCameraPosMag = relCameraPos.magnitude;

		newPos = standardPos.position;
	}

	void Update() {

		// The abovePos is directly above the player at the same distance as the standard position.
		Vector3 abovePos = (player.position) + Vector3.up * relCameraPosMag;

		// An array of 5 points to check if the camera can see the player.
        Vector3[] checkPoints = new Vector3[numCheckPoints];

		// The first is the standard position of the camera.
        checkPoints[0] = standardPos.position;
        Debug.DrawRay(player.position, checkPoints[0] - (player.position), Color.blue);

		// The last is the abovePos.
		checkPoints[checkPoints.Length-1] = abovePos;
		Debug.DrawRay(player.position, checkPoints[checkPoints.Length - 1] - (player.position), Color.blue);


		for (int i = 1; i < checkPoints.Length-1; i++) {
            checkPoints[i] = Vector3.Lerp(standardPos.position, abovePos, (float)i/checkPoints.Length);
			Debug.DrawRay(player.position, checkPoints[i] - (player.position), Color.blue);
        }

		for (int i = 0; i < checkPoints.Length; i++) {
			if (ViewingPosCheck(checkPoints[i])) {
				newPos = checkPoints[i];
                Debug.Log("Found Point: "+i+" -> "+checkPoints[i]);
				break;
			}
		}


		transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);

		Vector3 relPlayerPos = player.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPos, Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookAtRotation, smooth * Time.deltaTime);
	}

	bool ViewingPosCheck(Vector3 checkPos) {
		RaycastHit hit;
		Debug.DrawRay(player.position, checkPos - (player.position), Color.blue);
		if (Physics.Raycast(player.position , checkPos - (player.position), out hit)) {
            if (hit.transform.gameObject != GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA)) {
				return false;
			}
		}
		return true;
	}
}
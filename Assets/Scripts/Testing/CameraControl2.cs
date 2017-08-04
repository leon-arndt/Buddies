using UnityEngine;
using System.Collections;
using C;

public class CameraControl2 : MonoBehaviour {

    GameObject[] checkPoints;

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

		// The abovePos is directly above the player at the same distance as the standard position.
		Vector3 abovePos = (player.position) + Vector3.up * relCameraPosMag;
		// An array of 5 points to check if the camera can see the player.
		checkPoints = new GameObject[numCheckPoints];

		// The first is the standard position of the camera.
		checkPoints[0] = new GameObject("CamPoint0");
        checkPoints[0].transform.parent = player.parent;
        checkPoints[0].transform.position = standardPos.position;

		// The last is the abovePos.
		checkPoints[checkPoints.Length - 1] = new GameObject("CamPoint" + (checkPoints.Length - 1));
		checkPoints[checkPoints.Length - 1].transform.parent = player.parent;
        checkPoints[checkPoints.Length - 1].transform.position = abovePos;

		for (int i = 1; i < checkPoints.Length - 1; i++) {
            GameObject go = new GameObject("CamPoint" + i);
            go.transform.parent = player.parent;
            go.transform.position = Vector3.Lerp(standardPos.position, abovePos, (float)i / (checkPoints.Length-1));
            checkPoints[i] = go;
        }
	}

	void Update() {
		for (int i = 0; i < checkPoints.Length; i++) {
            Debug.DrawRay(player.position, checkPoints[i].transform.position - (player.position), Color.blue);
		}

		for (int i = 0; i < checkPoints.Length; i++) {
            if (ViewingPosCheck(checkPoints[i].transform.position)) {
                newPos = checkPoints[i].transform.position;
                Debug.Log("Found Point: " + i + " -> " + checkPoints[i].transform.position);
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
		if (Physics.Raycast(player.position, checkPos - (player.position), out hit)) {
			if (hit.transform.gameObject != GameObject.FindGameObjectWithTag(Tags.MAIN_CAMERA)) {
				return false;
			}
		}
		return true;
	}
}
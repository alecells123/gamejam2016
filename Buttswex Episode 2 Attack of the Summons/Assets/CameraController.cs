using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	float margin = 1.5f;
	private float z0 = 0f;
	private float zCam;
	private float wScene;
	private Transform f1;
	private Transform f2;
	private float xL;
	private float xR;

	void calcScreen(Transform p1, Transform p2){
		if (p1.position.x < p2.position.x) {
			xL = p1.position.x - margin;
			xR = p2.position.x + margin;
		} else {
			xL = p2.position.x - margin;
			xR = p1.position.x + margin;
		}
	}

	// Use this for initialization
	void Start () {
		f1 = GameObject.Find ("Fighter1").transform;
		f2 = GameObject.Find ("Fighter2").transform;

		calcScreen (f1, f2);
		wScene = xR - xL;
		zCam = transform.position.z - z0;
	}
	
	// Update is called once per frame
	void Update () {
		calcScreen (f1, f2);
		float width = xR - xL;

		if (width > wScene) {
			transform.position = new Vector3(transform.position.x, transform.position.y, zCam * width / wScene + z0);
		}

		transform.position = new Vector3 ((xR + xL) / 2, transform.position.y, transform.position.z);

	}
}

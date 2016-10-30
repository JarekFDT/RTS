using UnityEngine;
using System.Collections;

public class MouseClickMove : MonoBehaviour {
	Vector3 newPosition;
	float duration = 5.0f;
	float objectOriginalYAxis;
	// Use this for initialization
	void Start () {
		objectOriginalYAxis = transform.position.y;
		newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)) {
				newPosition = hit.point;
				newPosition.y = objectOriginalYAxis;
			}
		}

		transform.position = Vector3.Lerp(transform.position, newPosition, 1 / (duration * (Vector3.Distance (transform.position, newPosition))));
	}
}

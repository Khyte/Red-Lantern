using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    public Transform camPos;

	
	void Update () {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0.0f && camPos.localPosition.z < -2.4f) {
            camPos.localPosition += new Vector3(0, 0, scroll);
        }
        else if (scroll < 0.0f && camPos.localPosition.z > -7f) {
            camPos.localPosition += new Vector3(0, 0, scroll);
        }
    }
}
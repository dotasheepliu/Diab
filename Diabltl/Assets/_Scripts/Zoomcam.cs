using UnityEngine;
using System.Collections;

public class Zoomcam : MonoBehaviour {

	void OnEnable () {
		EasyTouch.On_Swipe += On_Swipe;
		EasyTouch.On_Drag += On_Drag;
		EasyTouch.On_PinchIn += On_PinchIn;
		EasyTouch.On_PinchOut += On_PinchOut;
	}

	void OnDestroy () {
		EasyTouch.On_Swipe -= On_Swipe;
		EasyTouch.On_Drag -= On_Drag;
		EasyTouch.On_PinchIn -= On_PinchIn;
		EasyTouch.On_PinchOut -= On_PinchOut;
	}

	void On_Drag (Gesture gesture) {
		On_Swipe (gesture);
	}

	void On_Swipe (Gesture gesture) {
		transform.Translate (Vector3.left * gesture.deltaPosition.x / Screen.width * transform.localPosition.y * 1.2f);
		transform.Translate (new Vector3 (0, -1, -1) * gesture.deltaPosition.y / Screen.height * transform.localPosition.y / 1.6f * 1.2f);
	}

	void On_PinchIn (Gesture gesture) {
		if (transform.localPosition.y < 2.4f) {	
			transform.Translate (Vector3.back * 0.06f * transform.localPosition.y);
		}
	}

	void On_PinchOut (Gesture gesture) {	
		if (transform.localPosition.y > 0.8f) {	
			transform.Translate (Vector3.forward * 0.06f * transform.localPosition.y);
		}
	}
}

using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes{
		MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}
	public float speedXY = 5f; // mouse movement speed horizontal and vertical
	public RotationAxes axes = RotationAxes.MouseXandY;
	private float minVerticalY = -45f;
	private float maxVerticalY = 45f;
	private float _rotationX = 0; // declared for vertical angle

	void Start(){
		Rigidbody playerBody = GetComponent <Rigidbody> ();
		if(playerBody!=null){
			playerBody.freezeRotation = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if(axes == RotationAxes.MouseX){
			// horizontal rotation here
			transform.Rotate (0, Input.GetAxis("Mouse X")*speedXY, 0f);
		}
		else if(axes == RotationAxes.MouseY){
		/*
		what this code does is simply 
1) the new x-rotation is saved into the variable _rotationX
2) you dont want the y-rotation to change! so what do you do? you save it into the variable rotationY
     by calling  float rotationY = transform.localEulerAngles.y;
		*/	
			
			// vertical rotation here
			_rotationX -= Input.GetAxis ("Mouse Y") * speedXY;
			_rotationX = Mathf.Clamp (_rotationX, minVerticalY, maxVerticalY);

			float rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
		else{
			// both rhorizontal and vertical rotaion here
			_rotationX -= Input.GetAxis ("Mouse Y") * speedXY;
			_rotationX = Mathf.Clamp (_rotationX, minVerticalY, maxVerticalY);
			// increment the rotation angle by delta
			float delta = Input.GetAxis ("Mouse X") * speedXY;
			float rotationY = transform.localEulerAngles.y + delta; // The rotation as Euler angles in degrees relative to the parent transform's rotation.

			transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
		}
	}
}

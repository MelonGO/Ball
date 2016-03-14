using UnityEngine;
using System.Collections;

public class TouchControl1 : MonoBehaviour {

	public float movementSpeed = 10.0f;
	private Vector3 horizontalMovement;
	
	private Vector3 verticalMovement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 &&
		    Input.GetTouch(0).phase == TouchPhase.Moved) {

			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

			horizontalMovement = touchDeltaPosition.x * Vector3.right * movementSpeed;
			verticalMovement = touchDeltaPosition.y * Vector3.forward * movementSpeed;
			
			Vector3 movement = horizontalMovement + verticalMovement;
			
			rigidbody.AddForce(movement, ForceMode.Force);

		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Pickup")
		{
			CrazyBallManager1.CB.FoundGem();
			
			Destroy(other.gameObject);
		}
		else
		{
			
		}
	}
}

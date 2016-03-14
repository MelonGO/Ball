using UnityEngine;
using System.Collections;

public class MarbleControl : MonoBehaviour {

    public float movementSpeed = 6.0f;
	private Vector3 horizontalMovement;
	private Vector3 verticalMovement;
	void Update () {
		horizontalMovement=Input.GetAxis("Horizontal") * Vector3.right * movementSpeed;
		verticalMovement=Input.GetAxis("Vertical") * Vector3.forward *movementSpeed;
        Vector3 movement = horizontalMovement+verticalMovement;
        rigidbody.AddForce(movement, ForceMode.Force);
	}

    void OnTriggerEnter  (Collider other  ) {
        if (other.tag == "Pickup")
        {
            MarbleGameManager.SP.FoundGem();
            Destroy(other.gameObject);
        }
        else
        {
            //Other collider.. See other.tag and other.name
        }        
    }

}

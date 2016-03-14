using UnityEngine;
using System.Collections;
public class BallControl_2 : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    private Vector3 horizontalMovement;

    private Vector3 verticalMovement;
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * Vector3.left * movementSpeed;
        verticalMovement = Input.GetAxis("Vertical") * Vector3.back * movementSpeed;

        Vector3 movement = horizontalMovement + verticalMovement;

        rigidbody.AddForce(movement, ForceMode.Force);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
			CrazyBallManager2.CB.FoundGem();

            Destroy(other.gameObject);
        }
        else
        {

        }
    }
}
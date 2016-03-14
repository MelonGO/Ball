using UnityEngine;
using System.Collections;

public class BallCamera : MonoBehaviour
{

    public Transform target;

	public float unknown = 0.0f;

    public float relativeHeigth = 10.0f;

    public float zDistance = 5.0f;

    public float dampSpeed = 5.0f;

    void Update()
    {

        Vector3 newPos = target.position + new Vector3(unknown, relativeHeigth, -zDistance);

        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);
    }
}
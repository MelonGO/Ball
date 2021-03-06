using UnityEngine;
using System.Collections;

public class MarbleCamera : MonoBehaviour
{
    //跟随的目标物体
    public Transform target;
    //与目标物体的相对高度
    public float relativeHeigth = 10.0f;
    //与目标物体的相对高度
    public float zDistance = 5.0f;
    //阻尼速度
    public float dampSpeed = 2;

    void Update()
    {

        Vector3 newPos = target.position + new Vector3(0, relativeHeigth, -zDistance);
        //像弹簧一样跟随目标物体
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);
    }
}

using UnityEngine;
using System.Collections;

public class MarbleCamera : MonoBehaviour
{
    //�����Ŀ������
    public Transform target;
    //��Ŀ���������Ը߶�
    public float relativeHeigth = 10.0f;
    //��Ŀ���������Ը߶�
    public float zDistance = 5.0f;
    //�����ٶ�
    public float dampSpeed = 2;

    void Update()
    {

        Vector3 newPos = target.position + new Vector3(0, relativeHeigth, -zDistance);
        //�񵯻�һ������Ŀ������
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerrFollowcamera : MonoBehaviour
{
    //�J�����ʒu���v���C���[�̈ʒu�ɍ��킹�ĕύX����

    Vector3 CameraPosition = Vector3.zero;

    public GameObject followTarget;

    public float followSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        CameraPosition = followTarget.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            followTarget.transform.position - CameraPosition,
            Time.deltaTime * followSpeed
            );
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

    }

    void Update()
    {
        //�v���C���[�̈ړ��ɍ��킹�ăJ�������ړ�������
        Vector3 playerPosition = player.transform.position;
        transform.position = new Vector3(playerPosition.x, transform.position.y, transform.position.z);

    }
}

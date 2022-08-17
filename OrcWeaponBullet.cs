using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcWeaponBullet : MonoBehaviour
{
    Vector3 defaultPosition;

    float speed = 7.0f;
    float maxDistance = 100.0f;

    void Start()
    {
        defaultPosition = transform.position;
    }

    void Update()
    {
        //���݂̋������ő勗���𒴂�������ł�����
        float distance = Vector3.Distance(transform.position, defaultPosition);

        if (distance > maxDistance)
            Destroy(gameObject);

        else
            transform.Translate(Vector3.left * Time.deltaTime * speed);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //�v���C���[�ɓ���������HP�����炷
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();
            
            //�v���C���[�ɂ�������e�����ł�����
            Destroy(gameObject);

        }

        else if(collision.tag == "PlayerGuard")
        {
            //�v���C���[�ɂ�������e�����ł�����
            Destroy(gameObject);
        }
    }
}

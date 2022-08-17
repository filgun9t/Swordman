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
        //現在の距離が最大距離を超えたら消滅させる
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
            //プレイヤーに当たったらHPを減らす
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();
            
            //プレイヤーにあったら弾を消滅させる
            Destroy(gameObject);

        }

        else if(collision.tag == "PlayerGuard")
        {
            //プレイヤーにあったら弾を消滅させる
            Destroy(gameObject);
        }
    }
}

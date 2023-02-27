using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static Bullet instance;
    public float speed;
    


    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        bulllet();

    }

    private void bulllet()
    {      
            transform.position += transform.up * speed * Time.deltaTime;
            Destroy(gameObject, 2f);

        if ( Attack.Instance.isBulletSpeed)
        {
            transform.position += transform.up * speed * 2 * Time.deltaTime;
            Destroy(gameObject, 2f);
        }
    }
}

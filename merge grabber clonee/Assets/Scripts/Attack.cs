using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public static Attack Instance;
    [SerializeField] GameObject ammo;
    [SerializeField] Transform fire;
    public float initialInstantiateSpeed ;
    public float speedIncreasePerTrigger ;
    [SerializeField] float currentInstantiateSpeed;
    [SerializeField] float timer;
    [SerializeField] bool isTrigger = false;
    public bool isBulletSpeed = false;
    public bool isDamage = false;
    void Start()
    {
        Instance = this;
        currentInstantiateSpeed = initialInstantiateSpeed;
        timer = 0f;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= currentInstantiateSpeed )
        {
            if(GameManager.instance.isStart && !GameManager.instance.isGameOver && !GameManager.instance.isFinish)
             Instantiate(ammo, fire.position, Quaternion.Euler(90f, 0f, 0f)); 
           
            timer = 0f;

        }
        if (isTrigger)
        { currentInstantiateSpeed = speedIncreasePerTrigger; }
       if(isBulletSpeed)
        { currentInstantiateSpeed = 0.125f; }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "wall")
        {
            isTrigger = true;
        }

        if(other.gameObject.tag =="wallSpeed")
        {
            isBulletSpeed = true;
        }
        if(other.gameObject.tag == "damage")
        {
            isDamage = true;
        }

    }

   
}

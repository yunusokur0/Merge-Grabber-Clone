using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toStart : MonoBehaviour
{
   
   private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
           
            gameObject.SetActive(false);
            GameManager.instance.isStart = true;
        }

    }
}

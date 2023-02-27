using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float forwartspeed;
    [SerializeField] private float borderx;
    private float endPosx;
    private Vector3 firstTouchPos;
    private Vector3 leftTouchPos;
    private float sensibility = 0.03f;

    void Update()
    {
        input();
    }


    private void input()
    {

        if (!GameManager.instance.isStart || GameManager.instance.isGameOver || GameManager.instance.isFinish)
        { return; }
 
        transform.position += new Vector3(0, 0, forwartspeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {

            firstTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {

            leftTouchPos = Input.mousePosition;

            Vector2 touchDelta = (leftTouchPos - firstTouchPos);

            endPosx = (transform.position.x + (touchDelta.x * sensibility));

            endPosx = Mathf.Clamp(endPosx, -borderx, borderx);

            transform.position = new Vector3(endPosx, transform.position.y, transform.position.z);

            firstTouchPos = Input.mousePosition;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
            UIManager.instance.fail();

        if (other.gameObject.tag == "Finish")
            UIManager.instance.win();
    }
}

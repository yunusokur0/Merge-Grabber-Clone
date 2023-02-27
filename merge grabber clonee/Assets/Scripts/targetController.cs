using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class targetController : MonoBehaviour
{
    [SerializeField] GameObject textObje;
    [SerializeField] TMP_Text text = null;
    [SerializeField] int textNumber = 0;
   
    private void Awake()
    {

        GenerateRandomGateNumber();
    }

    void Update()
    {
        
    }


    private void GenerateRandomGateNumber()
    {
        textNumber = Random.Range(20, 30);
        SetGateText();
    }

    private void SetGateText()
    {
        text.text = textNumber.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("bullet"))
        {
            sayiAzalt();
            Destroy(other.gameObject);
        }
        
    }

    private void sayiAzalt()
    {
        TextMeshPro targetText = transform.GetChild(0).GetComponent<TextMeshPro>();
        int targetint = System.Convert.ToInt32(targetText.text);
        if(!Attack.Instance.isDamage)
        {
            targetint -= 2;
            targetText.text = targetint.ToString();
        }
       

        if(Attack.Instance.isDamage)
        {
            targetint -= 6;
            targetText.text = targetint.ToString();
        }

        if (targetint <= 0)
        {
         
            Destroy(gameObject);
        }

    }
}

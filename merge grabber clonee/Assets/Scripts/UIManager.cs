using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] Image fillRateImage;
    [SerializeField] GameObject player;
    [SerializeField] GameObject finishLine;
    [SerializeField] GameObject again;
    [SerializeField] GameObject againButton;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject success;


    void Awake()
    {
        instance = this;    
    }

    
    void Update()
    {
        fillRateImage.fillAmount = (player.transform.position.z) / (finishLine.transform.position.z);       
    }

    public void fail()
    {
        GameManager.instance.isGameOver = true;
        againButton.SetActive(true);
        again.SetActive(true);
    }

    public void win()
    {
        GameManager.instance.isFinish = true;
        success.SetActive(true);
        nextButton.SetActive(true);
    }
}

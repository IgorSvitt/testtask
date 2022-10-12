using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    [SerializeField] private Text speedText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text distantText;

    private string mySpeedText;
    private string myTimeText;
    private string myDistantText;
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject finish;

    public static float speedMain = 5f;
    private float distant = 40f;
    private float time = 2f;

    private Vector3 targVector3;

    private float TimeLeft = 2f;

    [SerializeField] private Text textNow;

    private void Awake()
    {
        distant = 40f;
        finish.transform.position = new Vector3(distant - 20, finish.transform.position.y, finish.transform.position.z);
        speedMain = 5f;
        time = 2f;
    }


    private void Update()
    {
        textNow.text = "Speed - " + speedMain.ToString()+ " " + "Time - " + time.ToString()+ " " + "Distant - " + distant.ToString();
        
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            TimeLeft = time;
            Instantiate(player, new Vector3(-20, 1, 4), Quaternion.identity);
        }
    }
    
    public void SaveInputSpeedText()
    {
        float lastSpeed = speedMain;
        
        mySpeedText = speedText.text;
        float.TryParse(mySpeedText, out speedMain);

        if (speedMain < 1 || speedMain > 50)
        {
            speedMain = lastSpeed;
        }
    }
    
    public void SaveInputDistantText()
    {
        float lastDistant = distant;
        
        myDistantText = distantText.text;
        float.TryParse(myDistantText, out distant);

        if (distant < 0 || distant > 40)
        {
            distant = lastDistant;
        }
        finish.transform.position = new Vector3(distant - 20, finish.transform.position.y, finish.transform.position.z);
    }
    
    public void SaveInputTimeText()
    {
        float lastTime = time;
        
        myTimeText = timeText.text;
        float.TryParse(myTimeText, out time);
        if (time < 1)
        {
            time = lastTime;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    private Vector3 targVector3;
    public Controller Controller;

    private float speed = 5f;

    [SerializeField] private GameObject finish;


    private void Start()
    {
        speed = Controller.speedMain;
    }

    void Update()
    {
        speed = Controller.speedMain;
        var position = transform.position;
        targVector3 = position + Vector3.right;
        position = Vector3.MoveTowards(position, targVector3, speed/50);
        transform.position = position;

        if (transform.position.x > finish.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}

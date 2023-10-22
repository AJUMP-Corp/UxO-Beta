using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAB : MonoBehaviour
{
    [SerializeField] private Transform[] WalkingAtoB;
    private int currentPoint;
    private float lastPoint;
    [SerializeField] private float Speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Walking();
        FaceToSide();
    }

    private void Walking()
    {
        transform.position = Vector2.MoveTowards(transform.position, WalkingAtoB[currentPoint].position, Speed * Time.deltaTime);

        if (transform.position == WalkingAtoB[currentPoint].position)
        {
            currentPoint += 1;
            lastPoint = transform.localPosition.x;
        }

        if (currentPoint >= WalkingAtoB.Length)
        {
            currentPoint = 0;
        }
    }

    private void FaceToSide()
    {
        if (transform.localPosition.x > lastPoint)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (transform.localPosition.x < lastPoint)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

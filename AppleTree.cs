using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed = 1f; //Скорость яблони
    public float leftAndRightEdge = 24.5f; //Растояние сцены с края до края в игре
    public float chanceToChangeDirections = 0.1f; //Вереятность измиенение направление
    public float secondsBetweenAppleDrops = 1f;//частота создание яблок

    public void Start()
    {
        Invoke("DropApple", 2f);
    }

   public void DropApple() 
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    public void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        
    }

    public void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}

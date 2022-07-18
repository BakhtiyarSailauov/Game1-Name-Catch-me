using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamicaly")]
    public Text scoreGT;

    public void Start()
    {
        GameObject scoreGO = GameObject.Find("Score Counter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }
    public void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject coollidedWith = collision.gameObject;
        if (coollidedWith.tag == "Apple")
        {
            Destroy(coollidedWith);
        
        //внизу мы создаем счетчик для игры
        int score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();

        if (score>HighScore.score)
        {
                HighScore.score = score;
        }

        }
        


    }

}

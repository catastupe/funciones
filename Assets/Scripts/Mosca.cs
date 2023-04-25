using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
    public bool hasKey;
    public int livesCount = 3;
    public TextMeshProUGUI txtLives;
    public int points = 0;
    public TextMeshProUGUI txtpoint;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        
    }

    private void Update()
    {
        if (hasKey)
        {
            Debug.Log("Tiene la llave");
        }
    }

    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damager"))
        {
            LoseALife();
            
        } else if (collision.gameObject.CompareTag("coin"))
        {
            ScorePoint();
            Destroy(collision.gameObject);
        } 
    }
    void LoseALife()
    {
        transform.position = initialPosition;
        livesCount--;
        txtLives.text = livesCount.ToString();

        if (livesCount == 0)
        {
            PlayerDeath();
        }
    }
    void PlayerDeath()
    {
            Destroy(gameObject);
}
    void ScorePoint()
    {
        points++;
        txtpoint.text = points.ToString();
    }
}

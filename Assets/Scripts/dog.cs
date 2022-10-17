using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog: MonoBehaviour
{

    public float speed;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();//tìm gameObject GameManager
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
      
        if (transform.position.z < -14)
        {
            Destroy(gameObject);
            gameManager.GameOver();

        }
    }
}

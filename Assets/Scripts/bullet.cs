using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bullet : MonoBehaviour
{

    
    public ParticleSystem explosionParticle;
    public float speed;
 
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > 30)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
        GameManager.instance.killCount++;
        GameManager.instance.UpdateKillCounterUI();
    }
}

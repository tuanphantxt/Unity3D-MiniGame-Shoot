using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    private float horizontalInput;
    public float speed = 20f;
    public float XRange = 12f;

    public AudioClip ShootSound;

    private AudioSource ShootAudio;
    // Start is called before the first frame update
    void Start()
    {
        ShootAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        playerCheckXrange();
        playerShoot();
    }

    private void playerMove()
    {
       if(GameManager.instance.isGameActive) 
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
    }


    //check không cho ra khỏi phạm vi
    void playerCheckXrange()
    {

        if (transform.position.x < -XRange)
        {
            transform.position = new Vector3(-XRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > XRange)
        {
            transform.position = new Vector3(XRange, transform.position.y, transform.position.z);
        }
    }


    //hàm bắn
    void playerShoot()
    {
        if(Input.GetKeyDown(KeyCode.Space) && GameManager.instance.isGameActive)
        {
            // Instantiate tao ban sao doi tuong da ton tai 
            // transform.position vi tri duoc sinh ra o day la player
            //projectilePrefab.transform.rotation khong cho xoay
            Instantiate(bullet, transform.position + Vector3.up * +1.5f, bullet.transform.rotation);
            ShootAudio.PlayOneShot(ShootSound);

        }
    }

   
}

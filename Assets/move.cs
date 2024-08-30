using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move : MonoBehaviour
{
    //camera
    Vector3 offset;
    Vector3 newpos;
    public GameObject player;
    public GameObject cam;
    public float speed = 10.0f;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    public Rigidbody collect;
    private int count;
    private int spawn_count;
    public AudioSource src;
    public AudioClip sfx_break;
    public AudioClip sfx_win;
    

    void Start()
    {
        //camera move
        offset = player.transform.position - cam.transform.position;
        //others
        rb = GetComponent<Rigidbody>();
        count = 0;
        spawn_count = 4;
        //text
        winText.text = "";
        setCountText();
        //gyro move
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //camera move
        newpos = cam.transform.position;
        newpos.x = player.transform.position.x - offset.x;
        newpos.z = player.transform.position.z - offset.z;
        cam.transform.position = newpos;
        //gyro move
        Vector3 acc = Input.acceleration;
        rb.AddForce(acc.x * speed, 0, acc.y * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            src.clip = sfx_break;
            src.Play();
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            if (spawn_count > 0)
            {
                Vector3 rsp = new Vector3(UnityEngine.Random.Range(12, -12), 1, UnityEngine.Random.Range(12, -12));
                Instantiate(collect, rsp, Quaternion.identity);
                spawn_count--;
            }
        }
        if (other.gameObject.CompareTag("wall")) 
        {
            Debug.Log(spawn_count);
            count--;
            spawn_count++;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "count: " + count.ToString();
        if(count==10)
        {
            src.clip = sfx_win;
            src.Play();
            winText.text = "YOU WIN!!";
        }
    }
}

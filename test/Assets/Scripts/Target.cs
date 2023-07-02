using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public float life = 4;
    private Vector3 startPos;
    public float moveSpeed = 10f;
    public float frequency = 5f;
    public float magnitude = 5f;
    public float offset = 0f;
    public GameObject BlueDead;
    public GameObject BlackDead;
    public GameObject RedDead;
    public bool HitTarget = false;
    public static int BirdsKilled =0;
    void Start()
    {
        //Destroy(gameObject, life);
        startPos = transform.position;
        moveSpeed = Random.Range(2, 10);
        frequency = Random.Range(1, 5);
        magnitude = Random.Range(0.5f, 1.5f);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            BirdsKilled++;
            HitTarget = true;
            //Debug.Log("Hit target");
            Destroy(other.gameObject);
            string BirdName= transform.GetChild(0).name;
            switch (BirdName)
            {
                case "BlueDuck(Clone)":
                    Debug.Log("Hit BlueBird");
                    //Animator anim1 = transform.GetChild(0).GetComponent<Animator>();
                    transform.GetChild(0).gameObject.SetActive(false);
                    GameObject BlueBird = Instantiate(BlueDead, transform.GetChild(0).position, transform.GetChild(0).rotation);
                    BlueBird.GetComponent<Rigidbody>().useGravity = true;
                    Destroy(gameObject);
                    break;
                case "RedDuck(Clone)":
                    Animator anim2 = transform.GetChild(0).GetComponent<Animator>();
                    transform.GetChild(0).gameObject.SetActive(false);
                    GameObject RedBird = Instantiate(RedDead, transform.GetChild(0).position, transform.GetChild(0).rotation);
                    RedBird.GetComponent<Rigidbody>().useGravity = true;
                    Destroy(gameObject);
                    break;
                case "BlackDuck(Clone)":
                    Animator anim3 = transform.GetChild(0).GetComponent<Animator>();
                    transform.GetChild(0).gameObject.SetActive(false);
                    GameObject BlackBird = Instantiate(BlackDead, transform.GetChild(0).position, transform.GetChild(0).rotation);
                    BlackBird.GetComponent<Rigidbody>().useGravity = true;
                    Destroy(gameObject);
                    break;
            }
            

        }
    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(10f, 0f, 0f) * Time.deltaTime, Space.Self);
        //transform.position = startPos + transform.up * Mathf.Sin(Time.time + frequency + offset) * magnitude;

        startPos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = startPos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour {

    //PUBLIC FORCE TWEAKS
    [Header("Force tweaker")]
    public float headVelocityY;
    public float armRightVelocityY;
    public float armLeftVelocityY;
    public float footRightVelocityY;
    public float footLeftVelocityY;
    public float torsoVelocityY;

    //RIGIDBODIDES ON BODYPARTS
    /*Rigidbody2D head;
    Rigidbody2D armRight;
    Rigidbody2D armLeft;
    Rigidbody2D footRight;
    Rigidbody2D footLeft;
    Rigidbody2D torso;*/

    public Rigidbody2D head;
    public Rigidbody2D armRight;
    public Rigidbody2D armLeft;
    public Rigidbody2D footRight;
    public Rigidbody2D footLeft;
    public Rigidbody2D torso;

    //RANDOM VARIABLES
    float headVelocityX;
    float armRightVelocityX;
    float armLeftVelocityX;
    float footRightVelocityX;
    float footLeftVelocityX;
    float torsoVelocityX;

    //FORCE
    Vector2 headVelocity;
    Vector2 armRightVelocity;
    Vector2 armLeftVelocity;
    Vector2 footRightVelocity;
    Vector2 footLeftVelocity;
    Vector2 torsoVelocity;

    //ROTATION
    float headRotation;
    float armRightRotation;
    float armLeftRotation;
    float footRightRotation;
    float footLeftRotation;
    float torsoRotation;

    bool hasExploded;
    float timePassed;

    // Use this for initialization
    void Start () {
        timePassed = Time.time + 3;
        //FIND REFERENCES
        /*head = GameObject.Find("Head").GetComponent<Rigidbody2D>();
        armRight = GameObject.Find("Arm_Right").GetComponent<Rigidbody2D>();
        armLeft = GameObject.Find("Arm_Left").GetComponent<Rigidbody2D>();
        footRight = GameObject.Find("Foot_Right").GetComponent<Rigidbody2D>();
        footLeft = GameObject.Find("Foot_Left").GetComponent<Rigidbody2D>();
        torso = GameObject.Find("Torso").GetComponent<Rigidbody2D>();*/

        //GENERATE RANDOMNESS
        headVelocityX = Random.Range(-5, 6);
        headRotation = Random.Range(30, 70);

        armRightVelocityX = Random.Range(10, 20);
        armRightRotation = Random.Range(30, 70);

        armLeftVelocityX = Random.Range(-10, -20);
        armLeftRotation = Random.Range(-30, -70);

        footRightVelocityX = Random.Range(3, 10);
        footRightRotation = Random.Range(30, 70);

        footLeftVelocityX = Random.Range(-3, -10);
        footLeftRotation = Random.Range(-30, -70);

        torsoVelocityX = Random.Range(-3, -4);
        torsoRotation = Random.Range(-10, 10);

        //SETUP FORCES
        headVelocity = new Vector2(headVelocityX, headVelocityY);
        armRightVelocity = new Vector2(armRightVelocityX, armRightVelocityY);
        armLeftVelocity = new Vector2(armLeftVelocityX, armLeftVelocityY);
        footRightVelocity = new Vector2(footRightVelocityX, footRightVelocityY);
        footLeftVelocity = new Vector2(footLeftVelocityX, footLeftVelocityY);
        torsoVelocity = new Vector2(torsoVelocityX, torsoVelocityY);

        //SETUP ROTATION
        if (headVelocity.x > 0)
        {
            headRotation *= -1;
        }

        //INITIATE EXPLOSION
        Explode();
	}

    void Update()
    {
        //IF IT HAS EXPLODED AND 3 SECONDS HAVE PASSED, CHANGE SCENE!
        if (hasExploded && timePassed < Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Explode()
    {
        //ADD ALL VELOCITIES TO ALL 
        head.velocity = headVelocity;
        head.AddTorque(headRotation);

        armRight.velocity = armRightVelocity;
        armRight.AddTorque(armRightRotation);

        armLeft.velocity = armLeftVelocity;
        armLeft.AddTorque(armLeftRotation);

        footRight.velocity = footRightVelocity;
        footRight.AddTorque(footRightRotation);

        footLeft.velocity = footLeftVelocity;
        footLeft.AddTorque(footLeftRotation);

        torso.velocity = torsoVelocity;
        torso.AddTorque(torsoRotation);

        hasExploded = true;
    }
}

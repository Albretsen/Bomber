using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectiveExplosion : MonoBehaviour
{    
    //TWEAKABLE VARIABLES
    public float explosionForce;

    //REFERENCES
    public Rigidbody2D head;
    public Rigidbody2D armRight;
    public Rigidbody2D armLeft;
    public Rigidbody2D footRight;
    public Rigidbody2D footLeft;
    public Rigidbody2D torso;

    //
    Vector2 direction = new Vector2(1f, 0.1f);
    GameMaster gm;
    bool hasExploded = false;
    float timePassed;

    // Use this for initialization
    void Start()
    {
        timePassed = Time.time + 3;
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    void Update()
    {
        Vector2 dir = new Vector2(0, 0);
        direction = gm.Direction(dir, 2);
        if(direction.y > 0.01 || direction.x > 0.01 || direction.y < -0.01 || direction.x < -0.01)
        {
            Explode(direction);
        }

        //IF IT HAS EXPLODED AND 3 SECONDS HAVE PASSED, CHANGE SCENE!
        if(hasExploded && timePassed < Time.time)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Explode(Vector2 direction)
    {
        if (!hasExploded)
        {
            head.AddForce(direction * explosionForce * 1.2f, ForceMode2D.Impulse);
            armRight.AddForce(direction * explosionForce * 1.5f, ForceMode2D.Impulse);
            armLeft.AddForce(direction * explosionForce * 1.5f, ForceMode2D.Impulse);
            footRight.AddForce(direction * explosionForce * 1.35f, ForceMode2D.Impulse);
            footLeft.AddForce(direction * explosionForce * 1.35f, ForceMode2D.Impulse);
            torso.AddForce(direction * explosionForce * 1f, ForceMode2D.Impulse);

            hasExploded = true;
        }
    }
}

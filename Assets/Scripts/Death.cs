using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    public Transform Camera;
    public Vector3 RespawnPoint;
    public Vector3 CameraRespawn;
    public Movement Moving;
    public Scoring Score;
    public int EnemyKillScore = 200;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPoint = gameObject.transform.position;
        CameraRespawn = Camera.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided");
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "DeathBox" )
        {
            DoDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if(Moving.isDashing)
            {
                Destroy(col.gameObject);
                Score.UpdateScore(EnemyKillScore);
            }
            else
            {
                DoDeath();
            }

        }
    }

    public void DoDeath()
    {
        Debug.Log("Dead");
        //Destroy(gameObject);

        gameObject.transform.position = RespawnPoint;
        Camera.transform.position = CameraRespawn;
        Moving.setLocked(true);
        rb.velocity = new Vector2(0, 0);
    }
}

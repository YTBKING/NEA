using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissapear : MonoBehaviour
{

    public float dissapearTime = 5f;

    public float timer = 0f;

    private void OnCollision2DEnter(Collision2D col)
    {
        Debug.Log("Gone");
        if (col.gameObject.tag == "Player")
        {
            while (timer != dissapearTime) 
            {
                timer += Time.deltaTime;
            }

            Destroy(col.gameObject);
        }
    }
}

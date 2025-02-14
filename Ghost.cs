// SCRIPT DO FANTASMA
// DIREÇÃO DE A PARA B.
// TEM A COLISÃO

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform skin;

    public bool goRight;
  

    void Start()
    {
        
    }

    void Update()
    {
        if (goRight == true)
        {
            skin.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                transform.position = a.position;
            }

            transform.position = Vector2.MoveTowards(transform.position, b.position, 10f * Time.deltaTime);
        }
        else
        {
            skin.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                transform.position = b.position;
            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, 10f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}

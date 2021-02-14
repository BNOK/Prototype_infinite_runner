using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    public float scrollSpeed = 20f;
    private Vector3 startPos;
    private float repeatWidth;

    private CharacterController player;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        player = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Repeat();
        Move();
    }

    private void Repeat()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }

    private void Move()
    {
        if (player.gameOver == false)
        {
            transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosspatrol : MonoBehaviour
{
    public float moveSpeed;
    public bool moveleft;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;

    private float ySize;

    // Start is called before the first frame update
    void Start()
    {
        ySize = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge)
        {
            moveleft = !moveleft;
        }

        if (moveleft)
        {
            transform.localScale = new Vector3(ySize, transform.localScale.y, transform.localScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-ySize, transform.localScale.y, transform.localScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}

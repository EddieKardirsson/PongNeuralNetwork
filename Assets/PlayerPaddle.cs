using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    float yvel;
    public float paddleMinY = 8.8f;
    public float paddleMaxY = 17.4f;
    public float numSaved = 0;
    public float numMissed = 0;
    private Vector3 direction;

    [Range(1,20)]
    public float paddleSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float posy = Mathf.Clamp(rb.transform.position.y + (yvel * Time.deltaTime * paddleSpeed),
            paddleMinY, paddleMaxY);

        float input = Input.GetAxisRaw("Vertical");
        float translation = Time.deltaTime * input * paddleSpeed;
        if (input > 0)
        {
            if (transform.position.y >= paddleMaxY)
                direction = Vector3.zero;
            else
                direction = Vector3.up;
        }
        else if (input < 0)
        {
            if (transform.position.y <= paddleMinY)
                direction = Vector3.zero;
            else
                direction = Vector3.down;
        }
        else direction = Vector3.zero;
        
        transform.Translate(0, direction.y*paddleSpeed*Time.deltaTime, 0);
    }

    void FixedUpdate()
    {
        rb.AddForce(direction * paddleSpeed);
    }
}

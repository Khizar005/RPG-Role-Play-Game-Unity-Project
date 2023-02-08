using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float speed = 5f ;
    public string transitionAreaName;



    private Rigidbody2D rb;
    private Animator playerAnimator;



    private Vector3 bottomleftEdge;
    private Vector3 topRightEdge;

    public bool deactivateMovment = false;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

     
    }


    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        rb.velocity = speed * Time.deltaTime * new Vector2(horizontalMovement, verticalMovement);

        if (deactivateMovment == true)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {

            rb.velocity = speed * Time.deltaTime * new Vector2(horizontalMovement, verticalMovement);

        }
        playerAnimator.SetFloat("movementX", rb.velocity.x);
        playerAnimator.SetFloat("movementY", rb.velocity.y);

        if (horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            if (!deactivateMovment)
            {

            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
            }
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomleftEdge.x, topRightEdge.x),
               Mathf.Clamp(transform.position.y, bottomleftEdge.y, topRightEdge.y),
                  Mathf.Clamp(transform.position.z, bottomleftEdge.z, topRightEdge.z)

            );
    }

    public void SetLimit(Vector3 bottomEdgeToSet , Vector3 topEdgeToSet)
    {
        bottomleftEdge = bottomEdgeToSet;
        topRightEdge = topEdgeToSet;
    }
}

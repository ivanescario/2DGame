using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [Header("State Ground")]
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool wasGroundedLastFrame;
    [HideInInspector] public bool justGotGrounded;
    [HideInInspector] public bool justNOTGrounded;
    [HideInInspector] public bool isFalling;
    [HideInInspector] public bool isWall;
    [HideInInspector] public bool wasWallLastFrame;
    [HideInInspector] public bool justGotWall;
    [HideInInspector] public bool justNotWall;
    [HideInInspector] public bool isCeil;
    [HideInInspector] public bool wasCeilLastFrame;
    [HideInInspector] public bool justGotCeil;
    [HideInInspector] public bool justNotCeil;
    [Header("Permissions")]
    public bool checkGround;
    public bool checkWall;
    public bool checkCeiling;
    [Header("Filter properties")]
    public ContactFilter2D groundFilter;
    public int maxHits;
    [Header("Bottom box")]
    public Vector2 groundBoxPos; // amb el wall igual wallBoxPos... etc
    public Vector2 groundBoxSize;
    [Header("Wall box")]
    public Vector2 wallBoxPos;
    public Vector2 wallBoxSize;
    [Header("Ceiling box")]
    public Vector2 ceilingBoxPos;
    public Vector2 ceilingBoxSize;

    private void Start()
    {
        ResetState();
    }

    public void MyStart()
    {
    }

    void ResetState()
    {
        wasGroundedLastFrame = isGrounded;
        wasWallLastFrame = isWall;
        wasCeilLastFrame = isCeil;

        isGrounded = false;
        justGotGrounded = false;
        justNOTGrounded = false;
        isFalling = true;
        isWall = false;
        justGotWall = false;
        justNotWall = false;
        isCeil = false;
        justGotCeil = false;
        justNotCeil = false;
    }

    private void FixedUpdate()
    {
        ResetState();
        GroundDetection();
        if(checkGround)
        {
            GroundDetection();
        }

        WallDetection();
        if(checkWall)
        {
            WallDetection();
        }

        CeilingDetection();
        if (checkCeiling)
        {
            CeilingDetection();
        }
    }

    public void MyFixedUpdate()
    {
    }

    void GroundDetection()
    {
        Collider2D[] results = new Collider2D[maxHits];
        Vector2 pos = this.transform.position;
        int numHits = Physics2D.OverlapBox(pos + groundBoxPos, groundBoxSize, 0, groundFilter, results);

        if(numHits > 0)
        {
            isGrounded = true;
        }

        if(isGrounded) isFalling = false;
        if(isGrounded && !wasGroundedLastFrame) justGotGrounded = true;
        if(!isGrounded && wasGroundedLastFrame) justNOTGrounded = true;
    }

    void WallDetection()
    {
        Collider2D[] results = new Collider2D[maxHits];
        Vector2 pos = this.transform.position;
        int numHits = Physics2D.OverlapBox(pos + wallBoxPos, wallBoxSize, 0, groundFilter, results);

        if (numHits > 0)
        {
            isWall = true;
        }

        if (isWall) isFalling = false;
        if(isWall && !wasWallLastFrame) justGotWall = true;
        if(!isWall && wasWallLastFrame) justNotWall = true;
    }

    void CeilingDetection()
    {
        Collider2D[] results = new Collider2D[maxHits];
        Vector2 pos = this.transform.position;
        int numHits = Physics2D.OverlapBox(pos + ceilingBoxPos, ceilingBoxSize, 0, groundFilter, results);

        if (numHits > 0)
        {
            isCeil = true;
        }

        if (isCeil) isFalling = false;
        if (isCeil && !wasCeilLastFrame) justGotCeil = true;
        if (!isCeil && wasCeilLastFrame) justNotCeil = true;
    }

    private void OnDrawGizmos ()
    {
        Vector2 pos = this.transform.position;
        Gizmos.DrawWireCube(pos + groundBoxPos, groundBoxSize);

        Vector2 posWall = this.transform.position;
        Gizmos.DrawWireCube(posWall + wallBoxPos, wallBoxSize);

        Vector2 posCeiling = this.transform.position;
        Gizmos.DrawWireCube(posCeiling + ceilingBoxPos, ceilingBoxSize);
    }
}

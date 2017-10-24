using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    [Header("Physics2D.OverlapBox")]
    public Vector2 boxPos;
    public Vector2 boxSize;
    public LayerMask mask;
    [Header("Physics2D.OverlapCollider")]
    public Collider2D col;
    public ContactFilter2D filter;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        Collider2D[] results = new Collider2D[5];
        int numHits = Physics2D.OverlapBox(this.transform.position, boxSize, 0, filter, results);
        if(numHits > 0) Debug.Log("Se ha detectado un collider"); // Si collider no esta vacío

        //int n = Physics2D.OverlapCollider(col, filter, results);
        //Physics2D.OverlapCollider(col, filter, results);
    }

    private void OnDrawGizmosSelected() // Solo dibuja los gizmos de los objetos que están seleccionados
    {
        Gizmos.DrawWireCube(this.transform.position, boxSize);
    }
}

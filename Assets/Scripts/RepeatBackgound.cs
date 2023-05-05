using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgound : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

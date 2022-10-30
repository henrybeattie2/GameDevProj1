using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementJA : MonoBehaviour
{
    public float speed = 6f;
    public bool inCoolDown = false; 
    public Vector2 direction;

    private Vector2 rightEndpoint;
    // Start is called before the first frame update
    void Start()
    {
        direction.x = 0;
        direction.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pickingDirection();
        Vector3 newPosition = new Vector3(speed * direction.x * Time.deltaTime, speed * direction.y * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }

    private void pickingDirection()
    {
        if (inCoolDown == false)
        {
            inCoolDown = true;
            StartCoroutine(CoolDown());
            int temp = Random.Range(1, 4);
            if (temp == 1)
                StartCoroutine(moveRight());
            if (temp == 2)
                StartCoroutine(moveLeft());
            if (temp == 3)
                StartCoroutine(moveUp());
            if (temp == 4)
                StartCoroutine(moveDown());
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(10);
        inCoolDown = false;
    }
    IEnumerator moveRight()
    {
        direction.x = 1;
        yield return new WaitForSeconds(3);
        direction.x = -1;
        yield return new WaitForSeconds(3);
        direction.x = 0;
    }
    IEnumerator moveLeft()
    {
        direction.x = -1;
        yield return new WaitForSeconds(3);
        direction.x = 1;
        yield return new WaitForSeconds(3);
        direction.x = 0;
    }
    IEnumerator moveUp()
    {
        direction.y = 1;
        yield return new WaitForSeconds(3);
        direction.y = -1;
        yield return new WaitForSeconds(3);
        direction.y = 0;
    }
    IEnumerator moveDown()
    {
        direction.y = -1;
        yield return new WaitForSeconds(3);
        direction.y = 1;
        yield return new WaitForSeconds(3);
        direction.y = 0;
    }
}

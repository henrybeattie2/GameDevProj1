using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ShootHB : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject shootPoint;
    public float coolDownTime = 0.5f;

    public ParticleSystem shootPS;

    private bool inCoolDown = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !inCoolDown)
        {

            inCoolDown = true;

            shootPS.Play();

            GameObject go = Instantiate(Bullet);
            //go.transform.SetPositionAndRotation(shootPoint.transform.position, shootPoint.transform.rotation);
            go.transform.position = shootPoint.transform.position;
            go.transform.rotation = shootPoint.transform.rotation;
            BulletHB b = go.GetComponent<BulletHB>();
            b.speed = 20;

            StartCoroutine(CoolDown());
        }
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        inCoolDown = false;
    }

}


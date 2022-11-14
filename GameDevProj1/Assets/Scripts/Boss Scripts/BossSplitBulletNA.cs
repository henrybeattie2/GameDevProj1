using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSplitBulletNA : MonoBehaviour
{

    public GameObject SplitBullet;
    public Vector2 direction;
    public float speed = 5f;

    public ParticleSystem ImpactPS;

    private Vector3 BulletPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        BulletPosition = this.transform.position;
    }

    private void Move()
    {
        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 newPosition = new Vector3(speed * transform.up.x * Time.deltaTime, speed * transform.up.y * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "Boundary")
        {
            ImpactPS = Instantiate(ImpactPS);
            ImpactPS.transform.position = BulletPosition;
            var euler = transform.eulerAngles;
            euler.z = SplitBullet.transform.rotation.eulerAngles.z;
            ImpactPS.transform.eulerAngles = euler;
            ImpactPS.Play();
            Destroy(this.gameObject);
        }

        if (gameObject.tag == "Player")
        {
            ImpactPS = Instantiate(ImpactPS);
            ImpactPS.transform.position = BulletPosition;
            var euler = transform.eulerAngles;
            euler.z = SplitBullet.transform.rotation.eulerAngles.z;
            ImpactPS.transform.eulerAngles = euler;
            ImpactPS.Play();

            Destroy(this.gameObject);

        }
    }
}

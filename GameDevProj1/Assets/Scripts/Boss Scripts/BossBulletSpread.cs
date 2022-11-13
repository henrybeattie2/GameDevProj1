using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletSpread : MonoBehaviour
{
    public GameObject SpreadBullet;
    public Vector2 direction;
    public float speed = 5f;

    private GameObject Bullet;
    private GameObject Bullet2;
    private GameObject Bullet3;
    private GameObject Bullet4;
    private GameObject Bullet5;
    private GameObject Bullet6;
    private GameObject Bullet7;
    private GameObject Bullet8;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopTime());
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 currentPosition = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 newPosition = new Vector3(speed * transform.up.x * Time.deltaTime, speed * transform.up.y * Time.deltaTime, 0);
        this.transform.position += newPosition;
    }

    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(2);
        speed = 0;
        StartCoroutine(SplitTime());
    }

    IEnumerator SplitTime()
    {
        yield return new WaitForSeconds(2);

        Bullet = Instantiate(SpreadBullet);
        Bullet2 = Instantiate(SpreadBullet);
        Bullet3 = Instantiate(SpreadBullet);
        Bullet4 = Instantiate(SpreadBullet);
        Bullet5 = Instantiate(SpreadBullet);
        Bullet6 = Instantiate(SpreadBullet);
        Bullet7 = Instantiate(SpreadBullet);
        Bullet8 = Instantiate(SpreadBullet);

        //Bullet.GetComponent<BossSplitBulletNA>();

        Bullet.transform.position = this.transform.position;
        var euler = transform.eulerAngles;
        euler.z = Bullet.transform.localEulerAngles.z;
        Bullet.transform.eulerAngles = euler;

        Bullet2.transform.position = this.transform.position;
        var euler2 = transform.eulerAngles;
        euler2.z = euler.z + 45;
        Bullet2.transform.eulerAngles = euler2;

        Bullet3.transform.position = this.transform.position;
        var euler3 = transform.eulerAngles;
        euler3.z = euler.z + 90;
        Bullet3.transform.eulerAngles = euler3;

        Bullet4.transform.position = this.transform.position;
        var euler4 = transform.eulerAngles;
        euler4.z = euler.z + 135;
        Bullet4.transform.eulerAngles = euler4;

        Bullet5.transform.position = this.transform.position;
        var euler5 = transform.eulerAngles;
        euler5.z = euler.z + 180;
        Bullet5.transform.eulerAngles = euler5;

        Bullet6.transform.position = this.transform.position;
        var euler6 = transform.eulerAngles;
        euler6.z = euler.z + 225;
        Bullet6.transform.eulerAngles = euler6;

        Bullet7.transform.position = this.transform.position;
        var euler7 = transform.eulerAngles;
        euler7.z = euler.z + 270;
        Bullet7.transform.eulerAngles = euler7;

        Bullet8.transform.position = this.transform.position;
        var euler8 = transform.eulerAngles;
        euler8.z = euler.z + 315;
        Bullet8.transform.eulerAngles = euler8;

        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.tag == "Boundary")
        {
            //ImpactPS.Play();
            //speed = 0f;
            Destroy(this.gameObject);
        }

        if (gameObject.tag == "Player")
        {
            //BossImpactPS = Instantiate(BossImpactPS);
            //BossImpactPS.transform.position = BulletPosition;
            //var euler = transform.eulerAngles;
            //euler.z = bullet.transform.rotation.eulerAngles.z;
            //BossImpactPS.transform.eulerAngles = euler;

            //BossImpactPS.main.startRotation.Equals(bullet.transform.rotation);

            //BossImpactPS.Play();
            Destroy(this.gameObject);

        }
    }


}

using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public Vector3 speed = Vector3.zero;
    public float accel = 10;
    public float Rspeed = 300;
    public float Screenwidth = 1024.0f;
    public float Screenheight = 768;
    private Vector3 position;
    private Weapon arma;

    ParticleSystem[] Imulsores;

    // Use this for initialization
    void Start()
    {
        arma = this.GetComponent<Weapon>();
        position = this.transform.position;
        GameObject obj = GameObject.Find("Impulsores");
        Imulsores = obj.GetComponentsInChildren<ParticleSystem>();
        Imulsores[0].Stop();
        Imulsores[1].Stop();
    }

    // Update is called once per frame
    void Update()
    {


        position += speed * Time.deltaTime;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {

            this.transform.rotation *= Quaternion.AngleAxis(Rspeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, Vector3.forward);
        }

        if (Input.GetButton("Acelerar"))
        {
            Imulsores[0].Play();
            Imulsores[1].Play();
            this.speed += accel * this.transform.up * Time.deltaTime;
        }
        else
        {
            Imulsores[0].Stop();
            Imulsores[1].Stop();
        }

        if (Input.GetButtonDown("Disparar"))
        {
            arma.Shoot();
        }

        if (position.x < -Screenwidth / 2)
        {
            position.x = Screenwidth / 2;
        }
        if (position.x > Screenwidth / 2)
        {
            position.x = -Screenwidth / 2;
        }

        if (position.y < -Screenheight / 2)
        {
            position.y = Screenheight / 2;
        }
        if (position.y > Screenheight / 2)
        {
            position.y = -Screenheight / 2;
        }

        this.transform.position = position;
    }
}

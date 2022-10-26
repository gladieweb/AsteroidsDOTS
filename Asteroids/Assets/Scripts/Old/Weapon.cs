using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    [FormerlySerializedAs("BulletType")] public int bulletType = 1;

    public void Shoot()
    {
        GameObject bala = Pool.Create(bulletType);
        bala.transform.position = this.transform.position;
        bala.transform.up = this.transform.up;
    }
}

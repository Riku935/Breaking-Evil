using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFunction : Object_Interaction
{
    public GunData _gunData;

    [Header("Bullet Data")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private GameObject playerRecoil;

    void Start()
    {
        _gunData.currentCharger = _gunData.chargerSize;
        _gunData.currentReserved = _gunData.reservedAmmo;
    }

    private void Update()
    {
        Reload();
    }

    void Shoot()
    {
        if ( _gunData.canShoot && _gunData.currentCharger > 0)
        {
            _gunData.canShoot = false;
            _gunData.currentCharger--;
            StartCoroutine(ShootGun());
        }
    }
    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && _gunData.currentCharger < _gunData.chargerSize && _gunData.reservedAmmo > 0)
        {
            int ammoNeeded = _gunData.chargerSize - _gunData.currentCharger;
            if (ammoNeeded >= _gunData.currentReserved)
            {
                _gunData.currentCharger += _gunData.currentReserved;
                _gunData.currentReserved -= ammoNeeded;
            }
            else
            {
                _gunData.currentCharger = _gunData.chargerSize;
                _gunData.currentReserved -= ammoNeeded;
            }
        }
    }
    void Fire()
    {
        var bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
    void Recoil()
    {
        //transform.position -= Vector3.forward * 0.1f;
    }
    IEnumerator ShootGun()
    {
        Recoil();
        Fire();
        yield return new WaitForSeconds(_gunData.fireRate);
        _gunData.canShoot = true;
    }

    public override void Use()
    {
        base.Use();
        Shoot();
        
    }
}

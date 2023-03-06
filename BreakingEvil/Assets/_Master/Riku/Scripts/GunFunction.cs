using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFunction : MonoBehaviour
{
    public GunData _gunData;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    void Start()
    {
        _gunData.currentCharger = _gunData.chargerSize;
        _gunData.currentReserved = _gunData.reservedAmmo;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && _gunData.canShoot && _gunData.currentCharger > 0)
        {
            _gunData.canShoot = false;
            _gunData.currentCharger--;
            StartCoroutine(ShootGun());
        }
        else if (Input.GetKeyDown(KeyCode.R) && _gunData.currentCharger < _gunData.chargerSize && _gunData.reservedAmmo > 0)
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

    void Recoil()
    {
        transform.localPosition -= Vector3.forward * 0.1f;
    }
    void Fire()
    {
        var bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }

    IEnumerator ShootGun()
    {
        Recoil();
        Fire();
        yield return new WaitForSeconds(_gunData.fireRate);
        _gunData.canShoot = true;
    }
}

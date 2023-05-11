using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[AddComponentMenu("Nokobot/Modern Guns/Simple Shoot")]
public class SimpleShoot : MonoBehaviour
{
    public PistolData pistolRef;

    [Header("Prefab Refrences")]
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public TextMeshPro bulletText;

    [Header("References")]
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform barrelLocation;
    [SerializeField] private Transform casingExitLocation;

    [Header("Settings")]
    [Tooltip("Tiempo para destruir el casquillo")][SerializeField] private float destroyTimer = 2f;
    [Tooltip("velocidad de la bala")][SerializeField] private float shotPower = 500f;
    [Tooltip("velocidad de salida del cartucho")][SerializeField] private float ejectPower = 150f;

    public AudioSource source;
    public AudioClip fireSound;
    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;

        if (gunAnimator == null)
            gunAnimator = GetComponentInChildren<Animator>();

        pistolRef.currentAmmo = pistolRef.maxAmmo;
    }

    void Update()
    {
        bulletText.text = pistolRef.currentAmmo.ToString(); 
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    gunAnimator.SetTrigger("Fire");
        //}
    }
    [ContextMenu("Disparo")]
    public void PullTheTrigger()
    {
        if (pistolRef.currentAmmo > 0)
        {
            gunAnimator.SetTrigger("Fire");
        }
    }



    void Shoot()
    {
        source.PlayOneShot(fireSound);
        pistolRef.currentAmmo--;
        if (muzzleFlashPrefab)
        {
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            Destroy(tempFlash, destroyTimer);
        }


        if (!bulletPrefab)
        { return; }

        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);

    } 

    void CasingRelease()
    {
        if (!casingExitLocation || !casingPrefab)
        { return; }

        GameObject tempCasing;
        tempCasing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        tempCasing.GetComponent<Rigidbody>().AddExplosionForce(Random.Range(ejectPower * 0.7f, ejectPower), (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        tempCasing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(100f, 1000f)), ForceMode.Impulse);

        Destroy(tempCasing, destroyTimer);
    }

    void Reload()
    {
        pistolRef.currentAmmo = pistolRef.maxAmmo;
    }

}

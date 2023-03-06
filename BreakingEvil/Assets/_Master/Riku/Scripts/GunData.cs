using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon")]
public class GunData : ScriptableObject
{
    [Header("Gun Info")]
    public string gunName;

    public float damage;
    public float maxDistance;

    [Header("Ammo")]
    public int currentAmmo;
    public int chargerSize;
    public int currentCharger;
    public int reservedAmmo;
    public int currentReserved;

    [Header("Reloading")]
    public float fireRate;
    public float reloadTime;
    public bool reloading;
    public bool canShoot;

}

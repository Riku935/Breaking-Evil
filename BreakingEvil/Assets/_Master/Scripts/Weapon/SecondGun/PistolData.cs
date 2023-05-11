using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "M1911", menuName = "Pistol")]
public class PistolData : MonoBehaviour
{
    [Header("Gun Info")]
    public string gunName;

    public float damage;
    public float shotPower;

    [Header("Ammo")]
    public int currentAmmo;
    public int maxAmmo;

}

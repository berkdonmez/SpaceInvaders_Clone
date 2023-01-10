using UnityEngine;

[System.Serializable]
public class ShipStats
{
    [Range(1, 5)]
    public int MaxHealth;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int maxLifes = 3;
    [HideInInspector]
    public int currentLifes = 3;

    public float ShipSpeed;
    public float fireRate;

}

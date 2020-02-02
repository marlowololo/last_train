using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{

    [SerializeField] private List<WagonPart> wagonParts;
    [SerializeField] private GameObject wagonHealthBar;
    [SerializeField] private float minBarSize;
    [SerializeField] private float maxBarSize;

    public float WagonHealth;
    private int MaxCapacity;
    private int CurrentPassenger;

    private int brokenParts;

    private const float WAGON_DEFAULT_DAMAGE = 7.5f;
    private const int MAX_HEALTH = 100;

    public void Update()
    {
        brokenParts = 0;
        foreach(WagonPart part in wagonParts)
        {
            if(part.PartHealth <= 0)
            {
                brokenParts++;
            }
        }

        if(brokenParts > 0)
        {
            WagonHealth -= brokenParts * WAGON_DEFAULT_DAMAGE * Time.deltaTime;
        }

        wagonHealthBar.transform.localScale = new Vector3(
            Mathf.Lerp(minBarSize, maxBarSize, WagonHealth / MAX_HEALTH),
            wagonHealthBar.transform.localScale.y,
            wagonHealthBar.transform.localScale.z
        );
    }

    public void InitWagonData(float wagonHealth, int maxCapacity, int currentPassenger)
    {
        WagonHealth = wagonHealth;
        MaxCapacity = maxCapacity;
        CurrentPassenger = currentPassenger;
    }

    public void DamageWagon(float damageAmmount)
    {
        WagonHealth -= damageAmmount;
    }

    public void RepairWagon(float repairAmmount)
    {
        WagonHealth += repairAmmount;
    }

    public void UpdatePassangerCount(int count)
    {
        CurrentPassenger = count;
    }

    public List<WagonPart> GetWagonParts()
    {
        return wagonParts;
    }

    public void RepairAllPart()
    {
        foreach(var part in wagonParts)
        {
            part.RepairPart();
        }
        WagonHealth = MAX_HEALTH;
    }
}

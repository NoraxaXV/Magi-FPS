using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.GameFoundation;

public class Health : MonoBehaviour
{

    [SerializeField] string statTypeName = "creature";
    GameItem stats;
    
    // Start is called before the first frame update
    void Start()
    {
        stats = new GameItem(CatalogManager.gameItemCatalog.GetGameItemDefinition(statTypeName));
        Debug.Log("init stats for '"+statTypeName+"' with id " + stats.id);
    }

    public void RefreshUI(InventoryItem item = null)
    {
        Debug.Log("health is now: "+stats.GetStatFloat("health"));
    }

    public void TakeDamage(float damage)
    {
        float health = stats.GetStatFloat("health");
        health -= damage;
        stats.SetStatFloat("health", health);
        RefreshUI();
    }

}

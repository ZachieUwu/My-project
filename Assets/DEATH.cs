using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEATH : MonoBehaviour
{
    public List<Drop> itemDrops = new List<Drop>();
    
    public void DropLoot()
    {
        float chance = Random.Range(0f, 100f);
        for (int i = 0; i < itemDrops.Count; i++)
        {
            if (chance <= itemDrops[i].DropChance)
            {
                int amountToDrop = Random.Range(itemDrops[i].min, itemDrops[i].max);

                for (int j = 0; j < amountToDrop; j++)
                {
                    GameObject itemSpawn = Instantiate(itemDrops[i].ItemPrefab, transform.position, Quaternion.identity);
                    Rigidbody rb = itemSpawn.AddComponent<Rigidbody>();
                    rb.AddForce(transform.up * 5);
                    itemSpawn.AddComponent<CapsuleCollider>();
                    Destroy(itemSpawn, itemDrops[i].Duration);
                }
                Debug.Log($"{amountToDrop} {itemDrops[i].ItemName}(s) dropped");
            }
            
        }
    }

    private void OnDestroy()
    {
        DropLoot();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}

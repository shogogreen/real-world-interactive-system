using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CollectionManager collectionManager = FindObjectOfType<CollectionManager>();
        collectionManager.RemoveFromCollection("Bear");
        collectionManager.RemoveFromCollection("Rabbit");
        collectionManager.RemoveFromCollection("Pumpkin");
        collectionManager.RemoveFromCollection("Egg");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

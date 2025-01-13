using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class CollectionManager : MonoBehaviour
{
    public static CollectionManager Instance { get; private set; }  // シングルトンインスタンス
    private string saveFilePath;
    public CollectionData collectionData;

    void Awake()
    {
        // シングルトンパターンを適用し、インスタンスを1つだけにする
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // このオブジェクトをシーン遷移後も破棄しない
            saveFilePath = Application.persistentDataPath + "/collectionData.json";
            LoadCollectionData();  // 起動時にデータをロード
            PrintCollectionList();
        }
        else
        {
            Destroy(gameObject);  // すでにインスタンスが存在する場合は削除
        }
    }

    public void AddToCollection(string itemName, string description)
    {
        CollectionItem existingItem = collectionData.items.Find(item => item.itemName == itemName);
        if (existingItem == null)
        {
            CollectionItem newItem = new CollectionItem
            {
                itemName = itemName,
                description = description,
                isCollected = true
            };
            collectionData.items.Add(newItem);
            SaveCollectionData();
        }
    }

    public void RemoveFromCollection(string itemName)
    {
        CollectionItem itemToRemove = collectionData.items.Find(item => item.itemName == itemName);
        if (itemToRemove != null)
        {
            collectionData.items.Remove(itemToRemove);
            SaveCollectionData();
        }
    }

    public void SaveCollectionData()
    {
        string json = JsonUtility.ToJson(collectionData, true);
        File.WriteAllText(saveFilePath, json);
    }

    public void LoadCollectionData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            collectionData = JsonUtility.FromJson<CollectionData>(json);
        }
        else
        {
            collectionData = new CollectionData();
        }
    }

    public void PrintCollectionList()
    {
        if (collectionData.items.Count == 0)
        {
            Debug.Log("コレクションはまだ空です。");
        }
        else
        {
            Debug.Log("コレクションリスト:");
            foreach (CollectionItem item in collectionData.items)
            {
                Debug.Log($"アイテム名: {item.itemName} - 説明: {item.description}");
            }
        }
    }

    public List<CollectionItem> GetCollectionList()
    {
        if (collectionData.items.Count == 0)
        {
            Debug.Log("コレクションはまだ空です。");
        }
        return collectionData.items;  // コレクションリストを返す
    }
}

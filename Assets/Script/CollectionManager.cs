using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class CollectionManager : MonoBehaviour
{
    public static CollectionManager Instance { get; private set; }  // �V���O���g���C���X�^���X
    private string saveFilePath;
    public CollectionData collectionData;

    void Awake()
    {
        // �V���O���g���p�^�[����K�p���A�C���X�^���X��1�����ɂ���
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // ���̃I�u�W�F�N�g���V�[���J�ڌ���j�����Ȃ�
            saveFilePath = Application.persistentDataPath + "/collectionData.json";
            LoadCollectionData();  // �N�����Ƀf�[�^�����[�h
            PrintCollectionList();
        }
        else
        {
            Destroy(gameObject);  // ���łɃC���X�^���X�����݂���ꍇ�͍폜
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
            Debug.Log("�R���N�V�����͂܂���ł��B");
        }
        else
        {
            Debug.Log("�R���N�V�������X�g:");
            foreach (CollectionItem item in collectionData.items)
            {
                Debug.Log($"�A�C�e����: {item.itemName} - ����: {item.description}");
            }
        }
    }

    public List<CollectionItem> GetCollectionList()
    {
        if (collectionData.items.Count == 0)
        {
            Debug.Log("�R���N�V�����͂܂���ł��B");
        }
        return collectionData.items;  // �R���N�V�������X�g��Ԃ�
    }
}

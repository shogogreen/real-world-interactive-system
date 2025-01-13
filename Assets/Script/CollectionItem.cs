using System;
using System.Collections.Generic;

[Serializable]
public class CollectionItem
{
    public string itemName;  // �R���N�V�����A�C�e���̖��O
    public string description;  // �A�C�e���̐����i�C�Ӂj
    public bool isCollected;  // �o�^���ꂽ���ǂ���
}

[Serializable]
public class CollectionData
{
    public List<CollectionItem> items = new List<CollectionItem>();  // �R���N�V�����A�C�e���̃��X�g
}

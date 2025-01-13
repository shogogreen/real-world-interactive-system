using System;
using System.Collections.Generic;

[Serializable]
public class CollectionItem
{
    public string itemName;  // コレクションアイテムの名前
    public string description;  // アイテムの説明（任意）
    public bool isCollected;  // 登録されたかどうか
}

[Serializable]
public class CollectionData
{
    public List<CollectionItem> items = new List<CollectionItem>();  // コレクションアイテムのリスト
}

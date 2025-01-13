using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionView : MonoBehaviour
{
    public List<Image> imageSlots;  // キャンバス内のイメージオブジェクトのリスト

    // Start is called before the first frame update
    void Start()
    {
        CollectionManager collectionManager = FindObjectOfType<CollectionManager>();
        UpdateCollectionImages();
    }

    /// <summary>
    /// コレクションリストの長さに応じて画像を表示する
    /// </summary>
    public void UpdateCollectionImages()
    {
        List<CollectionItem> collectionList = CollectionManager.Instance.GetCollectionList();  // コレクションリストを取得

        // すべてのイメージを非アクティブにする
        foreach (Image img in imageSlots)
        {
            img.gameObject.SetActive(false);
        }

        // コレクションの長さ分だけイメージを表示
        for (int i = 0; i < collectionList.Count && i < imageSlots.Count; i++)
        {
            imageSlots[i].gameObject.SetActive(true);
            //imageSlots[i].sprite = GetItemSprite(collectionList[i].itemName);  // アイテム名に応じたスプライトを設定 (任意)
        }
    }
}

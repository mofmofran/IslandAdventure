using UnityEngine;

public class Door : MonoBehaviour
{
    [HideInInspector] private string _id;
    private UIController _uIController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _uIController = GameObject.FindFirstObjectByType<UIController>();//UIコントローラーを取得
        _id = SaveDataManager.MakeId(gameObject);
        if (SaveDataManager.IsUsed(_id))
        {
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (ItemKeeper.hasKeys > 0)
            {
                Destroy(this.gameObject);
                ItemKeeper.hasKeys -= 1;
                _uIController.UpdateItemCount(ItemType.key, ItemKeeper.hasKeys);
                SaveDataManager.SetUsed(_id);//開錠済みかセーブに刻む
                SoundManager.soundManager.SEPlay(SEType.DoorOpen);

            }
            else
            {
                SoundManager.soundManager.SEPlay(SEType.DoorClosed);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

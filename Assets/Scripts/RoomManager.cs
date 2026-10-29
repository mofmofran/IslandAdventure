using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    //シーンを跨ぐとき何番だったのかを記録している変数
    public static int currentDoorNumber=0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //シーン名取得
        string sceneName = SceneManager.GetActiveScene().name;
        //取得した名前に応じてBGM切替
        if (sceneName == "BossStage")
        {
            SoundManager.soundManager.PlayBgm(BGMType.InBoss);
        }
        else
        {
            SoundManager.soundManager.PlayBgm(BGMType.InGame);
        }
        if (SaveDataManager.isStartFromSavePoint)
        {
            SaveDataManager.isStartFromSavePoint = false;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = SaveDataManager.GetSavePointPosition();
            }
        }
        else
        {


            GameObject[] exits = GameObject.FindGameObjectsWithTag("Exit");
            foreach (GameObject extObj in exits)
            {
                if (currentDoorNumber == extObj.GetComponent<Exit>().doorNumber)
                {
                    float x = extObj.GetComponent<Transform>().position.x;
                    float y = extObj.GetComponent<Transform>().position.y;
                    //プレイヤーがいる座標を決める
                    switch (extObj.GetComponent<Exit>().direction)//breakを入れないと下の処理を行っていく
                    {
                        case Direction.up: y += 1; break;
                        case Direction.down: y -= 1; break;
                        case Direction.right: x += 1; break;
                        case Direction.left: x -= 1; break;
                            //defaultがelseの代わりになる
                    }
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    if (player != null)
                    {
                        player.transform.position = new Vector2(x, y);
                    }
                    break;//foreachを抜ける
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

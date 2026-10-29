using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [Header("移動先シーン")]
    [SerializeField] private string _sceneName;
    [Header("出入口と方向")]
    public int doorNumber;
    public Direction direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            //staticに自分の識別番号を授ける
            RoomManager.currentDoorNumber = doorNumber;
            Invoke("Load", 0.2f);
        }
    }

    private void Load()
    {
        SceneManager.LoadScene(_sceneName);
    }

}

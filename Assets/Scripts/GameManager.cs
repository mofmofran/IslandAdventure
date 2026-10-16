using UnityEngine;

public enum GameState
{
    InGame,//ゲーム中
    GameClear,//ゲームクリア
    GameOver,//ゲームオーバー
    GameEnd,//ゲーム終了
}
public class GameManager : MonoBehaviour
{
    public static GameState gameState = GameState.InGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //初期状態はゲーム中からはじまる
        gameState = GameState.InGame;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

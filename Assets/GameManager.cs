using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    enum State {
        Main,
        GameOver,
    }

    int _score = 0;
    State _state = State.Main;

    public void StartGameOver() {
        _state = State.GameOver;
    }
    
    void Start() {
        
    }

    void Update() {
        
    }

    private void FixedUpdate() {
        if(_state == State.Main) {
            _score++;
        }
    }

    private void OnGUI() {
        _DrawScore();

        float CenterX = Screen.width / 2;
        float CenterY = Screen.height / 2;
        if (_state == State.GameOver) {
            _DrawGameOver(CenterX, CenterY);

            if (_DrawRetryButton(CenterX, CenterY)) {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    bool _DrawRetryButton(float CenterX, float CenterY) {
        float ofsY = 40;
        float width = 100;
        float height = 64;
        Rect position = new Rect(CenterX - width / 2, CenterY + ofsY, width, height);

        if (GUI.Button(position, "Retry")) {
            return true;
        } else {
            return false;
        }
    }

    void _DrawGameOver(float CenterX, float CenterY) {
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        float width = 400;
        float height = 100;
        Rect position = new Rect(CenterX - width / 2, CenterY - height / 2, width, height);
        GUI.Label(position, "GAME OVER");
    }

    void _DrawScore() {
        GUI.skin.label.fontSize = 32;
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        Rect position = new Rect(10, 10, 400, 100);
        GUI.Label(position, "Score: " + _score);
    }

}

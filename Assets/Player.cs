using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    const int SPR_FALL = 0; // 落下中
    const int SPR_JUMP = 1; // ジャンプ中

    [SerializeField]
    float JUMP_VELOCITY = 1000;
    public Sprite[] SPR_LIST;
    public GameObject gameManager;

    Rigidbody2D _rigidbody;
    SpriteRenderer _renderer;
    GameManager _gameManager;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _gameManager = gameManager.GetComponent<GameManager>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY));
        }

        if (_rigidbody.velocity.y < 0) {
            _renderer.sprite = SPR_LIST[SPR_FALL];
        } else {
            _renderer.sprite = SPR_LIST[SPR_JUMP];
        }
    }

    private void FixedUpdate() {
        // 座標取得
        Vector3 position = transform.position;

        float y = position.y;
        float vx = _rigidbody.velocity.x;

        if (y > GetTop()) {
            _rigidbody.velocity = Vector2.zero;
            position.y = GetTop();
        }

        if (y < GetBottom()) {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(new Vector2(0, JUMP_VELOCITY));
            position.y = GetBottom();
        }

        transform.position = position;
    }

    float GetTop() {
        Vector2 max = Camera.main.ViewportToWorldPoint(Vector2.one);
        return max.y;
    }

    float GetBottom() {
        Vector2 min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        return min.y;
    }

    // 当たり判定
    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
        _gameManager.StartGameOver();
    }
}

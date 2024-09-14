using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    public GameObject blockPrefab;
    float _timer = 0;
    float _totalTime = 0;
    int _count = 0;

    void Start() {
    }

    void Update() {
        _timer -= Time.deltaTime;
        _totalTime += Time.deltaTime;

        if (_timer < 0 ) {
            Vector3 position = transform.position;
            // プレハブからインスタンスを生成
            position.y = Random.Range(-4.0f, 4.0f);
            GameObject obj = Instantiate(blockPrefab, position, Quaternion.identity);

            // 時間経過でスピードアップ
            Block blockScript = obj.GetComponent<Block>();
            float speed = 100 + _totalTime * 10;
            blockScript.SetSpeed(-speed);

            _count++;
            if (_count % 10 < 3) {
                _timer += 0.1f;
            } else {
                _timer += 1;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cubeの操作を行うクラス
/// Cubeにアタッチするように設計されている
/// </summary>
public class CubeController : MonoBehaviour
{
    private Test test;                   // このコンポーネントの持つクラス取得用
    [SerializeField,Header("回転角度の設定値")]
    public float eulerAngle;
    private int axis;                    // 回転させる軸の設定値
    public RotationInfo rotationInfo;    // 外部のコンポーネントの持つクラス取得用

    void Start()
    {
        // Testクラスを取得しtest変数に代入 = アクセスできる状態にする
        // 取得するTestクラスが同じオブジェクトにアタッチされている場合
        // 省略しない書き方
        test = this.gameObject.GetComponent<Test>();
        // 省略した書き方（基本形）
        //test = GetComponent<Test>();
    }

    void Update()
    {
        // ボタンを押す度に回転軸を x => y => z => x と変更する
        if (Input.GetKeyDown(KeyCode.Z)) {
            axis++;
            // zになったらxに戻す
            if(axis >= 3) {
                axis = 0;
            }
            Debug.Log(axis);
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            // cubeを回転させるため、TestクラスのRotateCubeメソッドを呼び出す
            // 第１引数として回転する角度、第２引数として回転をさせる軸の情報を渡す
            // アクセスする場合には、[クラスの代入されている変数名].[呼び出すメソッド名]で書く 
            test.RotateCube(eulerAngle, axis);
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            // 自クラスのRotateメソッドを呼び出す
            Rotate();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            // cubeの状態をリセットするため、TestクラスのResetRotateを呼び出す
            test.ResetRotate();
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            // 各回転軸の回転させた回数をリセットするため、TestクラスのResetAxisCountを呼び出す
            test.ResetAxisCount(0);
        }
    }

    /// <summary>
    /// Cubeを回転させるため、TestクラスのRotateCubeメソッドを呼び出す処理
    /// 外部のRotationButtonクラスからも呼ばれるのでpiblic修飾子がついている
    /// </summary>
    public void Rotate() {      
        // 第１引数として回転する角度、第２引数として回転をさせる軸、第３引数として逆回転の情報を渡す
        test.RotateCube(eulerAngle, axis, true);
        // RotationInfoクラスのDisplayTextメソッドを呼びだし、文字列を表示（更新）する
        rotationInfo.DisplayText();
    }
}

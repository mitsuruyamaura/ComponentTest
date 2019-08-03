using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトのアクティブ状態を外部から操作するクラス
/// Cube以外のオブジェクトにアタッチされるように設計されている
/// </summary>
public class ActivateSwitch : MonoBehaviour
{
    [SerializeField,Header("操作したいオブジェクト")]
    public GameObject cube;

    private Test test;   // testクラスの取得用

    void Start()
    {
        // このActivateSwitchクラスがアタッチされているオブジェクト以外のコンポーネントを取得する場合
        // まずは外部のオブジェクトの情報を取得し、その後、コンポーネントを取得する
        // 探す場合には文字列("")で検索するため、文字が１つでも違うと探せない(大文字・小文字区別する)
        GameObject obj = GameObject.Find("Cube");      // オブジェクトを探し、objに代入する
        test = obj.gameObject.GetComponent<Test>();    // objが持っているTestクラス・コンポーネントを取得

        // 1行で書く場合
        //test = GameObject.Find("Cube").GetComponent<Test>();
        Debug.Log(obj);
        Debug.Log(test);
        int x = new int();
        x = 5;
        Debug.Log(x);
    }

    void Update()
    {
        // ボタンを押すたびにオブジェクトの状態をアクティブ／非アクティブに切り替える
        if (Input.GetKeyDown(KeyCode.B)) {
            // activeSelfとはbool型で、指定した変数のオブジェクトが現在アクティブか非アクティブかを返してくれる
            if (!test.gameObject.activeSelf) {
                // 非アクティブならアクティブにする
                test.gameObject.SetActive(true);
            } else {
                // アクティブなら非アクティブにする
                test.gameObject.SetActive(false);
            }
            // 1行で書ける(test(Testクラス)を使う場合) = GameObject型ではないため、gameObjectの指示が必要
            //test.gameObject.SetActive(!test.gameObject.activeSelf);
            // cube(GameObject型)を使う場合 = GameObject型であるため、gameObjectの指示が不要
            //cube.SetActive(!cube.activeSelf);
        }
    }
}

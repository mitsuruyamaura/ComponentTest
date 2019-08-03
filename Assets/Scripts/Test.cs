using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// テスト用クラス
/// クラスとコンポーネントの取得、オン／オフ、利用方法について
/// </summary>
public class Test : MonoBehaviour
{    
    [SerializeField,Header("コライダー（接触判定）のオンオフ用")]
    public BoxCollider boxCollider;
    [SerializeField, Header("レンダラー（描画）のオンオフ用")]
    public MeshRenderer meshRenderer;
    [SerializeField, Header("マテリアル（色）の設定用")]
    public Material material;

    [SerializeField,Range(0,2),Header("変更する色の設定値")]
    public int colorNumber;
    [SerializeField, Header("Planeかどうかの判定用 trueならPlane")]
    public bool isPlaneFlag;

    private bool isRigidGet;    // 指定した条件(ここではRigidBodyコンポーネントを持っている)かどうかを判定するフラグ

    [SerializeField,Header("回転させる軸と回転させる回数")]
    public int x;
    public int y;
    public int z;

    void Start()
    {
        // このクラスがアタッチされているオブジェクトがPlaneかどうか判定し、分岐させる
        if (isPlaneFlag) {  // isPlaneFlag == true
            // Planeならこちらのメソッドを実行
            // 引数としてcolorNumberというint型の数値を渡している
            ChangeMatColor(colorNumber);
        } else {
            // Planeではない(Cube)なら、こちらのメソッドを実行
            // 引数としてColor.blueという、Color型の色情報を渡している
            SetMatColor(Color.blue);
        }
    }

    /// <summary>
    /// 常に動いているメソッド。ここではキーボード入力を監視し、常に入力を受け付ける状態にする
    /// if文であるのは、対応するキー入力があった場合のみ処理を実行するため
    /// 条件がないと常に動いてしまう
    /// </summary>
    void Update()
    {
        // ボタンを押す度にBoxColliderコンポーネントの状態をオン・オフ切り替える
        // オンならそのコンポーネントは有効　オフなら無効
        // 操作したいコンポーネントが代入されている変数を使う =　アクセスできる
        if (Input.GetKeyDown(KeyCode.A)) {
            // [変数名.enabled]で現在のコンポーネントの状態を確認できる。trueならオンの状態
            if (boxCollider.enabled == true) {
                // オフに切り替える
                boxCollider.enabled = false;
            } else {
                // ifの条件でないなら、こちらの処理を実行 = falseの場合
                boxCollider.enabled = true;
            }
            // 1行で書く場合
            //boxCollider.enabled = !boxCollider.enabled;
        }

        // ボタンを押す度にBoxColliderコンポーネントの持つIsTriggerプロパティのオン・オフを切り替える
        if (Input.GetKeyDown(KeyCode.S)) {
            if (!boxCollider.isTrigger) {   // boxCollider.isTrigger == falseと同じ
                // オフならオンにする
                boxCollider.isTrigger = true;
            } else {
                // オンならオフにする
                // if-else文なので、必ずどちらかの分岐に入る
                boxCollider.isTrigger = false;
            }
        }

        // ボタンを押す度にMeshRendererコンポーネントのオン・オフを切り替える
        if (Input.GetKeyDown(KeyCode.D)) {
            meshRenderer.enabled = !meshRenderer.enabled;
        }

        // ボタンを押す度にMaterialの色を変更する
        if (Input.GetKeyDown(KeyCode.F)) {
            // このクラスの持つメソッドを呼び出し実行する
            // 引数としてcolorNumberというint型の数値を渡す
            ChangeMatColor(colorNumber);
        }

        // ボタンを押したとき
        if (Input.GetKeyDown(KeyCode.G)) {
            // isPlaneFlagがfalseであり、かつisRigidGetがfalseである場合
            if (!isPlaneFlag && !isRigidGet) {  // isPlaneFlag == false && isRigidGet == false
                // このゲームオブジェクトに新しくRigidBodyコンポーネントを追加する
                gameObject.AddComponent<Rigidbody>();
                // RigidBodyを持っているかどうかのフラグをオンにし、持っている状態にする
                isRigidGet = true;
            }
            if (isRigidGet) {  // isRigidGet == true
                // すでにRigidBodyを追加している状態である場合
                // RigidBody型の変数rbを宣言し、RigidBodyを取得してアクセスできるようにする
                Rigidbody rb = GetComponent<Rigidbody>();

                // RigidBodyコンポーネントの持つIsKinematicプロパティの状態を見て、オン・オフを切り替える
                if (!rb.isKinematic) {
                    rb.isKinematic = true;
                } else {
                    rb.isKinematic = false;
                }
            }
        }

        // ボタンを押したとき
        if (Input.GetKeyDown(KeyCode.H)) {
            // isRigidGetがtrueなら = RigidBodyコンポーネントを持っているなら
            if (isRigidGet) {
                // RigidBodyコンポーネントを削除する
                Destroy(GetComponent<Rigidbody>());
                // 所有フラグをfalseにし、RigidBodyコンポーネント持っていない状態にする
                isRigidGet = false;
                // 落下しているCubeの位置を初期位置に戻す
                float pos = 3.0f;
                transform.position = new Vector3(transform.position.x,pos,transform.position.z);
            }
        }
    }

    /// <summary>
    /// マテリアルの色の初期設定処理
    /// </summary>
    /// <param name="argumentColor"></param>
    private void SetMatColor(Color argumentColor) {
        // 引数として渡されたargumentColorを使い色を変更（初期設定）する
        // 設定にはMaterial型の変数materialの持つcolorにアクセスする
        material.color = argumentColor;
        colorNumber = 1;
    }

    /// <summary>
    /// マテリアルの色を変える処理
    /// public修飾子なので、他のクラスからでもこのメソッドを実行できる
    /// </summary>
    /// <param name="argumentColorNumber"></param>
    public void ChangeMatColor(int argumentColorNumber) {
        // 引数として渡されたargumentColorNumberに入ってる番号を使い、分岐により色を設定する
        // ここでもmaterial.colorにアクセスすることで色を変更する
        // switch文はいずれかのcaseに入ると終了する( = breakで抜けている)
        switch (argumentColorNumber) {
            case 0:
                material.color = Color.blue;
                break;
            case 1:
                material.color = Color.green;
                break;
            case 2:
                material.color = Color.red;
                break;
        }
        // 色の番号を1ずつ加算する = 次回以降、別の分岐に入るようにする
        colorNumber++;
        // 色の設定値は2までなので、3以上の数値になったら0に戻す処理を入れておく
        if(colorNumber >= 3) {
            colorNumber = 0;
        }
        Debug.Log(colorNumber);
    }

    /// <summary>
    /// Cubeを回転させる処理
    /// </summary>
    /// <param name="argumentEulerAngle"></param> 回転させる角度
    /// <param name="argumentAxis"></param> 回転させる軸　
    /// <param name="isReverseFlag"></param> 正回転か逆回転かどうかのフラグ 基本はfalseで正回転
    public void RotateCube(float argumentEulerAngle, int argumentAxis, bool isReverseFlag = false) {
        // 回転させたい軸の情報をrotationPosに代入
        Quaternion rotationPos = transform.rotation;
        Debug.Log(transform.rotation);

        // 逆回転させるフラグがON(true)なら、回転させる向きを逆にする
        if (isReverseFlag) {
            argumentEulerAngle = -argumentEulerAngle;
            Debug.Log("Reverse");
        }
        // 回転させる軸を決める分岐 いずれかのcaseに入る
        // 軸ごとに回転した回数がカウントされる
        switch (argumentAxis) {
            case 0:  // x軸
                x++;
                rotationPos.x = argumentEulerAngle * x;
                break;
            case 1:  // y軸
                y++;
                rotationPos.y = argumentEulerAngle * y;
                break;
            case 2:  // z軸
                z++;
                rotationPos.z = argumentEulerAngle * z;
                break;
        }
        // 上記の分岐で決定した角度で回転させる
        // 分岐以外の２つの軸は元々の数値がそのまま再度入る
        transform.rotation = Quaternion.Euler(rotationPos.x, rotationPos.y, rotationPos.z);
        Debug.Log(transform.rotation);
    }

    /// <summary>
    /// Cubeの回転を初期状態に戻す処理
    /// </summary>
    public void ResetRotate() {
        // identityはゲーム開始時（生成時）の回転軸の情報の状態
        transform.rotation = Quaternion.identity;
        //transform.rotation = Quaternion.Euler(0,0,0);        
    }

    /// <summary>
    /// Cubeの各回転軸の回転回数を0に戻す処理
    /// </summary>
    /// <param name="argumentCount"></param>
    public void ResetAxisCount(int argumentCount) {
        x = argumentCount;
        y = argumentCount;
        z = argumentCount;
    }
}

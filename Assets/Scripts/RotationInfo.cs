using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationInfo : MonoBehaviour
{
    public Text infoTxt;
    //private Text infoTxt;       // Textプロパティに表示させるTextコンポーネントを持つGameObject[Info]を外部で指定する
    public Transform transCube;   // Textプロパティに表示させるTransformコンポーネントを持つGameObject[Cube]を外部で指定する。
    private Vector3 rotatePos;

    private void Start() {
        //infoTxt = GetComponent<Text>();
        // TransformコンポーネントであるtransCubeの持つRotationプロパティを、オイラー角に変換して代入
        rotatePos = transCube.transform.localEulerAngles;
        Quaternion quaternionPos = transCube.transform.rotation;
        Debug.Log(rotatePos);
        Debug.Log(quaternionPos);
    }

    /// <summary>
    /// TextコンポーネントのTextプロパティに文字を表示させる処理
    /// 外部から呼び出して処理を行うのでpublic修飾子にしている
    /// </summary>
    public void DisplayText()
    {
        // rotatePosに現在のCubeのRotationを反映する。
        rotatePos = transCube.transform.localEulerAngles;

        // infoTxtよりtextプロパティにアクセスして、テキストに内容を表示する
        // 表示内容は、rotatePos = transCubeの持つrotationプロパティの情報        
        infoTxt.text = "X : " + rotatePos.x + ", Y ;" + rotatePos.y + ", X :" + rotatePos.z;
    }
}

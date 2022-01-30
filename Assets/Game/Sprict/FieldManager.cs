using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class FieldManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("エリア座標")]

    /// <summary>
    /// 中央の座標(0,0,0)はエリア[9]
    /// </summary>
    [SerializeField] Vector3[]  _area;
 
    [Header("フィールドPrefab")]
    /// <summary>
    /// Field[0]Forest＿木材＿４
    /// Field[1]HIlls＿レンガ＿3
    /// Field[2]Mountain＿鉄＿３
    /// Field[3]Sheep＿羊＿４
    /// Field[4]Wheat_小麦＿４
    /// </summary>
    [SerializeField] GameObject[] _field;

    [SerializeField] GameObject _desert;//砂漠＿資源なし＿１

    //クローンされた砂漠
    GameObject _cloneDesert;
    /// <summary>
    /// クローンされたフィールドを入れる
    /// </summary>
    GameObject[] _cloneFields = new GameObject[19];


    [Header("ナンバー座標")]

    [SerializeField] Vector3[] _numArea;

    [Header("ナンバーPrefab")]

    [SerializeField] GameObject[] _number;
    /// <summary>
    /// クローンされたナンバーを入れる
    /// </summary>
    GameObject[] _cloneNum = new GameObject[19];

    Quaternion _rotate = Quaternion.Euler(90, 90, 0);
    void Start()
    {
        AreaDeployStandard();
        RandomNum();
    }



    public void AreaDeployStandard()
    {

        Vector3[] _areaRandam = _area.OrderBy(i => System.Guid.NewGuid()).ToArray();

        //desert
        _cloneDesert =　Instantiate(_desert, _areaRandam[0], Quaternion.identity) as GameObject;
        //Forest
        for (int i = 1; i <= 4; i++)
        {
            _cloneFields[i] =  Instantiate(_field[0], _areaRandam[i], Quaternion.identity) as GameObject;
        }
        //Hills
        for (int i = 5; i <= 7; i++)
        {
            _cloneFields[i] = Instantiate(_field[1], _areaRandam[i], Quaternion.identity) as GameObject;
        }
        ////Mountain
        for (int i = 8; i <= 10; i++)
        {
            _cloneFields[i] = Instantiate(_field[2], _areaRandam[i], Quaternion.identity) as GameObject;
        }
        ////Sheep
        for (int i = 11; i <= 14; i++)
        {
            _cloneFields[i] = Instantiate(_field[3], _areaRandam[i], Quaternion.identity) as GameObject;
        }
        ////Wheat
        for (int i = 15; i <= 18; i++)
        {
            _cloneFields[i] = Instantiate(_field[4], _areaRandam[i], Quaternion.identity) as GameObject;
        }

    }

    public void Destroy()
    {

        Destroy(_cloneDesert);

        foreach (GameObject clone in _cloneFields)
        {
            Debug.Log("削除");
            Destroy(clone);
        }

    }

    public void RandomNum()
    {
        Vector3[] _numRandam = _numArea.OrderBy(i => System.Guid.NewGuid()).ToArray();

        for (int i = 1; i <= 4; i++)
        {
            _cloneNum[i] = Instantiate(_number[0], _numRandam[i], _rotate) as GameObject;
        }
    }
}

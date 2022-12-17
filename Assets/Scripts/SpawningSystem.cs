using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
  [SerializeField] private GameObject house1, house2, house3, house4;
  [SerializeField] private int house1MaxNumber, house2MaxNumber, house3MaxNumber;
  [SerializeField] private int screenStartX, roadStartX, roadEndX, screenCornerX;
  [SerializeField] private int houseSpawnY;
  [SerializeField] private float spawningSpeed, speedUpFactor;
  private  List<GameObject> _list = new List<GameObject>();
  private IEnumerator coroutine;

  public void StartSpawning()
  {
   coroutine = WaveTimer();
  StartCoroutine(coroutine);
 }
 

 private IEnumerator WaveTimer()
 {
  Instantiate(GetHouseType(), new Vector2(GetXPosition(), houseSpawnY), new Quaternion(0, 0, 0, 0));
  yield return new WaitForSeconds(spawningSpeed);
  spawningSpeed -= speedUpFactor;
  StartCoroutine("WaveTimer");
 }

 private GameObject GetHouseType()
 {
  if (_list.Count < house1MaxNumber)
  {
   _list.Add(house1);
  } else if (_list.Count < house2MaxNumber && _list.Count >= house1MaxNumber)
  {
   _list.Add(house2);
  }else if (_list.Count < house3MaxNumber && _list.Count >= house2MaxNumber)
  {
   _list.Add(house3);
  }else if (_list.Count >= house3MaxNumber)
  {
   _list.Add(house4);
  }
  return _list[Random.Range(0, _list.Count)];
 }

 private int GetXPosition()
 {
  if (Random.Range(0, 2) == 0)
  {
   return Random.Range(screenStartX, roadStartX);
  }
  return Random.Range(roadEndX, screenCornerX);
 }
}

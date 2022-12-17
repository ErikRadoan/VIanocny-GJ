using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
  [SerializeField] private TimeManager timeManager;
  [SerializeField] private GameObject house1, house2, house3, house4;
  [SerializeField] private int house1MaxNumber, house2MaxNumber, house3MaxNumber;
  [SerializeField] private float startingSpeed;
  [SerializeField] private float screenStartX, roadStartX, roadEndX, screenCornerX;
  [SerializeField] private float houseSpawnY;
  private  List<GameObject> _list = new();
  private IEnumerator _coroutine;

  public void Start()
  {
   _coroutine = WaveTimer();
   StartCoroutine(_coroutine);
  }
 

 private IEnumerator WaveTimer()
 {
  Instantiate(GetHouseType(), new Vector2(GetXPosition(), houseSpawnY), new Quaternion(0, 0, 0, 0));
  yield return new WaitForSeconds(startingSpeed);
  timeManager.SpeedUpTime();
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

 private bool _roadSide;
 private float GetXPosition()
 {
  if (_roadSide)
  {
   _roadSide = !_roadSide;
   return Random.Range(screenStartX, roadStartX);
  }
  _roadSide = !_roadSide;
  return Random.Range(roadEndX, screenCornerX);
 }
}

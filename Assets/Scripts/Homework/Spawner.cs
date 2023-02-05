using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Homework
{
    /**
     * TODO:
     * 1. Найти примеры полиморфизма в уже написанном коде и в том, что будет написан вами.
     *      Нашел перегрузку, переопределение, приведение типов
     * 2. Реализовать удаление объектов из коллекции _spawnedObjects. +
     * 3. Заменить тип коллекции на более подходящий к данному случаю. Объяснить, если замена не требуется.
     *      Заменил _objectsToSpawn на массив т.к. изначально известно сколько у нас объектов,
     *      Заменил _spawnedObjects на LinkedList т.к. проще добавлять и удалять элементы, а поиск производить не надо
     */
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private int _totalAmount;

        [SerializeField]
        private float _spawnDelay;

        [SerializeField]
        private GameObject[] _objectsToSpawn = new GameObject[2];

        private readonly LinkedList<GameObject> _spawnedObjects = new LinkedList<GameObject>();


        void Start()
        {
            StartCoroutine(SpawnNext());
        }

        private IEnumerator SpawnNext()
        {
            var random = new System.Random();
            int i;

            while (true)
            {
                yield return new WaitForSeconds(_spawnDelay);

                if (_spawnedObjects.Count < _totalAmount)
                {
                    i = random.Next(_objectsToSpawn.Length);
                    var spawnedObject = Instantiate(_objectsToSpawn[i], transform);
                    
                    _spawnedObjects.AddLast(spawnedObject);
                }
                else if (_spawnedObjects.Count == _totalAmount)
                {
                    i = random.Next(_objectsToSpawn.Length);
                    var spawnedObject = Instantiate(_objectsToSpawn[i], transform);
                    
                    Destroy(_spawnedObjects.First.Value);
                    _spawnedObjects.RemoveFirst();
                    _spawnedObjects.AddLast(spawnedObject);
                }
            }
        }
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IFactory
{
    GameObject FactoryMethod(int index, Transform spawnPoint);
}
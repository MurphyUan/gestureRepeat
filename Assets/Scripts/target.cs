using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    [SerializeField] private int score = 1;

    public int returnScore(){
        Destroy(gameObject);
        return score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

float lifeTime = 1.50f;

void Awake () { Destroy (gameObject, lifeTime); }

}

﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotNullDrawerTester : MonoBehaviour
{
	public int IntegerFieldNoAttribute;
	[NotNull]
	public int
		IntegerField;
	public GameObject ObjectReferenceNoAttribute;
	[NotNull]
	public GameObject
		RequiredObjectOne;
	[NotNull]
	public GameObject
		RequiredObjectTwo;
	public string PublicString;
	[NotNull]
	public GameObject
		RequiredObjectInScene;
	[NotNullAttribute]
	public List<int> 
		AttributeOnList;
	[NotNullAttribute]
	public GameObject[]
		AttributeOnArray = new GameObject[5];
}

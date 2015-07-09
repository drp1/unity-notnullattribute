﻿using UnityEngine;

[System.AttributeUsage (System.AttributeTargets.Field)]
public class NotNullAttribute : PropertyAttribute {

	public bool IgnorePrefab = false;
}
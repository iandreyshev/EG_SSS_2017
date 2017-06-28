﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
	public abstract class Ammo : Body
	{
		public int demage { set { touchDemage = value; } }

		public abstract void Start();
		public sealed override void OnDeleteByWorld()
		{
			world.EraseAmmo(this);
		}
	}
}

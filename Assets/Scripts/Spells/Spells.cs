﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
	public abstract class Spell : ShipProperty
	{
		public bool isPassive { get; protected set; }

		public void DoEffect()
		{
			if (isPassive || !isTimerReady)
			{
				return;
			}

			CreateEffect();
		}

		protected override sealed void OnInit()
		{
			if (isPassive)
			{
				isTimerWork = false;
				CreateEffect();
			}
		}

		protected abstract void CreateEffect();
		protected virtual void OnAwake() { }

		private void Awake()
		{
			isPassive = true;
			OnAwake();
		}
	}
}

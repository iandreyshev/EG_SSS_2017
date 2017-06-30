﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGame
{
	public abstract class Enemy : Body
	{
		public Bonus bonus { get; set; }
		public int points { get; set; }
		public byte starsCount { get; protected set; }

		protected List<Gun> guns { get; set; }

		protected sealed override void OnAwakeEnd()
		{
			guns = new List<Gun>();
			if (roadController) roadController.OnEndReached.AddListener((T) =>
			{
				ExitFromWorld();
			});
		}
		protected sealed override void OnInitEnd()
		{
			InitProperties();
			InitGuns();

			if (healthBar) healthBar.SetValue(healthPart);
		}
		protected sealed override void DoAfterDemaged()
		{
			if (!isLive)
			{
				world.EraseEnemyByKill(this);
			}

			if (healthBar) healthBar.SetValue(healthPart);
		}
		protected sealed override void NotSleepUpdate()
		{
			guns.ForEach(gun =>
			{
				if (gun == null) return;
				gun.isTimerWork = !world.gameplay.isMapSleep;
			});
		}
		protected abstract void InitProperties();
		protected abstract void InitGuns();

		internal sealed override void OnErase()
		{
			guns.ForEach(gun =>
			{
				if (gun == null) return;
				Destroy(gun);
			});
		}
		internal sealed override void OnExitFromWorld()
		{
			world.EraseEnemy(this);
		}
	}
}

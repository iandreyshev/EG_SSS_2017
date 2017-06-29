﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGame
{
	public sealed class MiddleEnemy : Enemy
	{
		public RocketLauncher m_rocketGun;

		protected override void NotSleepUpdate()
		{
			m_rocketGun.isTimerWork = !isSleep;
		}
		protected override void OnInitEnd()
		{
			health = maxHealth = 50;
			touchDemage = 100;
			starsCount = 7;
			speed = 2;
			m_rocketGun.isTimerWork = true;
			m_rocketGun.speed = 10;
			m_rocketGun.factor = 1;
			m_rocketGun.Init(0, world, world.ship);
			points = 1527;
		}
		protected override void DoBeforeDestroy()
		{
			m_rocketGun.isTimerWork = false;
		}

		private float speed { get; set; }
	}
}

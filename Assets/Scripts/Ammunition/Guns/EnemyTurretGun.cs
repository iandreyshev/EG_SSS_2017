﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MyGame
{
	public class EnemyTurretGun : Gun
	{
		public Transform m_bulletsSpawn;
		public SimpleBullet m_bullet;

		public float speed { get; set; }

		protected override void DoAfterInit()
		{
			coldown = 1.3f;
			demage = 15;
		}
		protected override void Shoot()
		{
			SimpleBullet bullet = Instantiate(m_bullet);
			Vector3 position = m_bulletsSpawn.position;
			position.y = MapPhysics.FLY_HEIGHT;
			bullet.position = position;
			bullet.Init(gameMap.shipPosition, speed, demage);
			bullet.Start();
			gameMap.AddAmmo(bullet);
		}
	}
}

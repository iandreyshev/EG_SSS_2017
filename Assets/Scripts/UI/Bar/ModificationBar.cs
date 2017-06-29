﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyGame
{
	public class ModificationBar : UIBar
	{
		public GameObject m_plank;
		public Color m_inactive;
		public Color m_active;

		protected override void OnAwakeEnd()
		{
			CreateNewPlanks();
		}
		protected override void OnSetNewValue()
		{
			throw new NotImplementedException();
		}

		private List<Image> m_planks = new List<Image>();

		private void CreateNewPlanks()
		{
			List<Component> oldPlanks = Utils.GetChilds<Component>(transform);
			m_planks.ForEach(element => Destroy(element));
			m_planks.Clear();

			Utils.DoAnyTimes(MapPhysics.MODIFICATION_COUNT, () =>
			{
				GameObject plank = Instantiate(m_plank, transform);
				Image image = plank.GetComponentInChildren<Image>();
				m_planks.Add(image);
				image.color = m_inactive;
			});
		}
	}
}
using UnityEngine;
using System.Collections;
using System;

public static class EquipStatus {


	public static InventoryItem MakeEquipStatu(InventoryItem it)
	{
		Inventory i = null;
		InventoryManager._instance.inventoryDic.TryGetValue(it._Item._Id,out i);
		float level_exp;
		if (0 < it._Exp && it._Exp < 300) 
		{
			level_exp = 0.0f;
		}
		else if(300 <= it._Exp && it._Exp <500)
		{
			level_exp = 0.1f;
		}
		else if(500<=it._Exp && it._Exp <700)
		{
			level_exp = 0.2f;
		}
		else if(700 <= it._Exp && it._Exp < 1000)
		{
			level_exp = 0.35f;
		}
		else if(1000 <= it._Exp && it._Exp<1600)
		{
			level_exp = 0.5f;
		}
		else if(1600<= it._Exp && it._Exp<2200)
		{
			level_exp = 0.7f;
		}
		else if(2200<= it._Exp && it._Exp < 3000)
		{
			level_exp = 0.9f;
		}
		else if(3000<= it._Exp && it._Exp < 4000)
		{
			level_exp = 1.2f;
		}
		else if(4000<=it._Exp && it._Exp< 6000)
		{
			level_exp = 1.6f;
		}
		else if(6000<=it._Exp )
		{
			level_exp = 2.0f;
		}
		else
		{
			level_exp = 0.0f;
		}
		it._Item._Attack = Convert.ToInt32(i._Attack *(1.0 + level_exp + it._Strengthen/10));
		it._Item._Defence = Convert.ToInt32(i._Defence *(1.0+level_exp + it._Strengthen/10));
		it._Item._Health = Convert.ToInt32(i._Health *(1.0+level_exp + it._Strengthen/10));
		it._Item._HealthCover = Convert.ToInt32(i._HealthCover *(1.0+level_exp + it._Strengthen/10));
		it._Item._Power = Convert.ToInt32(i._Attack * 1.0 + it._Item._Defence * 1.0 + it._Item._Health * 0.1 +  it._Item._Resistance * 30.0 + it._Item._HealthCover * 10.0);
		return it;
	}
}

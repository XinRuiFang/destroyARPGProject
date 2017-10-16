using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class MakePrototypes {

	public static void MakeEquipProto(InventoryItem it,Dictionary<int,Inventory> inventoryDic)
	{
		Inventory i = null;
		inventoryDic.TryGetValue(it._Item._Id,out i);
		float _ex = 1f;
		if (0 < it._Exp && it._Exp < 300) 
		{
			_ex += 0.0f;
		}
		else if(300 <= it._Exp && it._Exp <500)
		{
			_ex += 0.1f;
		}
		else if(500<=it._Exp && it._Exp <700)
		{
			_ex += 0.2f;
		}
		else if(700 <= it._Exp && it._Exp < 1000)
		{
			_ex += 0.35f;
		}
		else if(1000 <= it._Exp && it._Exp<1600)
		{
			_ex += 0.5f;
		}
		else if(1600<= it._Exp && it._Exp<2200)
		{
			_ex += 0.7f;
		}
		else if(2200<= it._Exp && it._Exp < 3000)
		{
			_ex += 0.9f;
		}
		else if(3000<= it._Exp && it._Exp < 4000)
		{
			_ex += 1.2f;
		}
		else if(4000<=it._Exp && it._Exp< 6000)
		{
			_ex += 1.6f;
		}
		else if(6000<=it._Exp )
		{
			_ex += 2.0f;
		}
		else
		{
			_ex += 0.0f;
		}
		_ex += it._Strengthen / 10f;
		it.Attack = Convert.ToInt32(i._Attack * _ex);
		it.Defence = Convert.ToInt32(i._Defence * _ex);
		it.Energy = i._Energy * _ex;
		it.EnergyCover = Convert.ToInt32(i._EnergyCover * _ex);
		it.Health = Convert.ToInt32(i._Health * _ex);
		it.HealthCover =i._HealthCover * _ex;
		it.Resistance = Convert.ToInt32(i._Resistance * _ex);
	}
	public static int GetEquipPower(InventoryItem it)
	{
		if(it.Attack != null && it.Defence !=null && it.Health !=null && it.Energy !=null && it.EnergyCover !=null && it.HealthCover != null && it.Resistance !=null)
		{
			return System.Convert.ToInt32(it.Attack * 1 + it.Defence* 0.5 + it.Health * 0.3 +  it.Resistance * 30 + it.HealthCover * 10);
		}
	}

	public static int GetPlayerPower(PlayerInfo info)
	{
		return Convert.ToInt32((info.Attack * 1.0 + info.Defence * 0.5 + info.Health * 0.3 +  info.Resistance * 30.0 + info.HealthCover * 10.0) * (1 + info._Level / 100.0));
	}

	public static void MakePlayerStatus(PlayerInfo info,List<InventoryItem> inventoryItemList)
	{
		info.Attack = info._Attack;
		info.Defence = info._Defence;
		info.Health = info._Health;
		info.HealthCover = info._HealthCover;
		info.Energy = info._Energy;
		info.EnergyCover = info._EnergyCover;
		info.Resistance = info._Resistance;
		foreach(InventoryItem it in inventoryItemList)
		{
			if(it._Item._InventoryType == InventoryType.Equip && it._IsDressed == 1)
			{
				info.Attack += it.Attack;
				info.Defence += it.Defence;
				info.Health += it.Health;
				info.HealthCover += it.HealthCover;
				info.Energy +=it.Energy;
				info.EnergyCover +=it.EnergyCover;
				info.Resistance += it.Resistance;
			}
		}
	}
	public static int GetDifficult(int taskPower,int power)
	{
		if(taskPower<power-1000)
		{
			return 1;
		}
		else if(power-1000<=taskPower && taskPower<power-500)
		{
			return 2;
		}
		else if(power-500<=taskPower && taskPower<power+500)
		{
			return 3;
		}
		else if(power+500<=taskPower && taskPower<power+1000)
		{
			return 4;
		}
		else if(power+1000<=taskPower && taskPower<power+1500)
		{
			return 5;
		}
		else if(power+1500<=taskPower)
		{
			return 6;
		}
		else
		{
			return 0;
		}
	}
}













using System.Collections;
using System.Collections.Generic;
// DataRow 사용을 위함
using System.Data;
using UnityEngine;

public class UserData
{
	public string email;
	public string userName;
	public string characterClass;
	public int level;

	// 다른 생성자를 재사용하여 생성자 오버로딩
	public UserData(DataRow row) : this(row["email"].ToString(), row["username"].ToString(), row["class"].ToString(), int.Parse(row["level"].ToString())) { }

	public UserData(string email, string userName, string characterClass, int level)
	{
		this.email = email;
		this.userName = userName;
		this.characterClass = characterClass;
		this.level = level;
	}
}

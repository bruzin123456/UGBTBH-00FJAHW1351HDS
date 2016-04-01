using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;


public class IniFile : MonoBehaviour { 

	[DllImport("kernel32.dll")]
	private static extern int WritePrivateProfileString(string ApplicationName, string KeyName, string StrValue, string FileName);
	[DllImport("kernel32.dll")]
	private static extern int GetPrivateProfileString(string ApplicationName, string KeyName, string DefaultValue, StringBuilder ReturnString, int nSize, string FileName);



	//Escrever você passa os parametros SectionName, Keyname, KeyValue, e o filename do arquivo.
	//Rapido exemplo de como fica
	//[SectionName] Indice de busca dentro do Ini
	//KeyName= Indice da Chave
	//KeyValue Valor da chave
	//Ficaria assm:
	//[Player]
	//Name = Stanislal
	public static void WriteValue(string SectionName , string KeyName, string KeyValue, string FileName)
	{
		WritePrivateProfileString(SectionName , KeyName, KeyValue, FileName);
	}

	//Aqui ele atribui a busca sobre esses parametros. (ainda estou estudando esta parte!
	public static string ReadValue(string SectionName , string KeyName , string FileName)
	{
		StringBuilder szStr = new StringBuilder(255);
		GetPrivateProfileString(SectionName, KeyName, "" , szStr, 255, FileName);
		return szStr.ToString().Trim();
	}
		
}

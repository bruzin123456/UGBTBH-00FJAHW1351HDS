using UnityEngine;
using System.Collections;
using System;

public class ExIniFile : MonoBehaviour {

	public string Key; //Chave
	public string Section; // Sessão
	public static string SomeValue; // valor da chave


	// adicinar o endreço para ele pegar do executavel, (ainda n implementado)
	void Start () {
		// Escreve no arquivo.ini section, key e valor, no endereço.
		IniFile.WriteValue(Section, Key, SomeValue, "C:\\Users\\Stanislal\\Documents\\GitHub\\UGBTBH-00FJAHW1351HDS\\config.ini");


		//Provavelmente separar o Start em 2 Gravar e Carregar!
		//Busca no inifile.cs a procedure que busca o arquivo com sua sessão e sua chave
		string value = IniFile.ReadValue(Section, Key, "C:\\Users\\Stanislal\\Documents\\GitHub\\UGBTBH-00FJAHW1351HDS\\config.ini");

		Console.WriteLine(value);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

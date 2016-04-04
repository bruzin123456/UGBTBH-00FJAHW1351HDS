using UnityEngine;
using System.Collections;

public class BaseMenuText {
	public string profile;
	public string options;
	public string quitgame;
	public string screenResolution;
	public string screenMode;
	public string apply;
	public string name;
	public string timePlayed;
	public string Progress;
	public string change;
	public string returnToMenu;
	public string join;
	public string host;
	public string startGame;
	public string disconnect;
	public string window;
	public string fullScreen;
	public string save;
	public string confirm;
	public string cancel;
	public string returnn;
	}

public class PortugueseMenuText :  BaseMenuText{
	public PortugueseMenuText(){
		profile = "Perfil";
		options = "Opções";
		quitgame = "Sair Do jogo";
		screenResolution = "Resolução da Tela:";
		screenMode = "Modo de Tela:";
		apply = "Aplicar";
		name = "Nome:";
		timePlayed = "Tempo Jogado:";
		Progress = "Progresso:";
		change = "Trocar";
		returnToMenu = "Voltar Menu";
		join = "Juntar-se";
		host = "Hostear";
		startGame = "Iniciar Jogo";
		disconnect = "Desconectar";
		window = "Janela";
		fullScreen = "Tela Cheia";
		save = "Salvar";
		confirm = "Confirmar";
		cancel = "Cancelar";
		returnn = "Voltar";
	}
}
public class EnglishMenuText :  BaseMenuText{
	public EnglishMenuText(){
		profile = "Profile";
		options = "Options";
		quitgame = "Leave Game";
		screenResolution = "Screen Resolution:";
		screenMode = "Screen Mode:";
		apply = "Apply";
		name = "Name:";
		timePlayed = "Time Played:";
		Progress = "Progress:";
		change = "Change";
		returnToMenu = "To Main Menu";
		join = "Join";
		host = "Host";
		startGame = "Sart Game";
		disconnect = "Desconnect";
		window = "Windown";
		fullScreen = "Fullscreen";
		save = "Save";
		confirm = "Confirm";
		cancel = "Cancel";
		returnn = "Return";
	}
}


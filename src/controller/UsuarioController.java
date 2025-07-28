package controller;

import java.util.ArrayList;

import model.Usuario;

public class UsuarioController {
	
	private static ArrayList <Usuario> usuarios = new ArrayList <> ();
	
	public static void registrarUsuario (Usuario usuario) {
		
		usuarios.add(usuario);
	}
	
	public static ArrayList <Usuario> getUsuarios () {
		
		return usuarios;
	}
	
	public static Usuario buscarPorNombreUsuario (String nombreUsuario) {
		
		for (Usuario usu : usuarios) {
			
			if (usu.getUsuario().equalsIgnoreCase(nombreUsuario)) {
				
				return usu;
			}
		}
		
		return null;
	}

}

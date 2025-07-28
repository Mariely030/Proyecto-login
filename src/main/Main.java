package main;

import gui.VentanaLogin;

public class Main {
	
	public static void main (String[] args) {
		
		javax.swing.SwingUtilities.invokeLater (() -> {
			
			new VentanaLogin();
		});
	}

}

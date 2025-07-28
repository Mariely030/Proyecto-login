package gui;

import javax.swing.*;
import java.awt.*;

public class VentanaLogin extends JFrame {
	
	public VentanaLogin() {
	
    setTitle ("Iniciar sesion");
    setSize (400,250);
    setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    setLocationRelativeTo(null);
    
	
	JLabel usuarioLabel = new JLabel ("Nombre de usuario:");	
    JLabel contraseñaLabel = new JLabel ("Contraseña:");
    
    
    JTextField usuarioField = new JTextField(12);
    JPasswordField contraseñaField = new JPasswordField(12);
    
    
    JButton iniciarsesionButton = new JButton ("Iniciar Sesion");
    JButton registrarseButton = new JButton ("Registrarse");
    
    registrarseButton.addActionListener( e -> {
    	
    	dispose();
    	
    	new VentanaSignup();
    });
    
    
    iniciarsesionButton.addActionListener( e -> {
    	
    	String usuario = usuarioField.getText();
    	String contraseña = new String (contraseñaField.getPassword());
    	
    	if (usuario.isEmpty() || contraseña.isEmpty()) {
    		
    		JOptionPane.showMessageDialog (null,  "No ha completado todos los campos");
    		return;
    	}
    	
    	model.Usuario usu = controller.UsuarioController.buscarPorNombreUsuario(usuario);
    	
    	if (usu != null && usu.getContraseña().equals(contraseña)) {
    		
    		JOptionPane.showMessageDialog(null, "Ha iniciado sesion");
    		
    		dispose();
    		
    		new VentanaPrincipal();
    	
    	} else {
    		
    		JOptionPane.showMessageDialog ( null, "Debe ingresar su usuario\n"
    				+ "y contraseña, si no está registrado debe registrarse");
    	}
    });
    
    
    JPanel panelTitulo = new JPanel();
    JLabel titulo = new JLabel ("Iniciar sesion");
    panelTitulo.add(titulo);
    
    JPanel panelInformacion = new JPanel();
    panelInformacion.setLayout(new GridLayout(3, 2, 5, 5)); 
    
    
    panelInformacion.add (usuarioLabel);
    panelInformacion.add (usuarioField);
    panelInformacion.add (contraseñaLabel);
    panelInformacion.add (contraseñaField);
    panelInformacion.add (iniciarsesionButton);
    panelInformacion.add (registrarseButton);
    
    add(panelInformacion, BorderLayout.CENTER);
    add(panelTitulo, BorderLayout.NORTH);

    
    setVisible(true);

 }
}

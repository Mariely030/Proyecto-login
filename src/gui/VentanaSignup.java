package gui;

import javax.swing.*;
import java.awt.*;

import controller.UsuarioController;
import model.Usuario;

public class VentanaSignup extends JFrame {
	
	public VentanaSignup() {
		
	setTitle ("Iniciar registro");
	setSize (500,450);
	setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	setLocationRelativeTo(null);
	    
	    
	JLabel nombreLabel = new JLabel ("Nombre:");
    JLabel apellidoLabel = new JLabel ("Apellido:");
    JLabel usuarioLabel = new JLabel ("Nombre de usuario:");
	JLabel telefonoLabel = new JLabel ("Telefono:");
	JLabel correoLabel = new JLabel ("Correo:");
    JLabel contraseñaLabel = new JLabel ("Contraseña:");
	JLabel confirmacionContraseñaLabel = new JLabel ("Confirmacion de contraseña:");
	
	
	JTextField nombreField = new JTextField(15);
    JTextField apellidoField = new JTextField(15);
    JTextField usuarioField = new JTextField(15);
    JTextField telefonoField = new JTextField(15);
    JTextField correoField = new JTextField(15);
    JPasswordField contraseñaField = new JPasswordField(15);
    JPasswordField corfimacionContraseñaField = new JPasswordField(15);
    
    
    JButton registrarButton = new JButton ("Registrar");
    
    registrarButton.addActionListener(new java.awt.event.ActionListener() {
    	public void actionPerformed (java.awt.event.ActionEvent e) {
    		
    		String nombre = nombreField.getText();
    		String apellido = apellidoField.getText();
    		String usuario = usuarioField.getText();
    		String telefono = telefonoField.getText();
    		String correo = correoField.getText();
    		String contraseña = new String (contraseñaField.getPassword());
    		String confirmacion = corfimacionContraseñaField.getText();
    		
    		if (nombre.isEmpty() || apellido.isEmpty() || usuario.isEmpty() || telefono.isEmpty() || correo.isEmpty() || 
        		    contraseña.isEmpty() || confirmacion.isEmpty())  {
        			JOptionPane.showMessageDialog (null, "LLenar todos los campos");
        			return;
        		}
    		
    		if (nombre.isEmpty()) {
    			JOptionPane.showMessageDialog (null, "Debe poner su nombre");
    			return;
    			
    		}
    		
    		if (apellido.isEmpty()) {
    			JOptionPane.showMessageDialog (null, "Debe poner su apellido");
    			return;
    			
    		}
    		
    		if (usuario.isEmpty()) {
    			JOptionPane.showMessageDialog (null, "Debe poner un nombre de usuario");
    			return;
    			
    		}
    		
    		if (telefono.isEmpty() || telefono.length() < 10 ) {
    			JOptionPane.showMessageDialog (null, "Debe poner su telefono");
    			return;
    			
    		}
    		
    		if (correo.isEmpty()) {
    			JOptionPane.showMessageDialog (null, "Debe poner su correo");
    			return;
    			
    		}
    		
    		if (!correo.contains("@") || !correo.contains(".")) {
    			JOptionPane.showMessageDialog (null, "Debe escribir correctamente el correo");
    			return;
    		}
    		
    		if (contraseña.isEmpty() || contraseña.length() < 6) {
    			JOptionPane.showMessageDialog (null, "Debe crear una contraseña con minimo 6 digitos");
    			return;
    		}
    		
    		if (confirmacion.isEmpty() || confirmacion.length() < 6) {
    			JOptionPane.showMessageDialog (null, "Debe confirmar la contraseña");
    			return;
    		}
    		
    		if (!contraseña.equals(confirmacion)) {
    			JOptionPane.showMessageDialog (null, "Las contraseñas son diferentes");
    			return;
    		}
    		
    		
    		if (UsuarioController.buscarPorNombreUsuario(usuario) != null ) {
    			JOptionPane.showMessageDialog(null, "Nombre de ususario existente, inicie sesion");
    			return;
    		}
    		
    		Usuario nuevo = new Usuario(nombre, apellido, usuario, telefono, correo, contraseña);
    		UsuarioController.registrarUsuario(nuevo);
    		
    		JOptionPane.showMessageDialog(null, "Registro exitoso");
    		
    		dispose();
    		new VentanaLogin();
    	}
    });
     
    
    JPanel panelTitulo = new JPanel();
    JLabel titulo = new JLabel ("Iniciar registro");
    panelTitulo.add(titulo);
    
    JPanel panelInformacion = new JPanel();
    panelInformacion.setLayout(new GridLayout(8, 3, 5, 5));
    
    panelInformacion.add (nombreLabel);
    panelInformacion.add (nombreField);
    panelInformacion.add (apellidoLabel);
    panelInformacion.add (apellidoField);
    panelInformacion.add (usuarioLabel);
    panelInformacion.add (usuarioField);
    panelInformacion.add (telefonoLabel);
    panelInformacion.add (telefonoField);
    panelInformacion.add (correoLabel);
    panelInformacion.add (correoField);
    panelInformacion.add (contraseñaLabel);
    panelInformacion.add (contraseñaField);
    panelInformacion.add (confirmacionContraseñaLabel);
    panelInformacion.add (corfimacionContraseñaField);
    panelInformacion.add (registrarButton);
    
    JPanel panelButton = new JPanel(new FlowLayout(FlowLayout.CENTER));
    panelButton.add(registrarButton);

    
    add(panelTitulo, BorderLayout.NORTH);
    add(panelInformacion, BorderLayout.CENTER);
    add(panelButton, BorderLayout.SOUTH);
    
    setVisible(true);

 }
}
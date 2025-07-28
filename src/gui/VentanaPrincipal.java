package gui;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;
import controller.UsuarioController;
import model.Usuario;


public class VentanaPrincipal extends JFrame {
	
	public VentanaPrincipal() {
		
		
		setTitle ("Registro de usuarios");
		setSize (500,400);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setLocationRelativeTo(null);
		setLayout (new BorderLayout());
		
		String[] columnas = {"Nombre", "Usuario", "Telefono", "Correo"};
		javax.swing.table.DefaultTableModel modelo = new DefaultTableModel(columnas, 0);
		JTable tabla = new JTable(modelo);
		
		for (Usuario u : UsuarioController.getUsuarios()) {
			
			modelo.addRow(new Object [] {
					
					u.getNombre(),
					u.getUsuario(),
					u.getTelefono(),
					u.getCorreo()
			});
		}
		
		
		JScrollPane scroll = new JScrollPane(tabla);
		
		
		JButton cerrarsesionButton = new JButton ("Cerrar sesion");
	    JButton actualizarButton = new JButton ("Actualizar datos");
	    JButton eliminarButton = new JButton ("Eliminar usuario");
		
	    
	    JPanel panelButton = new JPanel (new FlowLayout());
	    
	    panelButton.add (actualizarButton);
	    panelButton.add (eliminarButton);
	    panelButton.add (cerrarsesionButton);
	    
	    add (panelButton, BorderLayout.SOUTH);
	    add (scroll, BorderLayout.CENTER);

	    cerrarsesionButton.addActionListener ( e -> {
	    	
	    	dispose();
	    	
	    	new VentanaLogin();
	    });
	    
	    
	    eliminarButton.addActionListener ( e -> {
	    	
	    	int  fila = tabla.getSelectedRow();
	    	
	    	if (fila >= 0) {
	    		
	    		String NombreUsu = modelo.getValueAt (fila, 1).toString();
	    		Usuario usu = UsuarioController.buscarPorNombreUsuario (NombreUsu);
	    		
	    		if (usu != null) {
	    			
	    			UsuarioController.getUsuarios().remove(usu);
	    			modelo.removeRow(fila);
	    			
	    		}
	    	   
	    	} else {
	    		
	    		JOptionPane.showMessageDialog(null, "Selecciona el usuario que quieres eliminar");
	    		
	    	}
	    });
	    
	    actualizarButton.addActionListener ( e -> {
	    	
	    	int fila = tabla.getSelectedRow();
	    	
	    	if (fila >= 0) {
	    		
	    		String NombreUsu = modelo.getValueAt (fila, 1).toString();
	    		Usuario Usu = UsuarioController.buscarPorNombreUsuario (NombreUsu);
	    		
	    		if (Usu != null) {
	    			
	    			String newNombre = JOptionPane.showInputDialog ("Nombre actualizado:", Usu.getNombre());
	    			String newUsuario = JOptionPane.showInputDialog ("Usuario actualizado:", Usu.getUsuario());
	     			String newTelefono = JOptionPane.showInputDialog ("Telefono actualizado:", Usu.getTelefono());
	    			String newCorreo = JOptionPane.showInputDialog ("Correo actualizado:", Usu.getCorreo());
	    			
	    			if (newNombre != null) Usu.setNombre (newNombre);
	    			if (newUsuario != null) Usu.setUsuario (newUsuario);
	    			if (newTelefono != null) Usu.setTelefono (newTelefono);
	    			if (newCorreo != null) Usu.setCorreo (newCorreo);
	    			
	    			modelo.setValueAt (Usu.getNombre(), fila, 0);
	    			modelo.setValueAt (Usu.getUsuario(), fila, 1);
	    			modelo.setValueAt (Usu.getTelefono(),  fila, 2);
	    			modelo.setValueAt (Usu.getCorreo(), fila, 3);
	    			
	    		}
	    		
	    	} else {
	    		
	    		JOptionPane.showMessageDialog (null, "Selecciona el usuario que quieres actualizar");
	    	}
	    	
	    });
	    
	    setVisible (true);
	}

}
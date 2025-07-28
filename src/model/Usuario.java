package model;

public class Usuario extends Persona {

	private String usuario;
	private String contraseña;
	
	public Usuario (String nombre, String apellido, String usuario, String telefono, String correo, String contraseña) {
		
		super (nombre, apellido, telefono, correo);
		this.usuario = usuario;
		this.contraseña = contraseña;	
	}
	
	public String getUsuario () {
		return usuario;
	}
	
	public String getContraseña () {
		return contraseña;
	}
	
	public void setUsuario (String usuario) {
		this.usuario = usuario;
	}
	
	public void setContraseña (String contraseña) {
		this.contraseña = contraseña;
	}
	
	public String mostrarInformacion() {
		return "Usuario: " + usuario + " | " + super.mostrarInformacion();
	}

}

package br.com.meucalhambeque02.models;

import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class Cliente {
	@Id
	private String clienteID;
	private String nome;
	private String telefone;
	private String eMail;
    private boolean sincronizado;
	
	public boolean isSincronizado() {
		return sincronizado;
	}

	public void setSincronizado(boolean sincronizado) {
		this.sincronizado = sincronizado;
	}

	public String getTelefone() {
		return telefone;
	}

	public void setTelefone(String telefone) {
		this.telefone = telefone;
	}

	public String geteMail() {
		return eMail;
	}

	public void seteMail(String eMail) {
		this.eMail = eMail;
	}

	public String getClienteID() {
		return clienteID;
	}
	
	public void setClienteID(String clienteID) {
		this.clienteID = clienteID;
	}
	
	public String getNome() {
		return nome;
	}
	
	public void setNome(String nome) {
		this.nome = nome;
	}
}
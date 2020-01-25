package br.com.meucalhambeque02.models;

import java.util.UUID;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Transient;

import org.springframework.web.multipart.MultipartFile;

@Entity
public class Peca {
	@Id
	private UUID pecaID;
	private String nome;
	private double valor;
	private String caminhoImagem;
	private boolean sincronizado;
	private byte[] arquivoEmBytes;
	
	public byte[] getArquivoEmBytes() {
		return arquivoEmBytes;
	}

	public void setArquivoEmBytes(byte[] arquivoEmBytes) {
		this.arquivoEmBytes = arquivoEmBytes;
	}

	@Transient
	private MultipartFile arquivo;
	
	public MultipartFile getArquivo() {
		return arquivo;
	}

	public void setArquivo(MultipartFile arquivo) {
		this.arquivo = arquivo;
	}

    public UUID getPecaID() {
		return pecaID;
	}
    
	public void setPecaID(UUID pecaID) {
		this.pecaID = pecaID;
	}
	
	public String getNome() {
		return nome;
	}
	
	public void setNome(String nome) {
		this.nome = nome;
	}
	
	public double getValor() {
		return valor;
	}
	
	public void setValor(double valor) {
		this.valor = valor;
	}
	
	public String getCaminhoImagem() {
		return caminhoImagem;
	}
	
	public void setCaminhoImagem(String caminhoImagem) {
		this.caminhoImagem = caminhoImagem;
	}
	
	public boolean isSincronizado() {
		return sincronizado;
	}
	
	public void setSincronizado(boolean sincronizado) {
		this.sincronizado = sincronizado;
	}
}
